using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepo : IRepository<User, int>
    {
        RMSFEntities db;

        public UserRepo(RMSFEntities db)
        {
            this.db = db;
        }

        public void Add(User e)
        {
            db.Users.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var flag = true;
            while (flag == true)
            {
                var t = db.Tokens.FirstOrDefault(e => e.UserId == id);
                if (t != null)
                {
                    db.Tokens.Remove(db.Tokens.FirstOrDefault(e => e.Id == t.Id));
                    db.SaveChanges();
                }
                else
                {
                    flag = false;
                }
            }
            db.Users.Remove(db.Users.FirstOrDefault(e => e.Id == id));
            db.SaveChanges();
        }

        public void Edit(User e)
        {
            var u = db.Users.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(u).CurrentValues.SetValues(e);
            db.Entry(u).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(e => e.Id == id);
        }
    }
}
