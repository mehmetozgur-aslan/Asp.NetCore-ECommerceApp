﻿using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Create(Product entity)
        {
            _productDal.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll().ToList();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productDal.GetByIdWithCategories(id);
        }

        public int GetCountByCategory(string category)
        {
            return _productDal.GetCountByCategory(category);
        }

        public Product GetProductDetails(int id)
        {
            return _productDal.GetProductDetails(id);
        }

        public List<Product> GetProductsByCategory(string category,int page,int pageSize)
        {
            return _productDal.GetProductsByCategory(category,page, pageSize);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }

        public void Update(Product entity, int[] categoryIds)
        {
            _productDal.Update(entity, categoryIds);
        }
    }
}
