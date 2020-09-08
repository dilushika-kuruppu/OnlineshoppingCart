using AutoMapper;
using OnlineShopping.Business.Email;
using OnlineShopping.Common;
using OnlineShopping.Common.CommonDto;
using OnlineShopping.Common.OrderDto;
using OnlineShopping.Common.PaymentDto;
using OnlineShopping.Data.Models;
using OnlineShopping.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Business.Order
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IEmail _email;



        /// <summary>Initializes a new instance of the <see cref="OrderManager" /> class.</summary>
        /// <param name="orderRepository">The order repository.</param>
        /// <param name="orderItemRepository">The order product repository.</param>
        /// <param name="mapper">The mapper.</param>
        public OrderManager(IUnitofWork unitofWork, IEmail email)
        {
            _unitofWork = unitofWork;
            _email = email;
        }



        public async Task<Orders> CreateOrderAsync(OrderDto orderDto)
        {
            try
            {
                await _unitofWork.OrderRepository.CreateOrderAsync(orderDto);
                _unitofWork.Commit();
                sendMail(orderDto);
                return null;

            }
            catch (Exception e)
            {
                _unitofWork.Rollback();
                return null;
            }
        }



        private void sendMail(OrderDto orderDto)
        {
            string emailbody;

            emailbody = "<br><br><table border='1'>" +
            "<tr>" +
             "<th>UserName</th>" +
             "<th>Address</th>" +
             "<th>Diate</th>" +
             "<th>Total</th>" +
            "</tr>" +
            "<tr>" +
             "<td>" + orderDto.UserName + "</td>" +
             "<td>" + orderDto.Address + "</td>" +
             "<td>" + orderDto.Date + "</td>" +
             "<td>" + orderDto.Total + "</td>" +
            "</tr>" +
            "</table><br><br>" + "Item Purchase";

            List<OrderItemDto> orderItemDto = orderDto.OrderItemDto;

            for (int i = 0; i < orderItemDto.Count; i++)
            {
#pragma warning disable S1643 // Strings should not be concatenated using '+' in a loop
                emailbody += "<table>" +
                                            "<tr>" +
                                            "<td>" + "Name: " + orderItemDto[i].Name + "</td>" +
                                            "<td>" + " Price: " + orderItemDto[i].ProductPrice + "</td>" +
                                            "</tr>" +
                                            "</table>";
#pragma warning restore S1643 // Strings should not be concatenated using '+' in a loop
            }

            _email.Send(orderDto.Email, "Home Shop - Bill", emailbody);

        }

        public async Task<OrderDetailsDto> GetOrder(int userId)
        {
            return await _unitofWork.OrderItemRepository.GetOrder(userId);

        }
        public async Task<IEnumerable<OrderListDto>> GetOrders()
        {
            return await _unitofWork.OrderRepository.GetOrders();

        }

        /// <summary>Adds the order.</summary>
        /// <param name="commonDto">The common dto.</param>
        /// <returns></returns>


        /// <summary>Deletes the order.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteOrder(int id)
        {
            OrderItemDto orderItem = await _unitofWork.OrderItemRepository.GetOrderItem(id);

            if (orderItem == null)
                return false;

            _unitofWork.OrderItemRepository.Delete(orderItem);
            return await _unitofWork.OrderItemRepository.SaveAll();
        }

        /// <summary>Gets the order.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>

        public async Task<IEnumerable<OrderInfromProductDto>> GetOrderInformationProduct(int orderId)
        {
            return await _unitofWork.OrderRepository.GetOrderInformationProduct(orderId);
        }

        public async Task<IEnumerable<OrderInformDto>> GetOrderInfromation(int userId)
        {
            return await _unitofWork.OrderRepository.GetOrderInfromation(userId);

        }


    }
}

