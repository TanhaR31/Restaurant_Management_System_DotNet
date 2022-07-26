using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class InvProductModel
    {
        public int Id { get; set; }
        public string InvProdName { get; set; }
        public int RemQuantity { get; set; }
        public double UnitPrice { get; set; }
    }
}
