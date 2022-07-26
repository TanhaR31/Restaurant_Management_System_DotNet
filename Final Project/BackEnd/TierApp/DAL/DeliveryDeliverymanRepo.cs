using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DeliveryDeliverymanRepo
    {
        static RMSFEntities db;

        static DeliveryDeliverymanRepo()
        {
            db = new RMSFEntities();
        }

        public static List<Delivery> GetAllDeliveries()
        {
            return db.Deliveries.ToList();
        }

        public static List<DeliverymansDetail> GetAllDeliveryman()
        {
            return db.DeliverymansDetails.ToList();
        }

        public static List<Order> GetAllOrder()
        {
            return db.Orders.ToList();
        }

        public static List<DeliverymansDetail> GetFreeDeliveryman()
        {
            var man = new List<DeliverymansDetail>();
            var t = (from pr in db.DeliverymansDetails
                     where pr.Status == "Free"
                     select pr).ToList();

            foreach (var p in t)
            {
                DeliverymansDetail d = new DeliverymansDetail()
                {
                    Id = p.Id,
                    DeliverymanName = p.DeliverymanName,
                    Phone = p.Phone,
                    Address = p.Address,
                    Status = p.Status,
                    UserId = p.UserId
                };
                man.Add(d);
            }
            return man;
        }

        public static void AssignDeliveryman(Delivery pd)
        {
            var chid = pd.DeliverymanId;
            var check = (from s in db.DeliverymansDetails
                         where s.Id == chid
                         select s.Status).FirstOrDefault();
            if (check == "Free")
            {
                var delivery = (from p in db.Deliveries
                                where p.Id == pd.Id
                                select p).FirstOrDefault();
                db.Entry(delivery).CurrentValues.SetValues(pd);
                db.Entry(delivery).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                var id = delivery.DeliverymanId;
                var stat = (from s in db.DeliverymansDetails
                            where s.Id == id
                            select s).FirstOrDefault();
                stat.Status = "Busy";
                db.SaveChanges();
            }
            else
            {
                Console.Beep();
            }
        }
    }
}
