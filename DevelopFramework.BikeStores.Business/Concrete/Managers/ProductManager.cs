using DevelopFramework.BikeStores.DataAccess.Abstract;
using DevelopFramework.BikeStores.Entities.Concrete;
using DevelopFramework.Core.Aspects.PostSharp;
using DevelopFramework.Core.Aspects.PostSharp.CacheAspects;
using DevelopFramework.Core.Aspects.PostSharp.LogAspects;
using DevelopFramework.Core.Aspects.PostSharp.TransactionAspects;
using DevelopFramework.Core.Aspects.PostSharp.ValidationAspects;
using DevelopFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevelopFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevelopFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevelopFramework.Core.DataAccess;
using DevelopFramework.BikeStores.Business.Abstract;
using DevelopFramework.BikeStores.Business.ValidationRules.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Diagnostics;
using DevelopFramework.Core.Aspects.PostSharp.PerformanceAspects;
using System.Threading;

namespace DevelopFramework.BikeStores.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p=>p.product_id == id);
        }
        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }
        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidatior))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                    _productDal.Add(product1);
                    //Business Codes
                    _productDal.Update(product2);
            }
            
        }
    }
}
