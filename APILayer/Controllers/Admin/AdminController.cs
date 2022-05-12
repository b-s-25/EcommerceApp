using BusinesLogic;
using BusinesLogic.Interface;
using DomainLayer.DTO;
using DomainLayer.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

namespace APILayer.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        //private readonly ProductDbContext _Context;
        private readonly IAdminoperations _adminoperations;
        public AdminController(ILogger<AdminController> logger, IAdminoperations adminoperations)
        {
            _logger = logger;

            _adminoperations = adminoperations;
        }


        [HttpPost("Login")]
        public HttpResponseMessage Login([FromBody] LoginView login)
        {
            try
            {
                var result = _adminoperations.Authenticate(login.username, login.password);
                if (result.roleId == 2)
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                }
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error In Post", ex);
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

        }
    }
}
