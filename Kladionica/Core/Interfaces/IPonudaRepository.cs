using System.Collections.Generic;

namespace Kladionica.Core
{
    public interface IPonudaRepository : ISaveable
    {
        IEnumerable<UIModel.Ponuda> GetPonudas(long susretId);
        UIModel.Ponuda GetPonuda(long ponudaId);
        void Add(UIModel.Ponuda ponuda);
        void Update(UIModel.Ponuda ponuda);
        void Delete(long ponudaId);
        IEnumerable<UIModel.Ponuda> GetPonudasWithSusret(string domacin, string gost, string tip, string koeficient);
        IEnumerable<UIModel.Ponuda> GetAllPonudas();
    }
}
