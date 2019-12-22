namespace Kladionica.Core
{
    public static class OkladaRepositoryFactory
    {
        public static IOkladaRepository Create()
        {
            return new OkladaRepository();
        }
    }
}