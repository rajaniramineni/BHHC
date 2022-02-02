using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Database;

namespace Api
{
    public class DataService
    {
        

        public List<Reason> GetAllReasons()
        {
            using (var db = new Context())
            {
                return db.Reasons.ToList();
            }
        }
        public List<Strength> GetAllStrengths()
        {
            using (var db = new Context())
            {
                return db.Strengths.ToList();
            }
        }
        public List<GoodFitFact> GetAllGoodFitFacts()
        {
            using (var db = new Context())
            {
                return db.GoodFitFacts.ToList();
                }

        }
        


    }
}
