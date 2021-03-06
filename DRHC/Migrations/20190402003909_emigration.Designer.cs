﻿// <auto-generated />
using DRHC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DRHC.Migrations
{
    [DbContext(typeof(DrhcCMSContext))]
    [Migration("20190402003909_emigration")]
    partial class emigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DRHC.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserID");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("DRHC.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int?>("AdminID");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AdminID")
                        .IsUnique()
                        .HasFilter("[AdminID] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DRHC.Models.Ecard", b =>
                {
                    b.Property<int>("EcardID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Department");

                    b.Property<string>("Message");

                    b.Property<string>("PatientName");

                    b.Property<int>("RoomNo");

                    b.Property<string>("SenderEmail");

                    b.Property<string>("SenderName");

                    b.HasKey("EcardID");

                    b.ToTable("Ecards");
                });

            modelBuilder.Entity("DRHC.Models.Faq", b =>
                {
                    b.Property<int>("FaqID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Questions")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.HasKey("FaqID");

                    b.ToTable("Faqs");
                });

            modelBuilder.Entity("DRHC.Models.Registration", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("UserFName")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("UserLName")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("UserID");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("DRHC.Models.Tag", b =>
                {
                    b.Property<int>("TagID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("TagID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DRHC.Models.Testimonial", b =>
                {
                    b.Property<int>("TestimonialID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Story")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<int>("TestimonialStatusID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("UserFName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("UserLName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("TestimonialID");

                    b.HasIndex("TestimonialStatusID");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("DRHC.Models.TestimonialStatus", b =>
                {
                    b.Property<int>("TestimonialStatusID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TestimonialStatusName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("TestimonialStatusID");

                    b.ToTable("TestimonialStatuss");
                });

            modelBuilder.Entity("DRHC.Models.TipAndLetter", b =>
                {
                    b.Property<int>("TipAndLetterID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<int>("TagID");

                    b.Property<int>("TipStatusID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("TipAndLetterID");

                    b.HasIndex("TagID");

                    b.HasIndex("TipStatusID");

                    b.ToTable("TipAndLetters");
                });

            modelBuilder.Entity("DRHC.Models.TipStatus", b =>
                {
                    b.Property<int>("TipStatusID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TipStatusName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("TipStatusID");

                    b.ToTable("TipStatuss");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DRHC.Models.ApplicationUser", b =>
                {
                    b.HasOne("DRHC.Models.Admin", "admin")
                        .WithOne("user")
                        .HasForeignKey("DRHC.Models.ApplicationUser", "AdminID");
                });

            modelBuilder.Entity("DRHC.Models.Testimonial", b =>
                {
                    b.HasOne("DRHC.Models.TestimonialStatus", "TestimonialStatus")
                        .WithMany("Testimonials")
                        .HasForeignKey("TestimonialStatusID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DRHC.Models.TipAndLetter", b =>
                {
                    b.HasOne("DRHC.Models.Tag", "Tag")
                        .WithMany("TipAndLetters")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DRHC.Models.TipStatus", "TipStatus")
                        .WithMany("TipAndLetters")
                        .HasForeignKey("TipStatusID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DRHC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DRHC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DRHC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DRHC.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
