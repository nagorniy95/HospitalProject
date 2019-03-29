using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

using DRHC.Models;

namespace DRHC.Data
{
    public class DrhcCMSContext : IdentityDbContext<ApplicationUser>
    {

        public DrhcCMSContext(DbContextOptions<DrhcCMSContext> options)
        : base(options)
        {

        }


        public DbSet<Admin> admin { get; set; }
        public DbSet<Feedback> feedback { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                    modelBuilder.Entity<Admin>()
                    .HasOne(a => a.user)
                    .WithOne(u => u.admin)
                    .HasForeignKey<ApplicationUser>(u => u.AdminID);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Feedback>().ToTable("Feedback");
            

        }
    }
}
