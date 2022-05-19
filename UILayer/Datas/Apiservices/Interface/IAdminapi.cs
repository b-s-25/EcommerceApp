using DomainLayer.DTO;
using DomainLayer.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.Datas.Apiservices.Interface
{
   public  interface IAdminapi
    {
        IEnumerable<Registration> GetUserInfo();
        bool AdminLogin(LoginView AdminLogin);

    }
}
