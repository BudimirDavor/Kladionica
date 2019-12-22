namespace Kladionica.Core
{
    public static class PonudaFactory
    {
        public static UIModel.Ponuda Create(Model.Ponuda ponuda)
        {
            return new UIModel.Ponuda
            {
                PonudaId = ponuda.PonudaId,
                SusretId = ponuda.SusretId,
                Tip = ponuda.Tip,
                Koeficient = ponuda.Koeficient
            };
        }

        public static Model.Ponuda CreateRecord(UIModel.Ponuda ponuda)
        {
            return new Model.Ponuda
            {
                SusretId = ponuda.SusretId,
                Tip = ponuda.Tip,
                Koeficient = ponuda.Koeficient
            };
        }

        public static UIModel.Ponuda CreateWithSusret(Model.Ponuda ponuda)
        {
            var susret = SusretFactory.Create(ponuda.Susret);

            return new UIModel.Ponuda
            {
                PonudaId = ponuda.PonudaId,
                Susret = susret.ToString(),
                Tip = ponuda.Tip,
                Koeficient = ponuda.Koeficient
            };
        }
    }
}