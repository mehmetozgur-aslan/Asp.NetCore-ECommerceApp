﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Entities
{
    //Junction Table
    public class ProductCategory
    {      
        public int CategoryId { get; set; }
        public Category Category { get; set; } // Navigation Property
        public int ProductId { get; set; }
        public Product Product { get; set; } // Navigation Property
    }
}
