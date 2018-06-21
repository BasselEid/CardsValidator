using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Validator.Data;
using Microsoft.EntityFrameworkCore;
using Validator;
using Validator.Services;

namespace Validator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("CardsDatabase"))
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<CardsRepository>();
            services.AddTransient<CardValidator>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    Console.WriteLine("here");

                    if (!db.Cards.Any())
                    {
                        Console.WriteLine("NO Cards found");
                        db.Cards.AddRange(new List<Card>
                            {
                                new Card {

                                    Number = "4532502535530681",
                                    Type = CardType.VisaCard,
                                    Year = 2018,
                                    Month = 2,
                                },
                                new Card {
                                    Number = "4626857291757960",
                                    Type = CardType.VisaCard,
                                    Year = 2018,
                                    Month = 2,
                                },
                                new Card {
                                    Number = "4929190883848003",
                                    Type = CardType.VisaCard,
                                    Year = 2018,
                                    Month = 2,
                                },
                                new Card {
                                    Number = "5462253588638655",
                                    Type = CardType.MasterCard,
                                    Year = 2018,
                                    Month = 2,
                                },
                                new Card {
                                    Number = "5290876870575413",
                                    Type = CardType.MasterCard,
                                    Year = 2018,
                                    Month = 2,
                                },
                                new Card {
                                    Number = "5243731722405376",
                                    Type = CardType.MasterCard,
                                    Year = 2018,
                                    Month = 2,
                                },
                            });

                        db.SaveChanges();
                    }
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
