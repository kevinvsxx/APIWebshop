using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PR5webshopAPI.Data;
using PR5webshopAPI.Helpers;
using PR5webshopAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PR5webshopAPI.Services
{
    public interface IUserService
    {
        User Authenticate(int userid, string username, string password);
    }
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public User Authenticate(int userid, string username, string password)
        {
            //else return null;
            var user = new User() { Username = username, Password = password };

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }
    }
}
