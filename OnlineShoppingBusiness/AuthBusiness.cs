using Microsoft.IdentityModel.Tokens;
using OnlineShopping.Data.Context;
using OnlineShoppingDB.Server.Dtos;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Business
{
    public class AuthBusiness : IAuthBusiness
    {
        private readonly IAuthRepository _authRepository;


        public AuthBusiness(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task<UserForCustomerDto> Customer(UserForCustomerDto userToCreate, string password)
        {
            throw new NotImplementedException();
        }

        public  async Task<UserForLoginDto> Login(string username, string password , string token)
        {
            var user = await _authRepository.Login(username, password);
                      

            if (user == null)
                return null;

            
            var claims = new[]
            {
                
           new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name,username)

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.ToCharArray()));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            UserForLoginDto userjwt = new UserForLoginDto();
            SecurityToken tokenx = tokenHandler.CreateToken(tokenDescriptor);
            string a = tokenHandler.WriteToken(tokenx);
            userjwt.JWTToken = a;


         return userjwt;
        }

        public Task<bool> UserExists(string username)
        {
            throw new NotImplementedException();
        }
    }
}
