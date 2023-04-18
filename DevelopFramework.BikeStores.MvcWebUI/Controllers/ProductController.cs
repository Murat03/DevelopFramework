using DevelopFramework.BikeStores.Entities.Concrete;
using DevelopFramework.BikeStores.MvcWebUI.Models;
using DevelopFramework.BikeStores.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevelopFramework.BikeStores.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }
        public string Add()
        {
            _productService.Add(new Product 
            { 
                category_id = 1,
                product_name = "Test",
                model_year = 1990,
                list_price = 25,
                brand_id = 1
            });
            return "Added";
        }
        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
            {
                category_id = 1,
                product_name = "Test 2",
                model_year = 1990,
                list_price = 250,
                brand_id = 5
            },new Product
            {
                product_id = 4322,
                category_id = 1,
                product_name = "Test 3",
                model_year = 1990,
                list_price = 500,
                brand_id = 4
            });
            return "Done!";
        }
    }
}