using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePort.Migrations
{
    public partial class AddFirstSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Park",
                columns: new[] { "ID", "ArrivalTime", "Payed", "PersonName", "SpaceShip" },
                values: new object[] { 1, new DateTime(2021, 3, 24, 10, 22, 14, 910, DateTimeKind.Local).AddTicks(7342), false, "Watto", "x-wing" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Park",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
