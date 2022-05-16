using APILayer.Models;
using BusinesLogic;
using BusinesLogic.Interface;
using DomainLayer;
using DomainLayer.DTO;
using DomainLayer.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace APILayer.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminoperations _userOperations;
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AdminController(IAdminoperations userOperations, ILogger<UserController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            _userOperations = userOperations;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        ////private readonly ProductDbContext _Context;
        //private readonly IAdminoperations _adminoperations;
        //public AdminController(ILogger<AdminController> logger, IAdminoperations adminoperations)
        //{
        //    _logger = logger;

        //    _adminoperations = adminoperations;
        //}


        //[HttpPost("Login")]
        //public HttpResponseMessage Login([FromBody] LoginView login)
        //{
        //    try
        //    {
        //        var result = _adminoperations.Authenticate(login.username, login.password);
        //        if (result.roleId == 2)
        //        {
        //            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        //        }
        //        return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Error In Post", ex);
        //        return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
        //    }

        //}

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] Registration register)
        {
            try
            {
                var result = await _userOperations.Register(register);
                if (result.Succeeded)
                {
                    return Ok(new UserResponse<string> { status = "Success", message = "User registration is successfully completed" });
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
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
        }

    }
}
