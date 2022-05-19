using DomainLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UILayer.Datas.Apiservices;

namespace UILayer.Controllers.Admin
{
    public class AdminController : Controller
    {
        private  Adminapi _adminapi;
        public AdminController()
        {
            _adminapi = new Adminapi();

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {           
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Userinfo(LoginView loginView)
        //{
        //    LoginView adminLogin = new LoginView();

        //    var data=_adminapi.GetUserInfo().Where(x=>x.email==loginView.username && x.password==loginView.password).FirstOrDefault();
        //    if (data != null)
        //    {
        //         return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Login");
        //    }
        //}

        [HttpPost]
        public IActionResult Login(LoginView loginView)
        {
            LoginView adminLogin = new LoginView();

            var result = _adminapi.AdminLogin(loginView);

            var data = _adminapi.GetUserInfo().Where(x => x.email == loginView.username && x.password == loginView.password).FirstOrDefault();
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }

}

