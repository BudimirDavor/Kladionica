using Kladionica.Core.UIModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kladionica.Core
{
    public class PonudaRepository : DatabaseRepository, IPonudaRepository
    {
        public IEnumerable<UIModel.Ponuda> GetPonudas(long susretId)
        {
            var query = _dataContext.Ponudas.Where(r => r.SusretId == susretId);

            return query.Select(PonudaFactory.Create);
        }

        public Ponuda GetPonuda(long ponudaId)
        {
            var record = Find(ponudaId);

            if (record != null)
            {
                return PonudaFactory.Create(record);
            }

            throw new Exception($"Found no Ponuda record with PonudaId={ponudaId}");
        }

        public void Add(UIModel.Ponuda ponuda) 
        {
            var record = PonudaFactory.CreateRecord(ponuda);

            _dataContext.Ponudas.Add(record);
        }

        public void Update(UIModel.Ponuda ponuda) 
        {
            var record = Find(ponuda.PonudaId);

            if (record != null)
            {
                record.Tip = ponuda.Tip;
                record.Koeficient = ponuda.Koeficient;
            }
        }

        public void Delete(long PonudaId) 
        {
            var record = Find(PonudaId);

            if (record != null)
            {
                _dataContext.Ponudas.Remove(record);
            }
        }

        private Model.Ponuda Find(long PonudaId)
        {
            return _dataContext.Ponudas.Find(PonudaId);
        }

        public IEnumerable<Ponuda> GetPonudasWithSusret(string domacin, string gost, string tip, string koeficient)
        {
            double.TryParse(koeficient, out double koef);

            var query = _dataContext.Ponudas
                .Where(r => (string.IsNullOrEmpty(domacin) || r.Susret.Domacin.StartsWith(domacin))
                    && (string.IsNullOrEmpty(gost) || r.Susret.Gost.StartsWith(gost))
                    && (string.IsNullOrEmpty(tip) || r.Tip == tip)
                    && (string.IsNullOrEmpty(koeficient) || r.Koeficient == koef));

            return query.Select(PonudaFactory.CreateWithSusret);
        }

        public IEnumerable<Ponuda> GetAllPonudas()
        {
            return _dataContext.Ponudas.Select(PonudaFactory.CreateWithSusret);
        }
    }
}
