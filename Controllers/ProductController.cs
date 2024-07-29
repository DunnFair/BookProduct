using AutoMapper;
using BookProduct.Models;
using BookProduct.Service;
using BookProduct.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
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
        public IActionResult GetProducts()
        {
            var data = _productService.Get();
            return Ok(_mapper.Map<List<ProductViewModel>>(data));
        }

        /// <summary>
        /// 取得單一產品
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("{Id}")]
        public IActionResult GetProduct(int Id)
        {
            var data = _productService.GetFirstOrDefault(Id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProductViewModel>(data));
        }
        /// <summary>
        /// 更新單筆產品
        /// </summary>
        /// <param name="product"></param>
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            _productService.Update(product);
            return NoContent();
        }
        /// <summary>
        /// 更新多筆產品
        /// </summary>
        /// <param name="products"></param>
        [HttpPost]
        public IActionResult UpdateProducts(IEnumerable<Product> products)
        {
            _productService.UpdateRange(products);
            return NoContent();
        }
        /// <summary>
        /// 刪除單筆產品
        /// </summary>
        /// <param name="product"></param>
        [HttpDelete("{Id}")]
        public IActionResult DeleteProduct(int Id)
        {
            _productService.Delete(Id);
            return NoContent();
        }
        /// <summary>
        /// 刪除多筆產品
        /// </summary>
        /// <param name="products"></param>
        [HttpDelete]
        public IActionResult DeleteProducts(IEnumerable<Product> products)
        {
            _productService.DeleteRange(products);
            return NoContent();
        }
    }
}
