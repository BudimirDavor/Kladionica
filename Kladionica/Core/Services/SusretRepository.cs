using Kladionica.Core.UIModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kladionica.Core
{
    public class SusretRepository : DatabaseRepository, ISusretRepository
    {
        public IEnumerable<UIModel.Susret> GetSusrets(string domacin, string gost)
        {
            var query = _dataContext.Susrets
                .Where(s => (string.IsNullOrEmpty(domacin) || s.Domacin.StartsWith(domacin))
                    && (string.IsNullOrEmpty(gost) || s.Gost.StartsWith(gost)));

            return query.Select(SusretFactory.Create);
        }

        public Susret GetSusret(long susretId)
        {
            var record = Find(susretId);

            if (record != null)
            {
                return SusretFactory.Create(record);
            }

            throw new Exception($"Found no Susret record with SusretId={susretId}");
        }

        public void Add(UIModel.Susret susret) 
        {
            var record = SusretFactory.CreateRecord(susret);

            _dataContext.Susrets.Add(record);
        }

        public void Update(UIModel.Susret susret) 
        {
            var record = Find(susret.SusretId);

            if (record != null)
            {
                record.Domacin = susret.Domacin;
                record.Gost = susret.Gost;
            }
        }

        public void Delete(long susretId) 
        {
            var record = Find(susretId);

            if (record != null)
            {
                _dataContext.Susrets.Remove(record);
            }
        }

        private Model.Susret Find(long susretId)
        {
            return _dataContext.Susrets.Find(susretId);
        }
    }
}
