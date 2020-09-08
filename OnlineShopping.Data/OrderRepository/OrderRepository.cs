using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Common.OrderDto;
using OnlineShopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OnlineShoppingContext _context;

        private readonly IMapper _mapper;

        /// <summary>Initializes a new instance of the <see cref="OrderRepository" /> class.</summary>
        /// <param name="dataContext">The data context.</param>
        /// <param name="mapper">The mapper.</param>
        public OrderRepository(OnlineShoppingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>Adds the order.</summary>
        /// <param name="orderDto">The order dto.</param>
        /// <returns></returns>
        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            Orders order = _mapper.Map<OrderDto, Orders>(orderDto);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
         
            return orderDto;
        }

        /// <summary>Checks the order status.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<OrderDto> CheckOrderStatus(int userId)
        {
            Orders order = await _context.Orders.Where(s => s.Id == userId).FirstOrDefaultAsync();

            OrderDto orderDto = _mapper.Map<Orders, OrderDto>(order);

            return orderDto;
        }
        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }


        /// <summary>Gets the order.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<OrderDetailsDto>> GetOrder(int userId)
        {
            var orderDetails = await (from Order in _context.Orders
                                      join
                                         OrderItem in _context.OrderItem on
                                         Order.Id equals OrderItem.OrderId
                                      join
                                        product in _context.Product on OrderItem.ProductId equals product.Id
                                      
                                      where Order.Id == userId
                                      select new OrderDetailsDto()
                                      {
                                          OrderId = Order.Id,
                                          OrderItemId=OrderItem.Id,
                                          ProductId = product.Id,
                                          ProductPrice = product.Price,
                                          Quantity =OrderItem.Quantity


                                      }).ToListAsync();

           
                                        

            return orderDetails;

        }
        public async Task<IEnumerable<OrderListDto>> GetOrders()

        {
            //var products = await _context.Product.ToListAsync();
            //return _mapper.Map<ProductListDto[]>(products);
            var orders = await (from Order in _context.Orders
                               join
                                  OrderItem in _context.OrderItem on
                                  Order.Id equals OrderItem.OrderId
                              

                                where OrderItem.OrderId == Order.Id
                                select new OrderListDto()
                               {
                                   OrderId = Order.Id,
                                    OrderItemId = OrderItem.Id,
                                   


                               }).ToListAsync();
            return orders;
        }

        public async Task<IEnumerable<OrderInformDto>> GetOrderInfromation(int userId)
        {
            List<Orders> order = await _context.Orders.Where(x => x.CustomerId == userId).ToListAsync();
            return _mapper.Map<OrderInformDto[]>(order);
        }

        public async Task<IEnumerable<OrderInfromProductDto>> GetOrderInformationProduct(int orderId)
        {
            var x = await (from orderItem in _context.OrderItem
                           join
                              product in _context.Product on
                              orderItem.ProductId equals product.Id
                           where orderItem.OrderId == orderId
                           select new OrderInfromProductDto()
                           {

                               ProductName = product.Name,
                               Price = product.Price

                           }).ToListAsync();
            return x;

        }

        public Task<bool> SaveAll()
        {
            throw new System.NotImplementedException();
        }

    }
}
