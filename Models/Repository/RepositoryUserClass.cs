using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zero_hunger.Models;
using zero_hunger.Models.DB;
using zero_hunger.Models.Repository;
namespace zero_hunger.Models.Repository
{
    public class RepositoryUserClass : Iuser
    {
        private zero_hungerEntities zero_hungerEntities;

        public RepositoryUserClass(zero_hungerEntities zero_hungerEntities)
        {
            this.zero_hungerEntities = zero_hungerEntities;
        }

        public void DeleteUserRecord(int userid)
        {
            user deluser = zero_hungerEntities.users.Find(userid); 
            zero_hungerEntities.users.Remove(deluser);
            zero_hungerEntities.SaveChanges();
        }

        public user GetUserByEmail(string email)
        {
            return zero_hungerEntities.users.FirstOrDefault(m => m.email == email);
        }

        public user GetUserById(int userid)
        {
            return zero_hungerEntities.users.Find(userid);

        }

        public IEnumerable<user> GetUsers()
        {
            return zero_hungerEntities.users.ToList();
        }

        public void InsertUserRecord(user user)
        {
            zero_hungerEntities.users.Add(user);
            zero_hungerEntities.SaveChanges();
        }

        public void UpdateUserRecord(user user)
        {
            zero_hungerEntities.Entry(user).State = System.Data.Entity.EntityState.Modified;
            zero_hungerEntities.SaveChanges();
        }
    }
}