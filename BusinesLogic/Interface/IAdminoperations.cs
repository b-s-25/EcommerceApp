﻿using DomainLayer.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Interface
{
    public interface IAdminoperations
    {

        //IEnumerable<Registration> GetUserData();
        //void Add(Registration entity);
        //Registration Authenticate(string username, string password);
        Task<IdentityResult> Register(Registration register);



    }
}

