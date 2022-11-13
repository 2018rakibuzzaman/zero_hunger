using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zero_hunger.Models.DB;

namespace zero_hunger.Models.Repository
{
    internal interface Ifood
    {
        void InsertFoodRecord(food food);
        IEnumerable<food> GetFood();
        void UpdateFoodRecord(food food);
        void DeleteFoodRecord(int id);
        food GetFoodById(int id);
    }
}
