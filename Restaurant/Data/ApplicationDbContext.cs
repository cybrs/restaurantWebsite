using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
       // private DbContextOptions options;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //this.options = options;
        }

        //public ApplicationDbContext(DbContextOptions options)
        //{
        //    this.options = options;
        //}
        public ApplicationDbContext() { }

        public DbSet<Restaurant.Models.User> User { get; set; }
        public DbSet<Restaurant.Models.Admin> Admin { get; set; }
        public DbSet<Restaurant.Models.Menu> Menu { get; set; }
        public DbSet<Restaurant.Models.Review> Review{ get; set; }
    }
}
