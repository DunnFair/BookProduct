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
        /// <summary>
        /// 取得單一產品
        /// </summary>
        /// <returns></returns>
        Product GetFirstOrDefault(int Id);
        /// <summary>
        /// 更新多筆產品
        /// </summary>
        /// <param name="product"></param>
        void Update(Product product);
        /// <summary>
        /// 更新多筆產品
        /// </summary>
        /// <param name="products"></param>
        void UpdateRange(IEnumerable<Product> products);
        /// <summary>
        /// 刪除單筆
        /// </summary>
        /// <param name="product"></param>
        void Delete(Product product);
        /// <summary>
        /// 刪除多筆
        /// </summary>
        /// <param name="products"></param>
        void DeleteRange(IEnumerable<Product> products);
    }
}
