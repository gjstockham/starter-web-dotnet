using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BPSample.Infrastructure.Migrations
{
    public partial class PatientInviteMissingFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PatientInvite",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FamilyName",
                table: "PatientInvite",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GivenName",
                table: "PatientInvite",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganisationId",
                table: "PatientInvite",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SmsNumber",
                table: "PatientInvite",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "PatientInvite");

            migrationBuilder.DropColumn(
                name: "FamilyName",
                table: "PatientInvite");

            migrationBuilder.DropColumn(
                name: "GivenName",
                table: "PatientInvite");

            migrationBuilder.DropColumn(
                name: "OrganisationId",
                table: "PatientInvite");

            migrationBuilder.DropColumn(
                name: "SmsNumber",
                table: "PatientInvite");
        }
    }
}
