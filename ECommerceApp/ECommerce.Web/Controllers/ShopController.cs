using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ECommerce.Business.Abstract;
using ECommerce.Entities;
using ECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _productService.GetProductDetails(id.GetValueOrDefault());

            if (product == null)
            {
                return NotFound();
            }

            return View(new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(x => x.Category).ToList()
            });
        }

        //products/telefon?page=2
        public IActionResult List(string category, int page = 1)
        {
            const int pageSize = 3;


            return View(new ProductListModel()
            {
                PageInfo = new PageInfo
                {
                    TotalItems=_productService.GetCountByCategory(category),
                    CurrentCategory = category,
                    CurrentPage = page,
                    ItemsPerPage = pageSize
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize)
            });
        }
    }
}