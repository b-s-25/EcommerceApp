using APILayer.Models;
using BusinesLogic.Interface;
using DomainLayer;
using DomainLayer.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserOperations _userOperations;
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserController(IUserOperations userOperations, ILogger<UserController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userOperations = userOperations;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] Registration register)
        {
            try 
            {
                var result = await _userOperations.Register(register);
                if (result.Succeeded)
                {
                    return Ok(new UserResponse<string> { status = "Success", message = "User registration is successfully completed"}) ;
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new UserResponse<string> { status = "Error", message = "User registration failed, please try again" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("error");
                _logger.LogError("error");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] Login login)
        {
            try
            {
                var result = await _userOperations.Userlogin(login);
                if (string.IsNullOrEmpty(result))
                {
                    return StatusCode(StatusCodes.Status401Unauthorized, new UserResponse<string> { status = "Error", message = "Login failed, please try again. If not registered, please Register to order your product" });
                }
                else
                {
                    return Ok(new UserResponse<string> { status = "Success", message = "Login Successfull" ,token = result });
                }
            }
            catch (Exception ex) 
            {
                _logger.LogInformation("error");
                _logger.LogError("error");
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        [HttpGet("GetUser")]
        public  IEnumerable<ApplicationUser> GetUser()
        {
            return _userOperations.GetUser().Result;
        }
    }
}
