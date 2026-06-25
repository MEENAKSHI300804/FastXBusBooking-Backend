using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastXBusBooking.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddSeatBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BusRoutes",
                table: "BusRoutes");

            migrationBuilder.RenameTable(
                name: "BusRoutes",
                newName: "Routes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routes",
                table: "Routes",
                column: "RouteId");

            migrationBuilder.CreateTable(
                name: "SeatBookings",
                columns: table => new
                {
                    SeatBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    SeatStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatBookings", x => x.SeatBookingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routes",
                table: "Routes");

            migrationBuilder.RenameTable(
                name: "Routes",
                newName: "BusRoutes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusRoutes",
                table: "BusRoutes",
                column: "RouteId");
        }
    }
}
