using DevelopFramework.BikeStores.DataAccess.Concrete.EntityFramework;
using DevelopFramework.BikeStores.DataAccess.Concrete.NHibernate;
using DevelopFramework.BikeStores.DataAccess.Concrete.NHibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevelopFramework.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetList();

            Assert.AreEqual(322, result.Count);
        }
        public void Get_all_with_parameter_returns_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());

            var result = productDal.GetList(p => p.product_name.Contains("as"));

            Assert.AreEqual(8, result.Count);
        }
    }
}
