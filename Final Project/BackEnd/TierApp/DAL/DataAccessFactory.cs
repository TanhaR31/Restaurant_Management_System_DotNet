using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static RMSFEntities db;
        static DataAccessFactory()
        {
            db = new RMSFEntities();
        }

        public static IAuth AuthDataAccess()
        {
            return new AuthRepo(db);
        }

        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepo(db);
        }

        public static IRepository<DeliverymansDetail, int> DeliverymanDataAccess()
        {
            return new DeliverymanRepo(db);
        }

        public static IRepository<Token, string> TokenDataAccess()
        {
            return new TokenRepo(db);
        }
    }
}
