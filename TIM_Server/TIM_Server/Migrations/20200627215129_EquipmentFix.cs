using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TIM_Server.Application.Migrations
{
    public partial class EquipmentFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StatusDate",
                table: "Equipments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusDate",
                table: "Equipments");
        }
    }
}
