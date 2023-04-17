using DevelopFramework.BikeStores.DataAccess.Abstract;
using DevelopFramework.BikeStores.Entities.Concrete;
using DevelopFramewrok.BikeStores.Business.Concrete.Managers;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace DevelopFramework.BikeStores.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            productManager.Add(new Product());
        }
    }
}
