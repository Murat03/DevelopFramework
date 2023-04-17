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
    [Table("production.brands")]
    public class Brand : IEntity
    {
        [Key]
        public int brand_id { get; set; }
        public string brand_name { get; set; }
    }
}
