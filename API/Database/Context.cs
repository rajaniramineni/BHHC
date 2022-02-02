using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.Database
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options)
          : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Database");
           
        }

        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Strength> Strengths { get; set; }
        public DbSet<GoodFitFact> GoodFitFacts { get; set; }
        

    }
}

