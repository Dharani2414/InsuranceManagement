using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface UserService
    {
        bool AddUser(User user);
        List<User> GetAllUsers();
        bool Login(string username, string password);
        User GetUserByUsername(string username);
        bool DeleteUser(int userId);
    }
}
