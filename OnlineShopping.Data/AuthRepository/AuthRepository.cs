using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data.Models;
using OnlineShoppingDB.Server.Dtos;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace OnlineShopping.Data.Context
{
    public class AuthRepository : IAuthRepository

    {
        private readonly OnlineShoppingContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(OnlineShoppingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserForCustomerDto> Customer(UserForCustomerDto user, string password)
        {
            Customer customer = new Customer();
            customer.Lastname = user.UserName;

            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();

            return user;
            
        }

        public async Task<UserForLoginDto> Login(string username, string password)
        {
            var user = await _context.Login.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
            if (user == null)
            {
                return null;
            }
            return
             new UserForLoginDto
             {
                 Id= user.Id,
                 
             };
        }

        public async Task<bool> UserExists(string username, int id)
        {
            if (await _context.Login.AnyAsync(x => x.Id == id))
            return true;

            return false;
        }
    }
}

