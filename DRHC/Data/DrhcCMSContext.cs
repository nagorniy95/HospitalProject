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

        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<TestimonialStatus> TestimonialStatuss { get; set; }

        public DbSet<TipAndLetter> TipAndLetters { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TipStatus> TipStatuss { get; set; }
        /* public DbSet<Registration> Registrations { get; set; }*/
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Ecard> Ecards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                    modelBuilder.Entity<Admin>()
                    .HasOne(a => a.user)
                    .WithOne(u => u.admin)
                    .HasForeignKey<ApplicationUser>(u => u.AdminID);


            //status has many testimonials, each testimonial has one status
            modelBuilder.Entity<Testimonial>()
                .HasOne(p => p.TestimonialStatus)
                .WithMany(b => b.Testimonials)
                .HasForeignKey(p => p.TestimonialStatusID);


            //Tag has many TipAndLetters, each TipAndLetter has one Tag
            modelBuilder.Entity<TipAndLetter>()
                .HasOne(p => p.Tag)
                .WithMany(b => b.TipAndLetters)
                .HasForeignKey(p => p.TagID);


            //TipStatus has many TipAndLetters, each TipAndLetter has one TipStatus
            modelBuilder.Entity<TipAndLetter>()
                .HasOne(p => p.TipStatus)
                .WithMany(b => b.TipAndLetters)
                .HasForeignKey(p => p.TipStatusID);






            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().ToTable("Admins");

            modelBuilder.Entity<Registration>().ToTable("Registrations");

            modelBuilder.Entity<Testimonial>().ToTable("Testimonials");
            modelBuilder.Entity<TestimonialStatus>().ToTable("TestimonialStatuss");

            modelBuilder.Entity<TipAndLetter>().ToTable("TipAndLetters");
            modelBuilder.Entity<Tag>().ToTable("Tags");
            modelBuilder.Entity<TipStatus>().ToTable("TipStatuss");

            modelBuilder.Entity<Faq>().ToTable("Faqs");

            modelBuilder.Entity<Ecard>().ToTable("Ecards");



        }

        public DbSet<DRHC.Models.Registration> Registrations { get; set; }
    }
}
