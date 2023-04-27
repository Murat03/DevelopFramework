using DevelopFramework.BikeStores.DataAccess.Abstract;
using DevelopFramework.BikeStores.DataAccess.Concrete.EntityFramework;
using DevelopFramework.BikeStores.DataAccess.Concrete.NHibernate.Helpers;
using DevelopFramework.Core.DataAccess;
using DevelopFramework.Core.DataAccess.EntityFramework;
using DevelopFramework.Core.DataAccess.NHibernate;
using DevelopFramework.BikeStores.Business.Abstract;
using DevelopFramework.BikeStores.Business.Concrete.Managers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<EfUserDal>();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<BikeStoresContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
