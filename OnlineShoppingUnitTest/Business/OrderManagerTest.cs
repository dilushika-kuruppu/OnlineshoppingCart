using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShopping.Business.Order;
using OnlineShopping.Common.OrderDto;
using OnlineShopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShoppingUnitTest.Business
{
    [TestClass]
   public class OrderManagerTest
    {
        Mock<IUnitofWork> _mockUnitofWork;
        OrderManager orderManager;
        OrderDetailsDto orderDetailsDto;
        Mock<IOrderRepository> _mockOrderRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            orderDetailsDto = new OrderDetailsDto()
            {
                OrderId = 1,
                OrderItemId = 1,
                ProductId = 1,
                ProductPrice = "rs.50",
                Quantity = 1,
                UserId = 1


            };
            _mockUnitofWork = new Mock<IUnitofWork>();
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockOrderRepository.Setup(m=> m.GetOrder(2)).ReturnsAsync(orderDetailsDto);
            _mockUnitofWork.Setup(m => m.OrderRepository).Returns(_mockOrderRepository.Object);

        }
     
      
        [TestMethod]
        public void GetOrder_WhenSuccessfull_ReturnOrderDetail(int userId)
        {
            orderManager = new OrderManager(_mockUnitofWork.Object);
            var orderObject = orderManager.GetOrder(1);
            Assert.AreEqual(1, orderObject.Result.UserId);
        }

    }

}

