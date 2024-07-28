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
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        /// <summary>
        /// 取得所有產品
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IEnumerable<ProductViewModel> GetProducts()
        {
            var data = _productService.Get();
            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach (var item in data)
            {
                ProductViewModel productViewModel = new ProductViewModel();
                productViewModel.Author = item.Author;
                productViewModel.Id = item.Id;
                productViewModel.Description = item.Description;
                productViewModel.Title = item.Title;
                products.Add(productViewModel);
            }
            return products;
        }
    }
}
