using DevelopFramework.BikeStores.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Products", @"production");
            HasKey(x => x.category_id);

            Property(x => x.category_id).HasColumnName("category_id");
            Property(x => x.category_name).HasColumnName("category_name");
        }
    }
}
