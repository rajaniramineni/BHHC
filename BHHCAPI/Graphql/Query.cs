using System.Collections.Generic;
using GraphQL;
using System.Linq;
using BHHCApi.Database;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BHHCApi.Graphql
{
    public class Query
    {

        [GraphQLMetadata("reasons")]
        public IEnumerable<BHHCReason> GetReasons()
        {
            DataService ds = new DataService();

            return ds.GetAllReasons();

        }
      
        [GraphQLMetadata("strengths")]
        public IEnumerable<Strength> GetStrengths()
        {
            DataService ds = new DataService();

            return ds.GetAllStrengths();

        }
        [GraphQLMetadata("goodFitFacts")]
        public IEnumerable<GoodFitFact> GetGoodFitFacts()
        {
            DataService ds = new DataService();

            return ds.GetAllGoodFitFacts();
        }


            [GraphQLMetadata("hello")]
        public string GetHello()
        {
           return "World";
        }




    }
}
