using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ManagerModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ManagerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public double Salary { get; set; }
    }
}
