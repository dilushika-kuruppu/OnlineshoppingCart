using OnlineShopping.Common.OrderDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
   public  interface IOrderRepository
    {
        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
        Task<OrderDto> CheckOrderStatus(int userId);
        Task<IEnumerable<OrderDetailsDto>> GetOrder(int userId);
        Task<IEnumerable<OrderInformDto>> GetOrderInfromation(int userId);
        Task<IEnumerable<OrderInfromProductDto>> GetOrderInformationProduct(int orderId);
        Task<IEnumerable<OrderListDto>> GetOrders();
    
    }
}
