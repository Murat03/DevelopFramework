using DevelopFramework.BikeStores.DataAccess.Abstract;
using DevelopFramework.BikeStores.Entities.Concrete;
using DevelopFramework.Core.DataAccess.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.DataAccess.Concrete.NHibernate
{
    public class NhCategoryDal : NhEntityRepositoryBase<Category>, ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
