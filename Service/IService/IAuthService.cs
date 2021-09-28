using AuthorizationApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationApi.Service.IService
{
    public interface IAuthService
    {
        User LoginService(User user);
    }
}
