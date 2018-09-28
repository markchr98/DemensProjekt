using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemensProjekt.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemensProjekt
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<IdentityDataContext>(options =>
            {
                //enter connection string (use onfiguration.GetconnectionString at some point (see lynda))
                var connectionString = @"Server = EALSQL1.eal.local; Database = DB2017_A09; User Id = USER_A09; Password = SesamLukOp_09; ";
                options.UseSqlServer(connectionString);
            });

            services.AddDbContext<BlogDataContext>(options =>
            {
                //enter connection string (use configuration.GetConnectionString at some point (see lynda))
                var connectionString = @"Server = EALSQL1.eal.local; Database = DB2017_A09; User Id = USER_A09; Password = SesamLukOp_09; ";
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDataContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
