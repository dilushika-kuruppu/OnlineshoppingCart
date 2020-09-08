
using OnlineShopping.Common.OrderDto;
using OnlineShopping.Common.PaymentDto;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Order
{
    public interface IOrderManager
    {
        Task<Orders> CreateOrderAsync(OrderDto orderDto);
        Task<OrderDetailsDto> GetOrder(int userId);
        Task<IEnumerable<OrderListDto>> GetOrders();
        Task<bool> DeleteOrder(int id);
        Task<IEnumerable<OrderInformDto>> GetOrderInfromation(int userId);
        Task<IEnumerable<OrderInfromProductDto>> GetOrderInformationProduct(int orderId);
       

    }
}
