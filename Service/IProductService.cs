using BookProduct.Models;

namespace BookProduct.Service
{
    public interface IProductService
    {
        /// <summary>
        /// 取得所有產品
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> Get();
    }
}
