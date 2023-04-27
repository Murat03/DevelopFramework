using DevelopFramework.BikeStores.DataAccess.Concrete.EntityFramework.Mappings;
using DevelopFramework.BikeStores.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.DataAccess.Concrete.EntityFramework
{
    public class BikeStoresContext:DbContext
    {
        public BikeStoresContext()
        {
            Database.SetInitializer<BikeStoresContext>(null);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("production");
            modelBuilder.Configurations.Add(new ProductMap()); 
            modelBuilder.Configurations.Add(new UserMap()); 
        }
    }
}
