using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingDB.Server.Dtos
{
    public class UserForCustomerDto
    {
   
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address1 { get; set; }
        [Required]
        public string Address2 { get; set; }
        [Required]
        public string Email { get; set; }
       
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage ="You Must specify Password Between 4 to 8 Chatacters")]
        public string Password { get; set; }

        [Required]
        public string FullName => FirstName + " " + LastName;

 
    }
}
