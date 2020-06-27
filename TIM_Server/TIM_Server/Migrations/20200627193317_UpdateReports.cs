using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TIM_Server.Application.Migrations
{
    public partial class UpdateReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reports");

            migrationBuilder.AddColumn<Guid>(
                name: "SoldierId",
                table: "Reports",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoldierId",
                table: "Reports");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
