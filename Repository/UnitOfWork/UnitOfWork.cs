namespace BookProduct.Repository.UnitOfWork
{
    using BookProduct.Repository.Data;
    using BookProduct.Repository.IRepository;
    using Microsoft.EntityFrameworkCore;
    using System.Collections;
    using System.Collections.Concurrent;

    public class UnitOfWork:IUnitOfWork
    {
        //private readonly ConcurrentDictionary<Type, object> _repositories = new();
        private readonly ApplicationDbContext _dbContext;
        private Hashtable _repositories;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEFRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            string name = typeof(T).Name;
            if (!_repositories.ContainsKey(name))
            {
                Type typeFromHandle = typeof(EFRepository<>);
                object value = Activator.CreateInstance(typeFromHandle.MakeGenericType(typeof(T)), _dbContext);
                _repositories.Add(name, value);
            }

            return (IEFRepository<T>)_repositories[name];
        }
    }

}
