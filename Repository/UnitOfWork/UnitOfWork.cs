namespace BookProduct.Repository.UnitOfWork
{
    using BookProduct.Repository.Data;
    using BookProduct.Repository.IRepository;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Concurrent;

    public class UnitOfWork:IUnitOfWork
    {
        private readonly ConcurrentDictionary<Type, object> _repositories = new();
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEFRepository<T>? Repository<T>() where T : class
        {
            return _repositories.GetOrAdd(typeof(T), _ =>
            {
                try
                {
                    var repositoryType = typeof(IEFRepository<>).MakeGenericType(typeof(T));
                    return (IEFRepository<T>)Activator.CreateInstance(repositoryType, _dbContext);
                }
                catch (Exception ex)
                {
                    // 處理異常，例如記錄錯誤或拋出自定義異常
                    Console.Error.WriteLine($"Failed to create repository for {typeof(T).Name}: {ex.Message}");
                    throw; 
                }
            }) as IEFRepository<T>;
        }
    }

}
