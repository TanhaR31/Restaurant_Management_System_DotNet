using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SalaryRepo
    {
        static RMSFEntities db;

        static SalaryRepo()
        {
            db = new RMSFEntities();
        }

        public static List<Salary> GetSalary()
        {
            return db.Salaries.ToList();
        }

        public static void GiveSalary(Salary sl)
        {
            var prod = sl.DeliverymanId;
            var uprice = (from s in db.DeliverymansDetails
                          where s.Id == prod
                          select s.Salary).FirstOrDefault();

            Salary d = new Salary()
            {
                DeliverymanId = sl.DeliverymanId,
                Bonus = sl.Bonus,
                SalPaid = uprice + sl.Bonus,
                SalDate = DateTime.Now
            };
            db.Salaries.Add(d);
            db.SaveChanges();
        }
    }
}
