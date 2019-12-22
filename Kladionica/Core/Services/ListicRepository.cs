using System;
using System.Collections.Generic;
using System.Linq;

namespace Kladionica.Core
{
    public class ListicRepository : DatabaseRepository, IListicRepository
    {
        public IEnumerable<UIModel.Listic> GetListics(string vrijemeUplate, string iznosUplate)
        {
            DateTime.TryParse(vrijemeUplate, out DateTime vrijeme);
            double.TryParse(iznosUplate, out double iznos);

            var query = _dataContext.Listics
                .Where(r => (string.IsNullOrEmpty(vrijemeUplate) || r.VrijemeUplate == vrijeme)
                    && (string.IsNullOrEmpty(iznosUplate) || r.IznosUplate == iznos));

            return query.Select(ListicFactory.Create);
        }

        public UIModel.Listic GetListic(long listicId)
        {
            var record = Find(listicId);

            if (record != null)
            {
                return ListicFactory.Create(record);
            }

            throw new Exception($"Found no Listic record with ListicId={listicId}");
        }

        public void Add(UIModel.Listic listic)
        {
            var record = ListicFactory.CreateRecord(listic);

            _dataContext.Listics.Add(record);
        }

        public void Update(UIModel.Listic listic)
        {
            var record = Find(listic.ListicId);

            if (listic.UpdateDate.ToString() != record.UpdateDate.ToString())
            {
                throw new Exception("Netko je u međuvremenu već napravio promjene na tom zapisu!");
            }

            if (record != null)
            {
                record.VrijemeUplate = listic.VrijemeUplate;
                record.IznosUplate = listic.IznosUplate;
                record.MoguciDobitak = listic.MoguciDobitak;
                record.UpdateDate = DateTime.Now;
            }
        }

        public void Delete(long listicId)
        {
            var record = Find(listicId);

            if (record != null)
            {
                _dataContext.Listics.Remove(record);
            }
        }

        private Model.Listic Find(long listicId)
        {
            return _dataContext.Listics.Find(listicId);
        }

        public void UpdateMoguciDobitak(long listicId)
        {
            var listic = GetListic(listicId);
            var okladaRepository = OkladaRepositoryFactory.Create();
            var oklade = okladaRepository.GetOkladas(listicId);
            listic.MoguciDobitak = CalculateMoguciDobitak(listicId, listic.IznosUplate, oklade);

            Update(listic);
            Save();
        }

        public double? CalculateMoguciDobitak(long listicId, double iznosUplate, UIModel.Oklada[] oklade)
        {
            var listic = GetListic(listicId);
            listic.MoguciDobitak = null;

            if (oklade.Any())
            {
                listic.MoguciDobitak = iznosUplate;

                foreach (var item in oklade)
                {
                    listic.MoguciDobitak *= item.Koeficient;
                }
            }

            return listic.MoguciDobitak;
        }

        public void ValidateMoguciDobitak(long listicId, double? moguciDobitak, UIModel.Oklada[] oklade)
        {
            var okladaRepository = OkladaRepositoryFactory.Create();
            var identicalListici = new List<UIModel.Listic>();

            if (moguciDobitak.HasValue)
            {
                var listici = GetListics(null, null);

                foreach (var listic in listici)
                {
                    if (listic.ListicId != listicId)
                    {
                        var okladeNaDrugomListicu = okladaRepository.GetOkladas(listic.ListicId);
                        int countOfIdenticalOkladas = 0;

                        foreach (var oklada in oklade)
                        {
                            if (okladeNaDrugomListicu.Any(o => o.PonudaId == oklada.PonudaId))
                            {
                                countOfIdenticalOkladas++;
                            }
                        }

                        if (countOfIdenticalOkladas == oklade.Length)
                        {
                            identicalListici.Add(listic);
                        }
                    }
                }

                double zbrojMogucihDobitaka = moguciDobitak ?? 0;

                foreach (var listic in identicalListici)
                {
                    if (listic.MoguciDobitak.HasValue)
                    {
                        zbrojMogucihDobitaka += listic.MoguciDobitak.Value;
                    }
                }

                if (zbrojMogucihDobitaka > Constants.MaxSumOfDobitakOnIdenticalListic)
                {
                    throw new Exception($"Zbroj mogućih dobitaka na identičnim listićima ne smije biti veći od {Constants.MaxSumOfDobitakOnIdenticalListic}!");
                }
            }
        }
    }
}
