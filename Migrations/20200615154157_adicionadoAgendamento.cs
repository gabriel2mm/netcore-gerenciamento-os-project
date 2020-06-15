using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GDR.Migrations
{
    public partial class adicionadoAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Scheduling",
                table: "Request",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scheduling",
                table: "Request");
        }
    }
}
