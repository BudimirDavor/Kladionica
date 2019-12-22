using System;

namespace Kladionica.Core
{
    public abstract class DatabaseRepository : ISaveable, IDisposable
    {
        protected readonly Model.KladionicaEntities _dataContext;

        public DatabaseRepository()
        {
            _dataContext = new Model.KladionicaEntities();
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}
