using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Business.Order;
using OnlineShopping.Common.CommonDto;
using OnlineShopping.Common.OrderDto;
using OnlineShopping.Data.Models;


namespace OnlineShopping.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

            private readonly IOrderManager _orderManager;

        public OrdersController( IOrderManager orderManager)
        {
            
            _orderManager = orderManager;
        }
        /// <summary>Posts the order.</summary>
        /// <param name="commonDto">The common dto.</param>
        /// <returns></returns>

        [HttpPost]
        public async Task<ActionResult<Orders>> CreateOrderAsync(OrderDto orderDto)
        {

            var order = await _orderManager.CreateOrderAsync(orderDto);
            return Ok(order);

        }
        /// <summary>Gets the order.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var getorderdetails = await _orderManager.GetOrder(id);
            return Ok(getorderdetails);
        }


        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var getorderlist = await _orderManager.GetOrders();
            return Ok(getorderlist);
        }



        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
          await _orderManager.DeleteOrder(id);
           return Ok();
        }
        [HttpGet("orderinformation/{id}")]
        public async Task<IActionResult> OrderInformation(int id)
        {
            return Ok(await _orderManager.GetOrderInfromation(id));
        }

        [HttpGet("orderinformationproduct/{id}")]
        public async Task<IActionResult> OrderInformationProducts(int id)
        {
            return Ok(await _orderManager.GetOrderInformationProduct(id));
        }

    }
}
