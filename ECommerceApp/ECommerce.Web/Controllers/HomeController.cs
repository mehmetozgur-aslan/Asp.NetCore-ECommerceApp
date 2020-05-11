using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Business.Abstract;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll(),
                Categories=_categoryService.GetAll()
            });
        }
    }
}