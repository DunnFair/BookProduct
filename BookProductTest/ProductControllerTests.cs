using AutoMapper;
using BookProduct.Controllers;
using BookProduct.Models;
using BookProduct.Service;
using BookProduct.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BookProductTest
{
    public class ProductControllerTests
    {
        private Mock<IProductService> _productServiceMock;
        private Mock<IMapper> _mapperMock;
        private ProductController _productController;
        [SetUp]
        public void Setup()
        {
            _productServiceMock = new Mock<IProductService>();
            _mapperMock = new Mock<IMapper>();
            _productController = new ProductController(_productServiceMock.Object, _mapperMock.Object);
        }
        [Test]
        public void GetProducts_ReturnOkWithAllProducts()
        {
            // Arrange
            var expectedProducts = new List<Product>()
            {
                new Product { Id = 1, Title = "Product 1" },
                new Product { Id = 2, Title = "Product 2" }
            };
            var expectedViewModels = new List<ProductViewModel>()
            {
                new ProductViewModel { Id = 1, Title = "Product 1" },
                new ProductViewModel { Id = 2, Title = "Product 2" }
            };

            _productServiceMock.Setup(p => p.Get()).Returns(expectedProducts);
            _mapperMock.Setup(m => m.Map<List<ProductViewModel>>(It.IsAny<List<Product>>()))
                .Returns(expectedViewModels);

            // Act
            var result = _productController.GetProducts();

            // Assert
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(expectedViewModels, okResult.Value);
        }
        [Test]
        public void GetProducts_ShouldReturnNotFoundWhenNoProductsFound()
        {
            // Arrange
            _productServiceMock.Setup(p => p.Get()).Returns(new List<Product>());

            // Act
            var result = _productController.GetProducts();

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
