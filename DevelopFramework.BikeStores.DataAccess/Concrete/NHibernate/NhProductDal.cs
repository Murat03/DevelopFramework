using DevelopFramework.BikeStores.DataAccess.Abstract;
using DevelopFramework.BikeStores.Entities.ComplexTypes;
using DevelopFramework.BikeStores.Entities.Concrete;
using DevelopFramework.Core.DataAccess.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        private NHibernateHelper _nHibernateHelper;
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<ProductDetail> GetProductDetails()
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>() on p.category_id equals c.category_id
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
