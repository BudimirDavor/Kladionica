namespace Kladionica.Core
{
    public static class OkladaFactory
    {
        public static UIModel.Oklada Create(Model.Oklada oklada)
        {
            return new UIModel.Oklada
            {
                OkladaId = oklada.OkladaId,
                ListicId = oklada.ListicId,
                Koeficient = oklada.Koeficient
            };
        }

        public static Model.Oklada CreateRecord(UIModel.Oklada oklada)
        {
            return new Model.Oklada
            {
                OkladaId = oklada.OkladaId,
                ListicId = oklada.ListicId,
                PonudaId = oklada.PonudaId,
                Koeficient = oklada.Koeficient
            };
        }

        public static UIModel.Oklada CreateWithListic(Model.Oklada oklada)
        {
            var listic = ListicFactory.Create(oklada.Listic);

            return new UIModel.Oklada
            {
                Listic = listic.ToString(),
                Koeficient = oklada.Koeficient
            };
        }

        public static UIModel.Oklada Create(Model.GetOkladas_Result result)
        {
            return new UIModel.Oklada
            {
                OkladaId = result.OkladaId,
                Ponuda = result.Name,
                ListicId = result.ListicId,
                PonudaId = result.PonudaId,
                Koeficient = result.Koeficient
            };
        }
    }
}