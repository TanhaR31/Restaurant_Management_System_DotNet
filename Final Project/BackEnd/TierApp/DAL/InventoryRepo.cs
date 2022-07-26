using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class InventoryRepo
    {
        static RMSFEntities db;

        static InventoryRepo()
        {
            db = new RMSFEntities();
        }

        public static List<InventoryProduct> GetAllInventoryProduct()
        {
            return db.InventoryProducts.ToList();
        }

        public static List<InventoryOrdersDetail> GetAllInventoryOrder()
        {
            return db.InventoryOrdersDetails.ToList();
        }

        public static List<InventoryOrdersTotal> GetAllInventoryTotal()
        {
            return db.InventoryOrdersTotals.ToList();
        }
        
        public static void CreateOrder(InventoryOrdersDetail dl)
        {
            var prod = dl.InvProductId;
            var uprice = (from s in db.InventoryProducts
                         where s.Id == prod
                         select s.UnitPrice).FirstOrDefault();
            InventoryOrdersDetail d = new InventoryOrdersDetail()
            {
                InvProductId = dl.InvProductId,
                Quantity = dl.Quantity,
                Total = dl.Quantity * uprice
            };
            db.InventoryOrdersDetails.Add(d);
            db.SaveChanges();
        }

        public static List<InventoryOrdersTotal> PlaceOrder()
        {
            var Total = 0.0;
            var did = (from s in db.InventoryOrdersDetails
                       select s).ToList();
            foreach (var p in did)
            {
                Total += p.Total;
            }
            InventoryOrdersTotal d = new InventoryOrdersTotal()
            {
                InvTotalPrice = Total,
                Status = "Not Received"
            };
            db.InventoryOrdersTotals.Add(d);
            db.SaveChanges();
            return db.InventoryOrdersTotals.ToList();
        }

        public static void RecieveOrder(InventoryOrdersTotal ol)
        {
            //Order Status Change In InventoryOrdersTotals Table
            var u = db.InventoryOrdersTotals.FirstOrDefault(en => en.Id == ol.Id);
            db.Entry(u).CurrentValues.SetValues(ol);
            db.Entry(u).State = System.Data.EntityState.Modified;
            db.SaveChanges();

            //Add New Quantity To InventoryProducts Table
            var did = (from s in db.InventoryOrdersDetails
                       select s).ToList();
            foreach (var p in did)
            {
                var pid = (from i in db.InventoryProducts
                           where i.Id == p.InvProductId
                           select i).FirstOrDefault();
                pid.RemQuantity += p.Quantity;
                db.Entry(pid).CurrentValues.SetValues(pid);
                db.Entry(pid).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }

            //Delete All From InventoryOrdersDetails Table
            var exist = (from s in db.InventoryOrdersDetails
                         select s).ToList();

            foreach (var p in exist)
            {
                db.InventoryOrdersDetails.Remove(db.InventoryOrdersDetails.FirstOrDefault(e => e.Id == p.Id));
                db.SaveChanges();
            }

            ////Add New Quantity To InventoryProducts Table
            //if (ol.Status == "Recieved")
            //{
            //    var did = (from s in db.InventoryOrdersDetails
            //               select s).ToList();
            //    foreach (var p in did)
            //    {
            //        var pid = (from i in db.InventoryProducts
            //                   where i.Id == p.InvProductId
            //                   select i).FirstOrDefault();
            //        pid.RemQuantity += p.Quantity;
            //        db.Entry(pid).CurrentValues.SetValues(pid);
            //        db.Entry(pid).State = System.Data.EntityState.Modified;
            //        db.SaveChanges();
            //    }
            //}

            ////Delete All From InventoryOrdersDetails Table
            //if (ol.Status == "Recieved")
            //{
            //    var exist = (from s in db.InventoryOrdersDetails
            //                 select s).ToList();

            //    foreach(var p in exist)
            //    {
            //        db.InventoryOrdersDetails.Remove(db.InventoryOrdersDetails.FirstOrDefault(e => e.Id == p.Id));
            //        db.SaveChanges();
            //    }
            //}
        }
    }
}
