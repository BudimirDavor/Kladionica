using System.Collections.Generic;

namespace Kladionica.Core
{
    public interface ISusretRepository : ISaveable
    {
        IEnumerable<UIModel.Susret> GetSusrets(string domacin, string gost);
        UIModel.Susret GetSusret(long susretId);
        void Add(UIModel.Susret susret);
        void Update(UIModel.Susret susret);
        void Delete(long susretId);
    }
}
