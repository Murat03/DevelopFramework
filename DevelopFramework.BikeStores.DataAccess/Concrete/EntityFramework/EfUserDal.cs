using DevelopFramework.BikeStores.DataAccess.Abstract;
using DevelopFramework.BikeStores.Entities.ComplexTypes;
using DevelopFramework.BikeStores.Entities.Concrete;
using DevelopFramework.Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopFramework.BikeStores.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, BikeStoresContext>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using(BikeStoresContext context = new BikeStoresContext())
            {
                var result = from ur in context.UserRoles
                             join r in context.Roles
                             on ur.UserID equals user.Id
                             where ur.UserID == user.Id
                             select new UserRoleItem { RoleName = r.Name };
                return result.ToList();
            }
        }
    }
}
