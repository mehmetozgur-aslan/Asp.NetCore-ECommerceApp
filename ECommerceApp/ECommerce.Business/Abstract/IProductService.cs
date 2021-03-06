﻿using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Business.Abstract
{
    public interface IProductService:IValidator<Product>
    {
        List<Product> GetAll();
        List<Product> GetProductsByCategory(string category, int page, int pageSize);
        Product GetById(int id);
        bool Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Product GetProductDetails(int id);
        int GetCountByCategory(string category);
        Product GetByIdWithCategories(int id);
        void Update(Product entity, int[] categoryIds);
    }
}
