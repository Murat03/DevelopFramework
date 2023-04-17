using DevelopFramework.BikeStores.Entities.Concrete;
using DevelopFramework.BikeStores.MvcWebUI.Models;
using DevelopFramewrok.BikeStores.Business.Abstract;
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
                list_price = 15,
                brand_id = 1
            });
            return "Added";
        }
    }
}