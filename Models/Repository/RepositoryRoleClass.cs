using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zero_hunger.Models.DB;

namespace zero_hunger.Models.Repository
{
    public class RepositoryRoleClass : Irole
    {
        private zero_hungerEntities zero_hungerEntities;

        public RepositoryRoleClass(zero_hungerEntities zero_hungerEntities)
        {
            this.zero_hungerEntities = zero_hungerEntities;
        }

        public void DeleteRoleRecord(int roleid)
        {
            role delrole = zero_hungerEntities.roles.Find(roleid);
            zero_hungerEntities.roles.Remove(delrole);
            zero_hungerEntities.SaveChanges();
        }

        public IEnumerable<role> GetRole()
        {
            return zero_hungerEntities.roles.ToList();
        }

        public role GetRoleById(int roleid)
        {
            return zero_hungerEntities.roles.Find(roleid);
        }

        public void InsertRoleRecord(role role)
        {
            zero_hungerEntities.roles.Add(role);
            zero_hungerEntities.SaveChanges();
        }

        public void UpdateRoleRecord(role role)
        {
            zero_hungerEntities.Entry(role).State = System.Data.Entity.EntityState.Modified;
            zero_hungerEntities.SaveChanges();
        }
    }
}