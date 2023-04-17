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
using DevelopFramewrok.BikeStores.Business.Abstract;
using DevelopFramewrok.BikeStores.Business.ValidationRules.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DevelopFramewrok.BikeStores.Business.Concrete.Managers
{
    [LogAspect(typeof(FileLogger))]
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(DatabaseLogger))]
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
