using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zero_hunger.Models.DB;

namespace zero_hunger.Models.Repository
{
    internal interface Icollect_request
    {
        void InsertCollect_requestRecord(collect_request collect_request);
        IEnumerable<collect_request> GetCollect_request();
        void UpdateCollect_requestRecord(collect_request collect_request);
        void DeleteCollect_requestRecord(int id);
        collect_request GetCollect_requestById(int id);
    }
}
