using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DRHC.Migrations
{
    public partial class Azebmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropForeignKey(
                name: "FK_Donations_Donors_DonorId",
                table: "Donations");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Donations_DonorId",
                table: "Donations");*/

            migrationBuilder.DropColumn(
                name: "Position",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "ERWaitTimes");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "ERWaitTimes");

            migrationBuilder.DropColumn(
                name: "AppDate",
                table: "Donations");

           /* migrationBuilder.DropColumn(
                name: "DonorId",
                table: "Donations");*/

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "JobApplications",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Resume",
                table: "JobApplications",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Coverletter",
                table: "JobApplications",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Donations",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Donations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Donations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Donations",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Donations",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Donations",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Donations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Donations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Donations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Donations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Donations");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "JobApplications",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "Resume",
                table: "JobApplications",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Coverletter",
                table: "JobApplications",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "JobApplications",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "ERWaitTimes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                table: "ERWaitTimes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Donations",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<DateTime>(
                name: "AppDate",
                table: "Donations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DonorId",
                table: "Donations",
                nullable: false,
                defaultValue: 0);

            /*migrationBuilder.CreateTable(
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonorId",
                table: "Donations",
                column: "DonorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Donors_DonorId",
                table: "Donations",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "DonorId",
                onDelete: ReferentialAction.Cascade);*/
        }
    }
}
