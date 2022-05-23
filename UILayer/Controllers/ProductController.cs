using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using DomainLayer;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RepositoryLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UILayer.Datas.Apiservices;
using UILayer.Controllers;

namespace UILayer.Controllers
{
    public class ProductController : Controller
    {
        Product Data = null;
        ProductView Storage = null;
        private IWebHostEnvironment _webHostEnvironment;

        public ProductController(IWebHostEnvironment hostEnvironment)
        {
            Data = new Product();

            _webHostEnvironment = hostEnvironment;
        }


        public IActionResult Index()
        {
            IEnumerable<Product> products = PoductApi.index();
            return View(products);
        }
        


        public IActionResult Details(int id)
        {
            Product products = PoductApi.GetById(id);
            return View(products);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Storage = new ProductView();
            Product product = PoductApi.GetById(id);
            /*Storage.productType = product.productType;*/
            Storage.productName = product.productName;
            Storage.productPrice = product.productPrice;
            Storage.productModel = product.productModel;
            /*Storage.image = Data.image;*/
            Storage.description = product.description;
            return View("Create", Storage);
        }
       
        public ActionResult Delete(int id)
        {
            bool result = PoductApi.Delete(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
           
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductView product)
        {
            if (product.id == 0)
            {
                string stringFileName = UploadFile(product);
                var Product = new Product
                {
                   /* productType = product.productType,*/
                    productName = product.productName,
                    productPrice = product.productPrice,
                    productModel = product.productModel,
                    image = stringFileName,
                    description = product.description
                };

                bool result = PoductApi.Create(Product);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                return Content("Failed");
            }
            else
            {
                string stringFileName = UploadFile(product);
                var Product = new Product
                {
                    id = product.id,
                    /*productType = product.productType,*/
                    productName = product.productName,
                    productPrice = product.productPrice,
                    productModel = product.productModel,
                    image = stringFileName,
                    description = product.description
                };
                bool result = PoductApi.Edit(Product);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                return Content("Failed");
            }
        }

        private string UploadFile(ProductView product)
        {
            string fileName = null;
            if (product.image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + product.image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    product.image.CopyTo(fileStream);
                }
            }

            return fileName;
        }
        public IEnumerable<Product> GetList()
        {
            IEnumerable<Product> products = PoductApi.index();
            return products;
        }
    }
}
