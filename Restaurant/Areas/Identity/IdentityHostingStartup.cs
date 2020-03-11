//using System;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Restaurant.Data;
//using Restaurant.Models;

//[assembly: HostingStartup(typeof(Restaurant.Areas.Identity.IdentityHostingStartup))]
//namespace Restaurant.Areas.Identity
//{
//    public class IdentityHostingStartup : IHostingStartup
//    {
//        public void Configure(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices((context, services) => {
//                services.AddDbContext<ApplicationDbContext>(options =>
//                    options.UseSqlServer(
//                        context.Configuration.GetConnectionString("DefaultConnection")));

//                services.AddDefaultIdentity<IdentityUser>()
//                    .AddEntityFrameworkStores<ApplicationDbContext>();
//            });
//        }
//    }
//}