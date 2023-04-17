using DevelopFramework.BikeStores.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products", @"production");
            HasKey(x => x.product_id);

            Property(x=> x.product_id).HasColumnName("product_id");
            Property(x=> x.product_name).HasColumnName("product_name");
            Property(x=> x.category_id).HasColumnName("category_id");
            Property(x=> x.brand_id).HasColumnName("brand_id");
            Property(x=> x.model_year).HasColumnName("model_year");
            Property(x=> x.list_price).HasColumnName("list_price");

        }
    }
}
