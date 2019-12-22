namespace Kladionica.Core
{
    public static class SusretFactory
    {
        public static UIModel.Susret Create(Model.Susret susret)
        {
            return new UIModel.Susret
            {
                SusretId = susret.SusretId,
                Domacin = susret.Domacin,
                Gost = susret.Gost,
                BrojPonuda = susret.Ponudas.Count
            };
        }

        public static Model.Susret CreateRecord(UIModel.Susret susret)
        {
            return new Model.Susret
            {
                Domacin = susret.Domacin,
                Gost = susret.Gost
            };
        }
    }
}