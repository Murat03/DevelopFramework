using DevelopFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.Entities.Concrete
{
    public class UserRole:IEntity
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int RoleId { get; set; }
    }
}
