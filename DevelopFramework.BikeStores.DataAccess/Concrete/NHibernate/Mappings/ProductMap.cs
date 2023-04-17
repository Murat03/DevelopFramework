using DevelopFramework.BikeStores.Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.DataAccess.Concrete.NHibernate.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"production.products");
            LazyLoad();
            Id(x => x.product_id).Column("product_id");
            
            Map(x => x.product_name).Column("product_name");
            Map(x => x.category_id).Column("category_id");
            Map(x => x.brand_id).Column("brand_id");
            Map(x => x.model_year).Column("model_year");
            Map(x => x.list_price).Column("list_price");
        }
    }
}
