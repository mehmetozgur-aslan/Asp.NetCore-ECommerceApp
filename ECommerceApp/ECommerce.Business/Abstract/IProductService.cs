using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetPopularProducts();
        Product GetById(int id);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Product GetProductDetails(int id);
    }
}
