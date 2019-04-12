using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DRHC.Migrations
{
    public partial class dietaryrestrictionsfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VolunteerPostingID",
                table: "VolunteerPositions",
                newName: "VolunteerPositionID");

            migrationBuilder.RenameColumn(
                name: "VolunteerPostingID",
                table: "VolunteerApplicants",
                newName: "VolunteerPositionID");

            migrationBuilder.RenameColumn(
                name: "DietaryRestrictionsID",
                table: "Patients",
                newName: "DietaryRestrictionID");

            migrationBuilder.RenameColumn(
                name: "DietaryRestrictionsID",
                table: "DietaryRestrictions",
                newName: "DietaryRestrictionID");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteerApplicants_VolunteerPositionID",
                table: "VolunteerApplicants",
                column: "VolunteerPositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DietaryRestrictionID",
                table: "Patients",
                column: "DietaryRestrictionID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_DietaryRestrictions_DietaryRestrictionID",
                table: "Patients",
                column: "DietaryRestrictionID",
                principalTable: "DietaryRestrictions",
                principalColumn: "DietaryRestrictionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteerApplicants_VolunteerPositions_VolunteerPositionID",
                table: "VolunteerApplicants",
                column: "VolunteerPositionID",
                principalTable: "VolunteerPositions",
                principalColumn: "VolunteerPositionID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_DietaryRestrictions_DietaryRestrictionID",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteerApplicants_VolunteerPositions_VolunteerPositionID",
                table: "VolunteerApplicants");

            migrationBuilder.DropIndex(
                name: "IX_VolunteerApplicants_VolunteerPositionID",
                table: "VolunteerApplicants");

            migrationBuilder.DropIndex(
                name: "IX_Patients_DietaryRestrictionID",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "VolunteerPositionID",
                table: "VolunteerPositions",
                newName: "VolunteerPostingID");

            migrationBuilder.RenameColumn(
                name: "VolunteerPositionID",
                table: "VolunteerApplicants",
                newName: "VolunteerPostingID");

            migrationBuilder.RenameColumn(
                name: "DietaryRestrictionID",
                table: "Patients",
                newName: "DietaryRestrictionsID");

            migrationBuilder.RenameColumn(
                name: "DietaryRestrictionID",
                table: "DietaryRestrictions",
                newName: "DietaryRestrictionsID");
        }
    }
}
