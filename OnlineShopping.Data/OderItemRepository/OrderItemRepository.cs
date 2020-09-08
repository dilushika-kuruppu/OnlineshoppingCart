using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Common;
using OnlineShopping.Common.OrderDto;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
   public class OrderItemRepository: IOrderItemRepository
    {
        private readonly OnlineShoppingContext _context;

        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="OrderPItemRepository" /> class.</summary>
        /// <param name="dataContext">The data context.</param>
        /// <param name="mapper">The mapper.</param>
        public OrderItemRepository(OnlineShoppingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>Adds the order product.</summary>
        /// <param name="orderItemDto">The order product dto.</param>
        /// <returns></returns>
        public async Task<OrderItemDto> AddOrderItem(OrderItemDto orderItemDto)
        {
            OrderItem orderItem = _mapper.Map<OrderItemDto, OrderItem>(orderItemDto);
            await _context.OrderItem.AddAsync(orderItem);
            await _context.SaveChangesAsync();
            return orderItemDto;
        }


        /// <summary>Deletes the specified entity.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Task<OrderDetailsDto> GetOrder(int userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>Gets the order product.</summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        public async Task<OrderItemDto> GetOrderItem(int i)
        {
            OrderItem orderItem = await _context.OrderItem.FirstOrDefaultAsync(x => x.Id == i);
            return _mapper.Map<OrderItem, OrderItemDto>(orderItem);
        }

        /// <summary>Saves all.</summary>
        /// <returns></returns>
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

