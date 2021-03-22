using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePort.Migrations
{
    public partial class EditForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pay_ParkID",
                table: "Pay",
                column: "ParkID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pay_Park_ParkID",
                table: "Pay",
                column: "ParkID",
                principalTable: "Park",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pay_Park_ParkID",
                table: "Pay");

            migrationBuilder.DropIndex(
                name: "IX_Pay_ParkID",
                table: "Pay");
        }
    }
}
