using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BHHCApi.Database
{
    public class BHHCContext : DbContext
    {
        public BHHCContext() { }
        public BHHCContext(DbContextOptions<BHHCContext> options)
          : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BHHCDatabase");
           
        }

        public DbSet<BHHCReason> Reasons { get; set; }
        public DbSet<Strength> Strengths { get; set; }
        public DbSet<GoodFitFact> GoodFitFacts { get; set; }
        

    }
}

