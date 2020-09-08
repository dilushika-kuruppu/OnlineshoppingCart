
using OnlineShoppingDB.Server.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace OnlineShopping.Data.Context
{
    public interface IAuthRepository
    {
        Task<UserForCustomerDto> Customer(UserForCustomerDto user, string password);
        Task<UserForLoginDto> Login(string username, string password);

        Task<bool> UserExists(string username, int id);
        //Task Customer(OnlineShoppingDB.Server.Models.Login userToCreate, string password);
    }
}
