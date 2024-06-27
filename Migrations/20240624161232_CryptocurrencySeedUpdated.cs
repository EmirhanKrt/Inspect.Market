using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspect.Market.Migrations
{
    /// <inheritdoc />
    public partial class CryptocurrencySeedUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9b77a7f-4ebe-450b-96f0-2081f59c450e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "aa70ecc0-78da-40a6-b20c-f4e0d27a6cf1", 0, "0d46a1cb-9cac-437c-844b-d642bdd115bc", "admin@admin.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEFa0jS7y0nVO6qPO29ouPWn4flzzgPQctscbKY0emTwo8DPFyKZ8cU2UtSWKcdqHsA==", null, false, "Administrator", "48c8efb6-eb9c-4d66-b8b4-75efd621bb62", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9282), new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9284) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9285), new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9286) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9288), new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9288) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9289), new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9291), new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9291) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9293), new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9293) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9296), new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9296) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CirculationSupply", "CreatedAt", "Name", "Slug", "Symbol", "TotalSupply", "UpdatedAt" },
                values: new object[] { 144842056384m, new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9297), "Dogecoin", "dogecoin", "DOGE", 144842056384m, new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9298) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CirculationSupply", "CreatedAt", "MaxSupply", "Name", "Slug", "Symbol", "TotalSupply", "UpdatedAt" },
                values: new object[] { 35743190042m, new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9299), 45000000000m, "Cardano", "cardano", "ADA", 36994116265m, new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CirculationSupply", "CreatedAt", "MaxSupply", "Name", "Slug", "Symbol", "TotalSupply", "UpdatedAt" },
                values: new object[] { 2803634836m, new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9301), null, "Fantom", "fantom", "FTM", 3175000000m, new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9301) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa70ecc0-78da-40a6-b20c-f4e0d27a6cf1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d9b77a7f-4ebe-450b-96f0-2081f59c450e", 0, "f30c3706-880a-458d-8bc3-2cd7f1cc99b6", "admin@admin.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEFzU9l0ZZEPE6lDmhAAPgnf7qLVRRHYjFm+XMFNAjiGaj2P/jfRldn8Nyd9OALgo/g==", null, false, "Administrator", "d0b54300-b128-4172-8b6d-5a85b82b7089", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1865), new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1867) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1869), new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1869) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1871), new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1871) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1873), new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1873) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1875), new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1875) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1876), new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1877) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1879), new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1879) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CirculationSupply", "CreatedAt", "Name", "Slug", "Symbol", "TotalSupply", "UpdatedAt" },
                values: new object[] { 2458295528m, new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1881), "Toncoin", "toncoin", "TON", 5108047012m, new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1881) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CirculationSupply", "CreatedAt", "MaxSupply", "Name", "Slug", "Symbol", "TotalSupply", "UpdatedAt" },
                values: new object[] { 144842056384m, new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1882), -1m, "Dogecoin", "dogecoin", "DOGE", 144842056384m, new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1883) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CirculationSupply", "CreatedAt", "MaxSupply", "Name", "Slug", "Symbol", "TotalSupply", "UpdatedAt" },
                values: new object[] { 35743190042m, new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1885), 45000000000m, "Cardano", "cardano", "ADA", 36994116265m, new DateTime(2024, 6, 24, 15, 31, 19, 606, DateTimeKind.Utc).AddTicks(1885) });
        }
    }
}
