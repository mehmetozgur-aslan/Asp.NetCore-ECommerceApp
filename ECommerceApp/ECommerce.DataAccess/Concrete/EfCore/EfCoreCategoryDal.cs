using ECommerce.DataAccess.Abstract;
using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;

namespace ECommerce.DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryDal :EfCoreGenericRepository<Category,ECommerceContext>, ICategoryDal
    {
       
    }
}
