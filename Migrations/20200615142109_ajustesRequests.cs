using Microsoft.EntityFrameworkCore.Migrations;

namespace GDR.Migrations
{
    public partial class ajustesRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionSupport",
                table: "Request",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TechnicianDescription",
                table: "Request",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DPTOPayment",
                table: "Request",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionSupport",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "TechnicianDescription",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "DPTOPayment",
                table: "Request");
        }
    }
}
