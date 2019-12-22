using System.Collections.Generic;

namespace Kladionica.Core
{
    public interface IOkladaRepository : ISaveable
    {
        UIModel.Oklada[] GetOkladas(long listicId);
        UIModel.Oklada GetOklada(long okladaId);
        void Add(UIModel.Oklada oklada);
        void Delete(long okladaId);
        IEnumerable<UIModel.Oklada> GetOkladasWithListic(string vrijemeUplate, 
            string iznosUplate, string moguciDobitak, string koeficient);
    }
}
