using DocumentFormat.OpenXml.Spreadsheet;
using DomainLayer.DTO;
using DomainLayer.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UILayer.Datas.Apiservices;
namespace UILayer.Datas.Authentication
{
    public class CookiesAuth
    {
        private UserApi _userApi;
        private IConfiguration _configuration;
        private Registration _registration;
        public CookiesAuth(IConfiguration configuration)
        {
            _userApi = new UserApi(_configuration);
            _configuration = configuration;
        }

        public void Authenticate() 
        {
        
        }
    }
}
