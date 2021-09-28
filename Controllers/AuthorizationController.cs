using AuthorizationApi.Model;
using AuthorizationApi.Repository.IRepository;
using AuthorizationApi.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthorizationController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            User user1 = authService.LoginService(user);

            if (user1==null)
                return Unauthorized(new { message = "Not Authorized" });

            user1.Password = "";
            return Ok(user1);
        }
    }
}
