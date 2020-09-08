using System;
using System.Collections.Generic;

namespace OnlineShopping.API.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Login = new HashSet<Login>();
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Fristname { get; set; }
        public string Lastname { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public virtual ICollection<Login> Login { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
