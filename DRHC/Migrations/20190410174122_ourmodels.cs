using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DRHC.Migrations
{
    public partial class ourmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*This doesn't make any sense
            migrationBuilder.DropPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "AuthorEmail",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "AuthorFName",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "AuthorLName",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "AuthorPhone",
                table: "Feedback");

            
            migrationBuilder.RenameTable(
                name: "Feedback",
                newName: "Faqs");
                
            migrationBuilder.RenameColumn(
                name: "AuthorMessage",
                table: "Faqs",
                newName: "Questions");

            migrationBuilder.RenameColumn(
                name: "FeedbackID",
                table: "Faqs",
                newName: "FaqID");

            migrationBuilder.AddColumn<string>(
                name: "Answers",
                table: "Faqs",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Faqs",
                table: "Faqs",
                column: "FaqID");
                */
            migrationBuilder.CreateTable(
                name: "ContactForms",
                columns: table => new
                {
                    ContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Message = table.Column<string>(maxLength: 1000, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Phone = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForms", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "DietaryRestrictions",
                columns: table => new
                {
                    DietaryRestrictionsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClearLiquid = table.Column<string>(maxLength: 255, nullable: false),
                    Diabetic = table.Column<string>(maxLength: 255, nullable: false),
                    Fasting = table.Column<string>(maxLength: 255, nullable: false),
                    FinishTime = table.Column<DateTime>(nullable: false),
                    FoodType = table.Column<string>(maxLength: 255, nullable: false),
                    LowCholesterol = table.Column<string>(maxLength: 255, nullable: false),
                    LowFat = table.Column<string>(maxLength: 255, nullable: false),
                    LowFiber = table.Column<string>(maxLength: 255, nullable: false),
                    PatientID = table.Column<int>(nullable: false),
                    Preference = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryRestrictions", x => x.DietaryRestrictionsID);
                });

            migrationBuilder.CreateTable(
                name: "Directions",
                columns: table => new
                {
                    DirectionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DirectionName = table.Column<string>(maxLength: 255, nullable: false),
                    Latitude = table.Column<string>(maxLength: 255, nullable: false),
                    Longitude = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directions", x => x.DirectionID);
                });

          /*  migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    DonorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.DonorId);
                });*/
            /*
            migrationBuilder.CreateTable(
                name: "Ecards",
                columns: table => new
                {
                    EcardID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Department = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    PatientName = table.Column<string>(nullable: true),
                    RoomNo = table.Column<int>(nullable: false),
                    SenderEmail = table.Column<string>(nullable: true),
                    SenderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecards", x => x.EcardID);
                });
                */
            migrationBuilder.CreateTable(
                name: "ERWaitTimes",
                columns: table => new
                {
                    ERWaitTimeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    WaitTimeCat = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ERWaitTimes", x => x.ERWaitTimeId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventDescription = table.Column<string>(maxLength: 255, nullable: false),
                    EventImage = table.Column<string>(maxLength: 255, nullable: false),
                    EventTitle = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                });
            /*
            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorEmail = table.Column<string>(maxLength: 255, nullable: false),
                    AuthorFName = table.Column<string>(maxLength: 255, nullable: false),
                    AuthorLName = table.Column<string>(maxLength: 255, nullable: false),
                    AuthorMessage = table.Column<string>(maxLength: 1000, nullable: false),
                    AuthorPhone = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackID);
                });
                */
            migrationBuilder.CreateTable(
                name: "JobPostings",
                columns: table => new
                {
                    JobPostingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AboutOrg = table.Column<string>(nullable: true),
                    AboutPosition = table.Column<string>(nullable: true),
                    DeadlineToApply = table.Column<DateTime>(nullable: false),
                    Department = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Education = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPostings", x => x.JobPostingID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateAdmitted = table.Column<DateTime>(maxLength: 255, nullable: false),
                    DietaryRestrictionsID = table.Column<int>(nullable: false),
                    Fname = table.Column<string>(maxLength: 255, nullable: false),
                    Lname = table.Column<string>(maxLength: 255, nullable: false),
                    RoomNumber = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                });

            migrationBuilder.CreateTable(
                name: "RecRoomBookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Fname = table.Column<string>(maxLength: 255, nullable: false),
                    Lname = table.Column<string>(maxLength: 255, nullable: false),
                    Month = table.Column<string>(maxLength: 255, nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Week = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecRoomBookings", x => x.BookingID);
                });
            /*
            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserEmail = table.Column<string>(maxLength: 500, nullable: false),
                    UserFName = table.Column<string>(maxLength: 500, nullable: false),
                    UserLName = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.UserID);
                });
                */
                /*
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TagName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagID);
                });
                */
                /*
            migrationBuilder.CreateTable(
                name: "TestimonialStatuss",
                columns: table => new
                {
                    TestimonialStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TestimonialStatusName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestimonialStatuss", x => x.TestimonialStatusID);
                });
                */
                /*
            migrationBuilder.CreateTable(
                name: "TipStatuss",
                columns: table => new
                {
                    TipStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipStatusName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipStatuss", x => x.TipStatusID);
                });
                */
            migrationBuilder.CreateTable(
                name: "VolunteerApplicants",
                columns: table => new
                {
                    ApplicantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 255, nullable: false),
                    ApplicationDate = table.Column<DateTime>(maxLength: 255, nullable: false),
                    Approval = table.Column<bool>(maxLength: 255, nullable: false),
                    City = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Experience = table.Column<string>(maxLength: 500, nullable: false),
                    Fname = table.Column<string>(maxLength: 255, nullable: false),
                    Lname = table.Column<string>(maxLength: 255, nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Postal = table.Column<string>(maxLength: 255, nullable: false),
                    Province = table.Column<string>(maxLength: 255, nullable: false),
                    VolunteerPostingID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerApplicants", x => x.ApplicantID);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerPositions",
                columns: table => new
                {
                    VolunteerPostingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AboutOrg = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Education = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(maxLength: 500, nullable: false),
                    PostTitle = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerPositions", x => x.VolunteerPostingID);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    DonationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    AppDate = table.Column<DateTime>(nullable: false),
                    //DonorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.DonationId);
                    
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    JobApplicationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    AppDate = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Coverletter = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    JobPostingId = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Resume = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.JobApplicationID);
                    table.ForeignKey(
                        name: "FK_JobApplications_JobPostings_JobPostingId",
                        column: x => x.JobPostingId,
                        principalTable: "JobPostings",
                        principalColumn: "JobPostingID",
                        onDelete: ReferentialAction.Cascade);
                });
            /*
            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    TestimonialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Story = table.Column<string>(maxLength: 1000, nullable: false),
                    TestimonialStatusID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    UserFName = table.Column<string>(maxLength: 255, nullable: false),
                    UserLName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.TestimonialID);
                    table.ForeignKey(
                        name: "FK_Testimonials_TestimonialStatuss_TestimonialStatusID",
                        column: x => x.TestimonialStatusID,
                        principalTable: "TestimonialStatuss",
                        principalColumn: "TestimonialStatusID",
                        onDelete: ReferentialAction.Cascade);
                });
                */
                /*
            migrationBuilder.CreateTable(
                name: "TipAndLetters",
                columns: table => new
                {
                    TipAndLetterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(maxLength: 1000, nullable: false),
                    TagID = table.Column<int>(nullable: false),
                    TipStatusID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipAndLetters", x => x.TipAndLetterID);
                    table.ForeignKey(
                        name: "FK_TipAndLetters_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipAndLetters_TipStatuss_TipStatusID",
                        column: x => x.TipStatusID,
                        principalTable: "TipStatuss",
                        principalColumn: "TipStatusID",
                        onDelete: ReferentialAction.Cascade);
                });
                */
                /*
            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonorId",
                table: "Donations",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobPostingId",
                table: "JobApplications",
                column: "JobPostingId");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_TestimonialStatusID",
                table: "Testimonials",
                column: "TestimonialStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_TipAndLetters_TagID",
                table: "TipAndLetters",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_TipAndLetters_TipStatusID",
                table: "TipAndLetters",
                column: "TipStatusID");

    */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactForms");

            migrationBuilder.DropTable(
                name: "DietaryRestrictions");

            migrationBuilder.DropTable(
                name: "Directions");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Ecards");

            migrationBuilder.DropTable(
                name: "ERWaitTimes");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "RecRoomBookings");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "TipAndLetters");

            migrationBuilder.DropTable(
                name: "VolunteerApplicants");

            migrationBuilder.DropTable(
                name: "VolunteerPositions");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "JobPostings");

            migrationBuilder.DropTable(
                name: "TestimonialStatuss");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "TipStatuss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Faqs",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "Answers",
                table: "Faqs");

            migrationBuilder.RenameTable(
                name: "Faqs",
                newName: "Feedback");

            migrationBuilder.RenameColumn(
                name: "Questions",
                table: "Feedback",
                newName: "AuthorMessage");

            migrationBuilder.RenameColumn(
                name: "FaqID",
                table: "Feedback",
                newName: "FeedbackID");

            migrationBuilder.AddColumn<string>(
                name: "AuthorEmail",
                table: "Feedback",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthorFName",
                table: "Feedback",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthorLName",
                table: "Feedback",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthorPhone",
                table: "Feedback",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feedback",
                table: "Feedback",
                column: "FeedbackID");
        }
    }
}
