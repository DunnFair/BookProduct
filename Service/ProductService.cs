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

        /// <summary>
        /// 取得單一產品
        /// </summary>
        /// <returns></returns>
        public Product GetFirstOrDefault(int Id)
        {
            var getData = _unitOfWork.Repository<Product>().GetAll().Where(o => o.Id == Id);
            if (getData != null)
            {
                var result = getData.SingleOrDefault();
                return result;
            }
            else
            {
                return new Product();
            }

        }
        /// <summary>
        /// 更新單筆產品
        /// </summary>
        /// <param name="product"></param>
        public void Update(Product product)
        {
            _unitOfWork.Repository<Product>().Update(product);

        }

        /// <summary>
        /// 更新多筆產品
        /// </summary>
        /// <param name="products"></param>
        public void UpdateRange(IEnumerable<Product> products)
        {
            _unitOfWork.Repository<Product>().UpdateRange(products);
        }

        /// <summary>
        /// 刪除單筆
        /// </summary>
        /// <param name="product"></param>
        public void Delete(int Id)
        {
            var data = _unitOfWork.Repository<Product>().GetAll().Where(o => o.Id == Id).SingleOrDefault();
            if (data != null)
            {
                _unitOfWork.Repository<Product>().Remove(data);
            }

        }

        /// <summary>
        /// 刪除多筆
        /// </summary>
        /// <param name="products"></param>
        public void DeleteRange(IEnumerable<Product> products)
        {
            _unitOfWork.Repository<Product>().RemoveRange(products);
        }
    }
}
