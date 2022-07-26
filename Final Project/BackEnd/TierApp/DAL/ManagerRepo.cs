using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ManagerRepo
    {
        static RMSFEntities db;

        static ManagerRepo()
        {
            db = new RMSFEntities();
        }

        public static void Edit(ManagersDetail pd)
        {
            var chid = pd.Id;
            var check = (from s in db.ManagersDetails
                         where s.Id == chid
                         select s).FirstOrDefault();
            ManagersDetail md = new ManagersDetail()
            {
                Id = pd.Id,
                ManagerName = pd.ManagerName,
                Phone = pd.Phone,
                Address = pd.Address,
                UserId = check.UserId,
                Salary = check.Salary
            };
            db.Entry(check).CurrentValues.SetValues(md);
            db.Entry(check).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public static ManagersDetail GetInfo()
        {
            return db.ManagersDetails.First();
        }
    }
}
