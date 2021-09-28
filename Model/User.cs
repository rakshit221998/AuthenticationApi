using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationApi.Model
{
    public class User
    {
        public string UserName { set; get; }

        public string Password { set; get; }

        public string Token { set; get; }
    }
}
