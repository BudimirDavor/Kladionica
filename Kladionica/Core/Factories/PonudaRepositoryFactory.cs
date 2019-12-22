namespace Kladionica.Core
{
    public static class PonudaRepositoryFactory
    {
        public static IPonudaRepository Create()
        {
            return new PonudaRepository();
        }
    }
}