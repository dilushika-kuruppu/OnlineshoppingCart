
using OnlineShoppingDB.Server.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Business
{
    public interface IAuthBusiness
    {
        Task<UserForLoginDto> Login(string username, string password, string token);
        Task<UserForCustomerDto> Customer(UserForCustomerDto userToCreate, string password);
        Task<bool> UserExists(string username);
    }
}
