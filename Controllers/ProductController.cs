using AutoMapper;
using BookProduct.Models;
using BookProduct.Service;
using BookProduct.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController:ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        /// <summary>
        /// 取得所有產品
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IEnumerable<ProductViewModel> Get()
        {
            var data = _productService.Get();
            return _mapper.Map<List<ProductViewModel>>(data);
        }

        /// <summary>
        /// 取得單一產品
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public ProductViewModel Get(int Id)
        {
            var data = _productService.GetFirstOrDefault(Id);
            return _mapper.Map<ProductViewModel>(data);
        }
        /// <summary>
        /// 更新單筆產品
        /// </summary>
        /// <param name="product"></param>
        [HttpPost]
        public void Update(Product product)
        {
            _productService.Update(product);
        }
        /// <summary>
        /// 更新多筆產品
        /// </summary>
        /// <param name="products"></param>
        [HttpPost]
        public void Update(IEnumerable<Product> products)
        {
            _productService.UpdateRange(products);
        }
        /// <summary>
        /// 刪除單筆產品
        /// </summary>
        /// <param name="product"></param>
        [HttpPost]
        public void Delete(Product product)
        {
            _productService.Delete(product);
        }
        /// <summary>
        /// 刪除多筆產品
        /// </summary>
        /// <param name="products"></param>
        [HttpPost]
        public void Delete(IEnumerable<Product> products)
        {
            _productService.DeleteRange(products);
        }
    }
}
