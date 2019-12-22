namespace Kladionica.Core
{
    public static class ListicFactory
    {
        public static UIModel.Listic Create(Model.Listic listic)
        {
            return new UIModel.Listic
            {
                ListicId = listic.ListicId,
                VrijemeUplate = listic.VrijemeUplate,
                IznosUplate = listic.IznosUplate,
                MoguciDobitak = listic.MoguciDobitak,
                BrojOklada = listic.Okladas.Count,
                UpdateDate = listic.UpdateDate
            };
        }

        public static Model.Listic CreateRecord(UIModel.Listic listic)
        {
            return new Model.Listic
            {
                VrijemeUplate = listic.VrijemeUplate,
                IznosUplate = listic.IznosUplate,
                MoguciDobitak = listic.MoguciDobitak
            };
        }
    }
}