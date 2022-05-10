using BusinesLogic;
using BusinesLogic.Interface;
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
        private readonly IAdminoperations _AdminCatalog;
        public AdminController(ILogger<AdminController> logger, IAdminoperations AdminCatalog)
        {
            _logger = logger;

            _AdminCatalog = AdminCatalog;
        }
       

        [HttpGet]
        public IEnumerable<Registration> GetAll()
        {

            try
            {
                var products = _AdminCatalog.GetUserData();

                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error message");
                return null;


            }
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Registration registration)
        {
            try
            {
                _AdminCatalog.Add(registration);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error In Post", ex);
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

        }
    }
}
