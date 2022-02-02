using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Api.Database;
using GraphiQl;

namespace Api
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
            using (var db = new Context())
            {
                db.Reasons.AddRange(
                new Reason
                {
                    Id = 1,
                    Description = "This company is using .Net Core and cloud technologies which align with my plans of growth, also i feel strong and motivated in agile practices which interests me in the position"

                }, new Reason
                {
                    Id = 2,
                    Description = "Reason 2"

                }, new Reason
                {
                    Id = 3,
                    Description = "reason 3"

                }
                );
                db.Strengths.AddRange(
               new Strength
               {
                   Id = 1,
                   StrengthDescription = "- I have worked in multiple environments and have continued to accept new areas which I am not familiar with in order to continue to improve my skills along with quick learning and adaptability" +
                   ""

               }, new Strength
               {
                   Id = 2,
                   StrengthDescription = "- My ability to work as a team. Aiding other team members when needed to meet our team goals."

               }, new Strength
               {
                   Id = 3,
                   StrengthDescription = "- Time management is one of my strengths. I have an exceptional work ethic and have high expectations of myself and the team to complete a task timely. "

               }, new Strength
               {
                   Id = 4,
                   StrengthDescription = "- My ability to be a good listener and to negotiate the best practices to be successful as a team. Asking questions is another strength because it clarifies and reiterates a concise answer. "

               }, new Strength
               {
                   Id = 5,
                   StrengthDescription = "- My work ethic is another intrinsic strength."

               },
               new Strength
               {
                   Id = 6,
                   StrengthDescription = "- In Addition i do have good Time management, Business acumen and Interpersonal skills."

               }
               );
                db.GoodFitFacts.AddRange(
               new GoodFitFact
               {
                   Id = 1,
                   FactDescription = "- I excel in an agile environment that allows open collaboration and challenges my skill sets. An agile environment has also proven to push me to become a better team member and overall better developer.s"

               }, new GoodFitFact
               {
                   Id = 2,
                   FactDescription = " - While being on an agile team, I feel more engaged, produce better code, and overall have more fun. It has also allowed me to adapt to changes and continue to learn new methods to reach better outcomes."

               }, new GoodFitFact
               {
                   Id = 3,
                   FactDescription = "- I have learned to code in many different environments to be more versatile as a developer. This has allowed me to deliver better processes and different techniques to junior developers that I have mentored. I continue to learn new approaches and have guided other developers to research alternative solutions.  I have become efficient at identifying problem areas before they become problems and assist when appropriate to fix them. "

               }, new GoodFitFact
               {
                   Id = 4,
                   FactDescription = "- I currently work in a diverse workplace which also stretches multiple time zones and cultures. Therefore, communication and time management are valued to maintain overall team success."

               }
               );

                db.SaveChanges();
            }


        }
    }
}
