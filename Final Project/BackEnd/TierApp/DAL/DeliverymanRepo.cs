using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DeliverymanRepo : IRepository<DeliverymansDetail, int>
    {
        RMSFEntities db;
        public DeliverymanRepo(RMSFEntities db)
        {
            this.db = db;
        }

        public void Add(DeliverymansDetail e)
        {
            User us = new User()
            {
                UserName = "D" + e.Id,
                Password = "123",
                Type = "Deliveryman"
            };
            db.Users.Add(us);
            db.SaveChanges();

            int id = (from record in db.Users
                      orderby record.Id descending
                      select record.Id).First();

            DeliverymansDetail dd = new DeliverymansDetail();

            dd.DeliverymanName = e.DeliverymanName;
            dd.Phone = e.Phone;
            dd.Address = e.Address;
            dd.Status = "Free";
            dd.UserId = id;
            dd.Salary = e.Salary;
            db.DeliverymansDetails.Add(dd);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var di = db.DeliverymansDetails.FirstOrDefault(e => e.Id == id);
            var us = db.Users.FirstOrDefault(e => e.Id == di.UserId);

            var flag = true;
            while (flag == true)
            {
                var t = db.Tokens.FirstOrDefault(e => e.UserId == us.Id);
                if (t != null)
                {
                    db.Tokens.Remove(db.Tokens.FirstOrDefault(e => e.Id == t.Id));
                    db.SaveChanges();
                }
                else
                {
                    flag = false;
                }
            }
            db.DeliverymansDetails.Remove(db.DeliverymansDetails.FirstOrDefault(e => e.Id == id));
            db.SaveChanges();
            db.Users.Remove(db.Users.FirstOrDefault(e => e.Id == us.Id));
            db.SaveChanges();
        }
        public void Edit(DeliverymansDetail e)
        {
            var u = db.DeliverymansDetails.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(u).CurrentValues.SetValues(e);
            db.Entry(u).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public List<DeliverymansDetail> Get()
        {
            return db.DeliverymansDetails.ToList();
        }

        public DeliverymansDetail Get(int id)
        {
            return db.DeliverymansDetails.FirstOrDefault(e => e.Id == id);
        }
    }
}
