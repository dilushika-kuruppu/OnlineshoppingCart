using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShopping.Common.PaymentDto
{
    public class PaymentDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int Date { get; set; }

        [Required]
        public string PaymentType { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Total { get; set; }


    }
}
