using DevelopFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.Entities.Concrete
{
    [Table("production.categories")]
    public class Category:IEntity
    {
        [Key]
        public virtual int category_id { get; set; }
        public virtual string category_name { get; set; }
    }
}
