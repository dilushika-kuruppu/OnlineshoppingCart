using OnlineShopping.Common;
using OnlineShopping.Common.OrderDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
  public interface IOrderItemRepository
    {
        Task<OrderItemDto> AddOrderItem(OrderItemDto orderItemDto);
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<OrderItemDto> GetOrderItem(int i);
        Task<OrderDetailsDto> GetOrder(int userId);
    }
}
