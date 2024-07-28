using BookProduct.Repository.IRepository;

namespace BookProduct.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IEFRepository<T> Repository<T>() where T : class;
    }
}
