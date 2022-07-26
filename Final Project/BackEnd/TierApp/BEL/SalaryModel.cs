using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class SalaryModel
    {
        public int Id { get; set; }
        public int DeliverymanId { get; set; }
        public double Bonus { get; set; }
        public double SalPaid { get; set; }
        public Nullable<System.DateTime> SalDate { get; set; }
    }
}
