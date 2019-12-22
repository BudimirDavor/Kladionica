namespace Kladionica.Core
{
    public static class ListicRepositoryFactory
    {
        public static IListicRepository Create()
        {
            return new ListicRepository();
        }
    }
}