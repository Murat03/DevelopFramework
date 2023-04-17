using DevelopFramework.BikeStores.Entities.ComplexTypes;
using DevelopFramework.BikeStores.Entities.Concrete;
using DevelopFramework.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
    }
}
