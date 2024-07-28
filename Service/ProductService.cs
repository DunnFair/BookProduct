using BookProduct.Models;
using BookProduct.Repository.UnitOfWork;

namespace BookProduct.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 取得所有產品
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> Get()
        {
            var getData = _unitOfWork.Repository<Product>().GetAll();
            return getData;
        }
    }
}
