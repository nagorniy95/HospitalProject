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
        public DbSet<SearchCategory> searchCategory { get; set; }
        public DbSet<Alerts> alerts { get; set; }

        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<ERWaitTime> ERWaitTimes { get; set; }




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
                .HasOne(testimonial => testimonial.TestimonialStatus)
                .WithMany(testimonialstatus => testimonialstatus.Testimonials)
                .HasForeignKey(testimonial => testimonial.TestimonialStatusID);


            //Tag has many TipAndLetters, each TipAndLetter has one Tag
            modelBuilder.Entity<TipAndLetter>()
                .HasOne(tipandletter => tipandletter.Tag)
                .WithMany(tag => tag.TipAndLetters)
                .HasForeignKey(tipandletter => tipandletter.TagID);


            //TipStatus has many TipAndLetters, each TipAndLetter has one TipStatus
            modelBuilder.Entity<TipAndLetter>()
                .HasOne(tipandletter => tipandletter.TipStatus)
                .WithMany(tipStatus => tipStatus.TipAndLetters)
                .HasForeignKey(tipandletter => tipandletter.TipStatusID);


            //JobPosting has many JobApplications, each JobApplication has one JobPosting
              modelBuilder.Entity<JobApplication>()
                .HasOne(JobApplication => JobApplication.JobPostings)
                .WithMany(JobPosting=> JobPosting.JobApplication)
                .HasForeignKey(JobApplication => JobApplication.JobPostingId);





            //Donor can have many donations, each donation has one donor
              modelBuilder.Entity<Donation>()
                .HasOne(donation => donation.Donor)
                .WithMany(donor => donor.Donations)
                .HasForeignKey(donation => donation.DonorId);






            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Feedback>().ToTable("Feedback");
            modelBuilder.Entity<SearchCategory>().ToTable("SearchCAtegory");
            modelBuilder.Entity<Alerts>().ToTable("Alerts");


            modelBuilder.Entity<Registration>().ToTable("Registrations");

            modelBuilder.Entity<Testimonial>().ToTable("Testimonials");
            modelBuilder.Entity<TestimonialStatus>().ToTable("TestimonialStatuss");

            modelBuilder.Entity<TipAndLetter>().ToTable("TipAndLetters");
            modelBuilder.Entity<Tag>().ToTable("Tags");
            modelBuilder.Entity<TipStatus>().ToTable("TipStatuss");

            modelBuilder.Entity<Faq>().ToTable("Faqs");


        }

        public DbSet<DRHC.Models.Registration> Registrations { get; set; }

        public DbSet<DRHC.Models.VolunteerPosition> VolunteerPosition { get; set; }

        public DbSet<DRHC.Models.VolunteerApplicant> VolunteerApplicant { get; set; }
    }
}
