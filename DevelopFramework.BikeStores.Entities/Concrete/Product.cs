using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevelopFramework.Core.Entities;

namespace DevelopFramework.BikeStores.Entities.Concrete
{
    public class Product : IEntity
    {
        public virtual int product_id { get; set; }
        public virtual string product_name { get; set; }
        public virtual int category_id { get; set; }
        public virtual int brand_id { get; set; }
        public virtual Int16 model_year { get; set; }
        public virtual decimal list_price { get; set; }
    }
}