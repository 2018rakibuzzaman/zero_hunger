using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zero_hunger.Models.DB;

namespace zero_hunger.Models.Repository
{
    internal interface Irole
    {
        void InsertRoleRecord(role role);
        IEnumerable<role> GetRole();
        void UpdateRoleRecord(role role);
        void DeleteRoleRecord(int roleid);
        role GetRoleById(int roleid);
    }
}
