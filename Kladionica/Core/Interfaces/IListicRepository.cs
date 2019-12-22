using System.Collections.Generic;

namespace Kladionica.Core
{
    public interface IListicRepository : ISaveable
    {
        IEnumerable<UIModel.Listic> GetListics(string vrijemeUplate, string iznosUplate);
        UIModel.Listic GetListic(long listicId);
        void Add(UIModel.Listic listic);
        void Update(UIModel.Listic listic);
        void Delete(long listicId);
        void UpdateMoguciDobitak(long listicId);
        double? CalculateMoguciDobitak(long listicId, double iznosUplate, UIModel.Oklada[] oklade);
        void ValidateMoguciDobitak(long listicId, double? moguciDobitak, UIModel.Oklada[] oklade);
    }
}
