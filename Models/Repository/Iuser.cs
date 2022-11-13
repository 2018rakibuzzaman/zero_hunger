using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zero_hunger.Models;
using zero_hunger.Models.DB;

namespace zero_hunger.Models.Repository
{
    internal interface Iuser
    {
        void InsertUserRecord(user user);
        IEnumerable<user> GetUsers();
        void UpdateUserRecord(user user);
        void DeleteUserRecord(int userid);
        user GetUserById(int userid);
        user GetUserByEmail(string email);
    }
}
