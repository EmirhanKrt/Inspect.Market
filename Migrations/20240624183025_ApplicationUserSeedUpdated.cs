using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspect.Market.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUserSeedUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa70ecc0-78da-40a6-b20c-f4e0d27a6cf1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2b1502a1-606f-4ba4-a65d-6d06a2c9e2c8", 0, "81e4db9a-cf37-4935-b8c1-bf190af3814f", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEIH2JQO5qpzqZtWVtQ860nlJhTUnqhDIE3up+FVgQSUHhWsLdVFNNVvnGqUEUJaDkg==", null, false, "Administrator", "fc6477ef-d43a-4837-a2aa-f21f3c26d415", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8786), new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8788) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8789), new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8791), new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8792) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8793), new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8794) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8795), new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8796) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8797), new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8798) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8799), new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8801), new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8801) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8803), new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8803) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8805), new DateTime(2024, 6, 24, 18, 30, 24, 805, DateTimeKind.Utc).AddTicks(8805) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b1502a1-606f-4ba4-a65d-6d06a2c9e2c8");

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9297), new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9298) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9299), new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9301), new DateTime(2024, 6, 24, 16, 12, 31, 733, DateTimeKind.Utc).AddTicks(9301) });
        }
    }
}
