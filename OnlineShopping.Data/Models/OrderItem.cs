using System;
using System.Collections.Generic;

namespace OnlineShopping.Data.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public string ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
