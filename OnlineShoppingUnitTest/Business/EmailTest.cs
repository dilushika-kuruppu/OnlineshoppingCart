using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShopping.Business.Email;
using OnlineShopping.Business.Order;
using OnlineShopping.Common.OrderDto;
using OnlineShopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingUnitTest.Business
{
    [TestClass]
    public class EmailTest
    {

        Mock<IUnitofWork> _mockUnitofWork;
        Email email;
        OrderDto orderDto;
        OrderManager orderManager;
     

        [TestInitialize]
        public void TestInitialize()
        {
            orderDto = new OrderDto()
            {
                ID = 1,
                UserID = 1,
                Date = 12/1/2020,
                Address = "jdkdjshdkjh fsf fgsg",
                UserName = "Dilu",
                Email = "dilushika@gmail.com",
                Total= 122


            };
            _mockUnitofWork = new Mock<IUnitofWork>();
            _mockOrderRepository = new Mock<IOrderRepository>();
            orderManager.Setup(m => m.sendMail(2)).ReturnsAsync(orderDto);
            _mockUnitofWork.Setup(m => m.OrderRepository).Returns(orderManager.Object);

        }
        [TestMethod]

        public void sendMail_WhenSuccessfull_ReturnProductDetail()
        {
            email = new Email(_mockUnitofWork.Object);
            var product = email.sendMail(2);
            Assert.AreEqual("Dilu", product.Result.UserName);
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

