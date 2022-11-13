using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zero_hunger.Models.DB;

namespace zero_hunger.Models.Repository
{
    public class RepositoryCollect_requestClass : Icollect_request
    {
        private zero_hungerEntities zero_hungerEntities;

        public RepositoryCollect_requestClass(zero_hungerEntities zero_hungerEntities)
        {
            this.zero_hungerEntities = zero_hungerEntities;
        }

        public void DeleteCollect_requestRecord(int id)
        {
            collect_request collect_request = zero_hungerEntities.collect_request.Find(id);
            zero_hungerEntities.collect_request.Remove(collect_request);
            zero_hungerEntities.SaveChanges();
        }

        public IEnumerable<collect_request> GetCollect_request()
        {
            return zero_hungerEntities.collect_request.ToList();
        }

        public collect_request GetCollect_requestById(int id)
        {
            return zero_hungerEntities.collect_request.Find(id);
        }

        public void InsertCollect_requestRecord(collect_request collect_request)
        {
            zero_hungerEntities.collect_request.Add(collect_request);
            zero_hungerEntities.SaveChanges();
        }

        public void UpdateCollect_requestRecord(collect_request collect_request)
        {
            zero_hungerEntities.Entry(collect_request).State = System.Data.Entity.EntityState.Modified;
            zero_hungerEntities.SaveChanges();
        }
    }
}