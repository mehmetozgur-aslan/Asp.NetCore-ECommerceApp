using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccess.Concrete.EfCore
{
    public class ECommerceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ECommerce;IntegratedSecurity=true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
