using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Restaurant.Contracts;
using Restaurant.Data.Migrations;
using Restaurant.Models;
using User = Restaurant.Models.User;
using ApplicationDbContext = Restaurant.Data.ApplicationDbContext;

namespace Restaurant
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

            services.AddDbContext<Data.ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>()
           //     .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        //    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.Add(new ServiceDescriptor(typeof(IAdminRepository), new Admin()));
            //services.Add(new ServiceDescriptor(typeof(IUserRepository), new User()));
            //services.Add(new ServiceDescriptor(typeof(IMenuRepository), new Menu()));
            //services.Add(new ServiceDescriptor(typeof(IReviewRepository), new Review()));

            //services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //   .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddIdentity<IdentityUser,IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 10;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 6;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccesDenied";
                options.SlidingExpiration = true;


            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
