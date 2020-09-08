using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingDB.Server.Dtos
{
    public class UserForLoginDto
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You Must specify Password Between 4 to 8 Chatacters")]
        public string Password { get; set; }

        public string JWTToken { get; set; }
    }
}
