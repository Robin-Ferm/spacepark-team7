using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePort.Migrations
{
    public partial class AddedBoolPayed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Payed",
                table: "Park",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Payed",
                table: "Park");
        }
    }
}
