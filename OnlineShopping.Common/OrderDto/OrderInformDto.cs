using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Common.OrderDto
{
    public class OrderInformDto
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
        public string Address { get; set; }
        public bool Expanded { get; set; } = false;
    }
}
