using System;
using System.Collections.Generic;

namespace OnlineShopping.API.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? PaymentId { get; set; }
        public DateTime? Date { get; set; }
        public string Total { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
