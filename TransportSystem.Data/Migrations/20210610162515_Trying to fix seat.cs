using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportSystem.Data.Migrations
{
    public partial class Tryingtofixseat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvailableSeat",
                table: "Buses",
                newName: "TotalSeats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalSeats",
                table: "Buses",
                newName: "AvailableSeat");
        }
    }
}
