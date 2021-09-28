using AuthorizationApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationApi.Repository.IRepository
{
    public interface IAuthRepository
    {
        User Login(User user);
    }
}
