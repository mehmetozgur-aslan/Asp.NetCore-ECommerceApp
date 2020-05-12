﻿using System;
using System.Collections.Generic;
using System.Linq;
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

            Product product = _productService.GetById(id.GetValueOrDefault());

            if (product==null)
            {
                return NotFound();
            }


            return View(product);
        }

        public IActionResult List()
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()
            });
        }
    }
}