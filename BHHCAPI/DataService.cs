using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHHCApi.Database;

namespace BHHCApi
{
    public class DataService
    {
        

        public List<BHHCReason> GetAllReasons()
        {
            using (var db = new BHHCContext())
            {
                return db.Reasons.ToList();
            }
        }
        public List<Strength> GetAllStrengths()
        {
            using (var db = new BHHCContext())
            {
                return db.Strengths.ToList();
            }
        }
        public List<GoodFitFact> GetAllGoodFitFacts()
        {
            using (var db = new BHHCContext())
            {
                return db.GoodFitFacts.ToList();
                }

        }
        


    }
}
