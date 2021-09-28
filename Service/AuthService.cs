using AuthorizationApi.Model;
using AuthorizationApi.Repository.IRepository;
using AuthorizationApi.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationApi.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }
        public User LoginService(User user)
        {
            User user1 = authRepository.Login(user);
            return user1;
        }
    }
}
