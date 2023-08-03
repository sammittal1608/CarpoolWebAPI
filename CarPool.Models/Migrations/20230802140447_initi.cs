using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarPool.Models.Migrations
{
    /// <inheritdoc />
    public partial class initi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_OfferRides_DBOfferRideOwnerId",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferRides",
                table: "OfferRides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedRides",
                table: "BookedRides");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "2547cf1e-6949-4f3c-b800-6541bb91c73f");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "34518ac6-22a0-44a7-929c-08378da46282");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "45ec80f3-3bdf-47ef-b308-b767a43f122a");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "d40ec757-3aba-4c84-b587-322b2cb21057");

            migrationBuilder.RenameColumn(
                name: "DBOfferRideOwnerId",
                table: "Cities",
                newName: "DBOfferRideRideId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_DBOfferRideOwnerId",
                table: "Cities",
                newName: "IX_Cities_DBOfferRideRideId");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "OfferRides",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "RideId",
                table: "OfferRides",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "BookedRides",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "RideId",
                table: "BookedRides",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferRides",
                table: "OfferRides",
                column: "RideId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedRides",
                table: "BookedRides",
                column: "RideId");

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "DBOfferRideRideId", "Name" },
                values: new object[,]
                {
                    { "14d835d8-d3f3-45dd-b6a2-f1fbb9a8929a", null, "Indianapolis" },
                    { "44890943-9f48-4631-9612-1ee88561aa14", null, "Cincinnati" },
                    { "551824fb-ada0-4aa3-b41f-493714235d6c", null, "Madinson" },
                    { "64d53f6b-2479-43fd-a87f-8e927305d7ab", null, "Chicago" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_OfferRides_DBOfferRideRideId",
                table: "Cities",
                column: "DBOfferRideRideId",
                principalTable: "OfferRides",
                principalColumn: "RideId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_OfferRides_DBOfferRideRideId",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferRides",
                table: "OfferRides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookedRides",
                table: "BookedRides");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "14d835d8-d3f3-45dd-b6a2-f1fbb9a8929a");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "44890943-9f48-4631-9612-1ee88561aa14");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "551824fb-ada0-4aa3-b41f-493714235d6c");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "64d53f6b-2479-43fd-a87f-8e927305d7ab");

            migrationBuilder.DropColumn(
                name: "RideId",
                table: "OfferRides");

            migrationBuilder.DropColumn(
                name: "RideId",
                table: "BookedRides");

            migrationBuilder.RenameColumn(
                name: "DBOfferRideRideId",
                table: "Cities",
                newName: "DBOfferRideOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_DBOfferRideRideId",
                table: "Cities",
                newName: "IX_Cities_DBOfferRideOwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "OfferRides",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "BookedRides",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferRides",
                table: "OfferRides",
                column: "OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookedRides",
                table: "BookedRides",
                column: "OwnerId");

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "DBOfferRideOwnerId", "Name" },
                values: new object[,]
                {
                    { "2547cf1e-6949-4f3c-b800-6541bb91c73f", null, "Cincinnati" },
                    { "34518ac6-22a0-44a7-929c-08378da46282", null, "Indianapolis" },
                    { "45ec80f3-3bdf-47ef-b308-b767a43f122a", null, "Chicago" },
                    { "d40ec757-3aba-4c84-b587-322b2cb21057", null, "Madinson" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_OfferRides_DBOfferRideOwnerId",
                table: "Cities",
                column: "DBOfferRideOwnerId",
                principalTable: "OfferRides",
                principalColumn: "OwnerId");
        }
    }
}
