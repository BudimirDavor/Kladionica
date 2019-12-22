namespace Kladionica.Core
{
    public static class SusretRepositoryFactory
    {
        public static ISusretRepository Create()
        {
            return new SusretRepository();
        }
    }
}