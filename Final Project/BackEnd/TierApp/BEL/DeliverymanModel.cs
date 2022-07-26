using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class DeliverymanModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DeliverymanName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
        public string Status { get; set; }
    }
}
