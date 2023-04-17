using DevelopFramework.BikeStores.DataAccess.Abstract;
using DevelopFramework.BikeStores.Entities.ComplexTypes;
using DevelopFramework.BikeStores.Entities.Concrete;
using DevelopFramework.Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, BikeStoresContext>, IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            using (BikeStoresContext context = new BikeStoresContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.category_id equals c.category_id
                             select new ProductDetail
                             {
                                 product_id = p.product_id,
                                 product_name = p.product_name,
                                 category_name = c.category_name
                             };
                return result.ToList();
            }
        }
    }
}
