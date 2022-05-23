using APILayer.Models;
using BusinesLogic;
using BusinesLogic.Interface;
using DomainLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCatagoryController : ControllerBase
    {
        
            private readonly ILogger<ProductCatagoryController> _logger;
            ProductDbContext _Context;
            IProductCatagory _Catalog;


            public ProductCatagoryController(ProductDbContext Context, ILogger<ProductCatagoryController> logger)
            {
                _logger = logger;
                _Context = Context;
                _Catalog = new ProductCatagory(_Context);

            }
            [HttpGet("Index")]
            public IEnumerable<Product> Index()
            {
                try
                {
                    var products = _Catalog.index();
                    return products;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error message");
                return null;
                }
            }


        [HttpGet("Details")]
            public IActionResult Details(int id)
            {
                try
                {
                    var data = _Catalog.Details(id);
                return Ok(data);
                }
                catch(Exception ex)
                {
                    _logger.LogError("Error In Post", ex);
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }


            [HttpPost("ProductPost")]
            public async Task<IActionResult> ProductPost([FromBody] Product product)
            {
                try
                {
                _Catalog.Create(product);
                    return Ok("success");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error In Post", ex);
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            [HttpPut("ProductPut")]
            public  IActionResult ProductPut([FromBody] Product product)
            {
                try
                {
                _Catalog.Update(product);
                    return StatusCode(StatusCodes.Status200OK);

                }
                catch (Exception ex)
                {
                    _logger.LogError("Error In Put", ex);
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }

        [HttpDelete("ProductDelete/{id}")]
            public IActionResult ProductDelete(int id)
            {
                try
                {
                    Product product = new Product();
                    product = _Catalog.Details(id);
                    _Catalog.Delete(product);
                    return StatusCode(StatusCodes.Status200OK);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error In Put", ex);
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
    }
}
