using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.Entities.ComplexTypes
{
    public class ProductDetail
    {
        public virtual int product_id { get; set; }
        public virtual string product_name { get; set; }  
        public virtual string category_name { get; set; }

    }
}
