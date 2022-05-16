using DocumentFormat.OpenXml.Spreadsheet;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UILayer.Datas.Apiservices;
using DomainLayer.Users;
using Microsoft.AspNetCore.Authorization;

namespace UILayer.Controllers
{
    public class UserController : Controller
    {
        private UserApi _userApi;
        private IConfiguration _configuration;
        private Registration _registration;
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
        //public IActionResult UserRegister(Registration registration)
        {
            _userApi.UserRegister(registrationView);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login(string loginUrl)
        {
            ViewData["LoginUrl"] = loginUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginView loginView)
        //public async Task<IActionResult> Login(Login loginView)
        {
            LoginView userLogin = new LoginView();
            //Login userLogin = new Login();
            _registration = _userApi.GetUserInfo().Where(register => register.email == loginView.username).FirstOrDefault();
            userLogin = loginView;
            bool check = _userApi.UserLogin(loginView);
            if (check)
            {
                var claims = new List<Claim>();

                claims.Add(new Claim("password", loginView.password));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, loginView.username));
                claims.Add(new Claim(ClaimTypes.Name, loginView.username));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index");
            }
            TempData["Error"] = "*Invalid Email or Password";
            return View("Login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult ForgetPassword(ForgetPasswordView forgetPasswordView)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            ModelState.Clear();
        //            var userDetails = _userApi.GetUserInfo().Where(check => check.email.Equals(forgetPasswordView.email)).FirstOrDefault();
        //            if (userDetails!=null)
        //            {
        //                forgetPasswordView.emailSent = true;
        //                return Redirect("/user/ResetPassword?email=" + forgetPasswordView.email);
        //            }
                   

        //        }
        //        return View(forgetPasswordView);
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

        //[HttpGet]
        //public ActionResult ResetPassword(string email)
        //{
        //    var userDetails = _userApi.GetUserInfo().Where(check => check.email.Equals(email)).FirstOrDefault();
        //    //ResetPassword reset = new ResetPassword();
        //    reset.user = userDetails;
        //    return View(reset);
        //}

        //[HttpPost]
        //public ActionResult ResetPassword(ResetPassword resetPassword)
        //{
        //    try
        //    {
        //        Registration register = new Registration();
        //        register = _userApi.GetUserInfo().Where(c => c.email.Equals(resetPassword.user.email)).FirstOrDefault();
        //        register.password = resetPassword.newPassword;
        //        var result = _userApi.EditUserInfo(register);
        //        return View(resetPassword);
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
    }
}
