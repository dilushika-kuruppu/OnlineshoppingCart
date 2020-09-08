using OnlineShopping.Common;
using OnlineShoppingDB.Server.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShopping.Common.OrderDto
{
   public  class OrderDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int PaymentID { get; set; }
        [Required]
        public int Date { get; set; }
       
        [Required]
        public string Address { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Total { get; set; }

        public List<OrderItemDto> OrderItemDto { get; set; }
    }
}
