using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class InvProductDetailModel
    {
        public int Id { get; set; }
        public int InvProductId { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}
