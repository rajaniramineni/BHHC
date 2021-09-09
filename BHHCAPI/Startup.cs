using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using BHHCApi.Database;
using GraphiQl;

namespace BHHCApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string _policyName = "CorsPolicy";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _policyName, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddEntityFrameworkInMemoryDatabase().AddDbContext<BHHCContext>(context => { context.UseInMemoryDatabase("BHHCDatabase"); });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            BuildReasonList();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGraphiQl("/graphql");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            app.UseRouting();
            app.UseCors(_policyName);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void BuildReasonList()
        {
            using (var db = new BHHCContext())
            {
                db.Reasons.AddRange(
                new BHHCReason
                {
                    Id = 1,
                    Description = "Reason 1"

                }, new BHHCReason
                {
                    Id = 2,
                    Description = "Reason 2"

                }, new BHHCReason
                {
                    Id = 3,
                    Description = "Reason 3"

                }, new BHHCReason
                {
                    Id = 4,
                    Description = "Reason 4"

                }, new BHHCReason
                {
                    Id = 5,
                    Description = "Reason 5"

                }
                );
                db.Strengths.AddRange(
               new Strength
               {
                   Id = 1,
                   StrengthDescription = "Knowledge of the full stack"

               }, new Strength
               {
                   Id = 2,
                   StrengthDescription = "Ability to quickly learn, adapt and grow"

               }, new Strength
               {
                   Id = 3,
                   StrengthDescription = "Time management"

               }, new Strength
               {
                   Id = 4,
                   StrengthDescription = "Business acumen"

               }, new Strength
               {
                   Id = 5,
                   StrengthDescription = "Interpersonal skills"

               }
               );
                db.GoodFitFacts.AddRange(
               new GoodFitFact
               {
                   Id = 1,
                   FactDescription = "Experiance over 13 years, worked with .Net sharepoint Angular and many others"

               }, new GoodFitFact
               {
                   Id = 2,
                   FactDescription = " Experiance in mentoring and managing team members"

               }, new GoodFitFact
               {
                   Id = 3,
                   FactDescription = "Self Motivated and always up for challenges"

               }, new GoodFitFact
               {
                   Id = 4,
                   FactDescription = "Always called out as good leader"

               }, new GoodFitFact
               {
                   Id = 5,
                   FactDescription = "Worked in different work cultures"

               }
               );

                db.SaveChanges();
            }


        }
    }
}
