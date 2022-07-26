using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FeedbackRepo
    {
        static RMSFEntities db;

        static FeedbackRepo()
        {
            db = new RMSFEntities();
        }
        public static List<Feedback> GetAllFeedback()
        {
            return db.Feedbacks.ToList();
        }
    }
}
