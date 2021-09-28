using AuthorizationApi.Model;
using AuthorizationApi.Repository.IRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationApi.Repository
{
    public class AuthRepository : IAuthRepository
    {
       
        private readonly IConfiguration configuration;
        private static List<User> List = new List<User>()
        {
            new User{ UserName = "user1", Password = "user1"},
            new User{ UserName = "user2", Password = "user2"}
        };

        public AuthRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public User Login(User user)
        {
            var response = String.Empty;
            var userobj = Authenticate(user);
            if (userobj != null)
            {
                var tokenString = GenerateJSONWebToken(userobj.UserName);
                User user1 = new User()
                {
                    UserName = userobj.UserName,
                    Password = userobj.Password,
                    Token = tokenString

                };
                return user1;
            }
            return null;

        }
        public User Authenticate(User user)
        {
            User obj = List.Where(x => x.UserName == user.UserName && x.Password == user.Password).Select(x => new User()
            {
                UserName = x.UserName,
                Password = x.Password
            }).FirstOrDefault();
            
            return obj;

        }

        private string GenerateJSONWebToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,username),
              

            };
            var token = new JwtSecurityToken(

               issuer: configuration["Jwt:Issuer"],
               audience: configuration["JWT:ValidAudience"],
               claims: claims,
               expires: DateTime.Now.AddMinutes(120),
               signingCredentials: credentials
               );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
