using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DRHC.Migrations
{
    public partial class intial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");
        }
    }
}
