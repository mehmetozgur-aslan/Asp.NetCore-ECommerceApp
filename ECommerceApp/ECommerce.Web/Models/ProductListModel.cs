﻿using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Models
{
    public class ProductListModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public PageInfo PageInfo { get; set; }

    }
}
