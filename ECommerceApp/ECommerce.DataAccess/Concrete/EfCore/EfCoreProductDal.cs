using ECommerce.DataAccess.Abstract;
using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.DataAccess.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreGenericRepository<Product, ECommerceContext>, IProductDal
    {
        public Product GetProductDetails(int id)
        {
            using (var context = new ECommerceContext())
            {
                return context.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category).FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            using (var context = new ECommerceContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(i => i.Category.Name.ToLower() == category.ToLower()));
                }

                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new ECommerceContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.ProductCategories.Any(i => i.Category.Name.ToLower() == category.ToLower()));
                }

                return products.Count();
            }
        }

        public Product GetByIdWithCategories(int id)
        {
            using (var context = new ECommerceContext())
            {
                return context.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category).FirstOrDefault();
            }
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context = new ECommerceContext())
            {
                var product = context.Products
                    .Include(i => i.ProductCategories)
                    .FirstOrDefault(i => i.Id == entity.Id);

                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Description = entity.Description;
                    product.ImageUrl = entity.ImageUrl;
                    product.Price = entity.Price;

                    //TODO: Hata olabilir.
                    product.ProductCategories = categoryIds.Select(catId => new ProductCategory()
                    {
                        CategoryId = catId,
                        ProductId = product.Id
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }
    }
}
