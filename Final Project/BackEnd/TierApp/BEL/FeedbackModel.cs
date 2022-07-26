using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class FeedbackModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Comment { get; set; }
    }
}
