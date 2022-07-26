using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IAuth
    {
        Token Authenticate(User user);
        bool IsAuthenticated(string token);
        bool Logout(string token);
    }
}
