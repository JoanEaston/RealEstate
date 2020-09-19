using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Migrations
{
    public partial class AcdedPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OldPrice",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Properties",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldPrice",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Properties");
        }
    }
}
