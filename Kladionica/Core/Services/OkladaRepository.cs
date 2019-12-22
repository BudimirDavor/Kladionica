using Kladionica.Core.UIModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kladionica.Core
{
    public class OkladaRepository : DatabaseRepository, IOkladaRepository
    {
        public UIModel.Oklada[] GetOkladas(long listicId)
        {
            var okladas = _dataContext.GetOkladas(listicId);

            return okladas.Select(OkladaFactory.Create).ToArray();
        }

        public Oklada GetOklada(long okladaId)
        {
            var record = Find(okladaId);

            if (record != null)
            {
                return OkladaFactory.Create(record);
            }

            throw new Exception($"Found no Oklada record with OkladaId={okladaId}");
        }

        public void Add(UIModel.Oklada oklada) 
        {
            var okladas = GetOkladas(oklada.ListicId);

            if (okladas.Length >= Constants.MaxNumOfOkladasPerListic)
            {
                throw new Exception($"Maksimalan broj oklada na listiću je {Constants.MaxNumOfOkladasPerListic}!");
            }

            var record = OkladaFactory.CreateRecord(oklada);

            _dataContext.Okladas.Add(record);
        }

        public void Delete(long okladaId) 
        {
            var record = Find(okladaId);

            if (record != null)
            {
                _dataContext.Okladas.Remove(record);
            }
        }

        private Model.Oklada Find(long okladaId)
        {
            return _dataContext.Okladas.Find(okladaId);
        }

        public IEnumerable<UIModel.Oklada> GetOkladasWithListic(string vrijemeUplate,
            string iznosUplate, string moguciDobitak, string koeficient)
        {
            DateTime.TryParse(vrijemeUplate, out DateTime vrijeme);
            double.TryParse(iznosUplate, out double iznos);
            double.TryParse(moguciDobitak, out double dobitak);
            double.TryParse(koeficient, out double koef);

            var query = _dataContext.Okladas
                .Where(r => (string.IsNullOrEmpty(vrijemeUplate) || r.Listic.VrijemeUplate == vrijeme)
                    && (string.IsNullOrEmpty(iznosUplate) || r.Listic.IznosUplate == iznos)
                    && (string.IsNullOrEmpty(moguciDobitak) || r.Listic.MoguciDobitak == dobitak)
                    && (string.IsNullOrEmpty(koeficient) || r.Koeficient == koef));

            return query.Select(OkladaFactory.CreateWithListic);
        }
    }
}
