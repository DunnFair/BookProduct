using AutoMapper;
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
        public IEnumerable<ProductViewModel> GetProducts()
        {
            var data = _productService.Get();
            return _mapper.Map<List<ProductViewModel>>(data);
        }
    }
}
