using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zero_hunger.Models.DB;

namespace zero_hunger.Models.Repository
{
    public class RepositoryFoodClass : Ifood
    {
        private zero_hungerEntities zero_hungerEntities;

        public RepositoryFoodClass(zero_hungerEntities zero_hungerEntities)
        {
            this.zero_hungerEntities = zero_hungerEntities;
        }

        public void DeleteFoodRecord(int id)
        {
            food food = zero_hungerEntities.foods.Find(id);
            zero_hungerEntities.foods.Remove(food);
            zero_hungerEntities.SaveChanges();
        }

        public IEnumerable<food> GetFood()
        {
            return zero_hungerEntities.foods.ToList();
        }

        public food GetFoodById(int id)
        {
            return zero_hungerEntities.foods.Find(id);
        }

        public void InsertFoodRecord(food food)
        {
            zero_hungerEntities.foods.Add(food);
            zero_hungerEntities.SaveChanges();
        }

        public void UpdateFoodRecord(food food)
        {
            zero_hungerEntities.Entry(food).State = System.Data.Entity.EntityState.Modified;
            zero_hungerEntities.SaveChanges();
        }
    }
}