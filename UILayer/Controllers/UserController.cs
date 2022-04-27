using DomainLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UILayer.Datas.Apiservices;

namespace UILayer.Controllers
{
    public class UserController : Controller
    {
        private UserApi _userApi;
        private IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _userApi = new UserApi(_configuration);
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserRegister(RegistrationView registrationView)
        {
            _userApi.UserRegister(registrationView);
            return View("Index");
        }
    }
}
