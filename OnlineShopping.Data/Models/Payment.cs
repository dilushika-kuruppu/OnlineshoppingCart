using System;
using System.Collections.Generic;

namespace OnlineShopping.Data.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string Amount { get; set; }
        public DateTime? Date { get; set; }
        public string PaymentType { get; set; }

        public virtual Orders Order { get; set; }
    }
}
