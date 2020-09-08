using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Common.OrderDto
{
    public class OrderDetailsDto
    {
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }


    }
}
