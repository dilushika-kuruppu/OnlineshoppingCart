using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShopping.Business.Product;
using OnlineShopping.Common.ProductDto;
using OnlineShopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingUnitTest.Business
{

    [TestClass]
    public class ProductManagerTest

    {
        Mock<IUnitofWork> _mockUnitofWork;
        ProductManager productManager;
        ProductDetailDto productDetailDto;
        Mock<IProductRepository> _mockProductRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            productDetailDto = new ProductDetailDto()
            {
                Id = 1,
                CategoryId = 1,
                Name = "Dilu",
                Price = "Rs.139",
                Description = "jdkdjshdkjh"


            };
            _mockUnitofWork = new Mock<IUnitofWork>();
            _mockProductRepository = new Mock<IProductRepository>();
            _mockProductRepository.Setup(m => m.GetProduct(2)).ReturnsAsync(productDetailDto);
            _mockUnitofWork.Setup(m => m.ProductRepository).Returns(_mockProductRepository.Object);

        }
        [TestMethod]

        public void GetProduct_WhenSuccessfull_ReturnProductDetail()
        {
            productManager = new ProductManager(_mockUnitofWork.Object);
            var product = productManager.GetProduct(2);
            Assert.AreEqual("Dilu", product.Result.Name);
        }
        //[TestMethod]
        //public void GetProductbyCategory_WhenSuccessfull_ReturnProductDetail()
        //{
        //    productManager = new ProductManager(_mockUnitofWork.Object);
        //    var product = productManager.GetProductbyCategory(2);
        //    Assert.AreEqual("dilu", product.Result.Name);
        //}
       
    }
}
