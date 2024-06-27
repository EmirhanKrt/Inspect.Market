using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Inspect.Market.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationUserRoleRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b1502a1-606f-4ba4-a65d-6d06a2c9e2c8");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Administrator", "ADMINISTRATOR" },
                    { "2", null, "User", "USER" },
                    { "3", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "1c70d621-3058-42e3-a2c1-ee7882df818f", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEL+r0GvyPAGJSs3SgsR1hlsa7xPeSkBS2p27Jzn6WOxSItEeHh03F1usIvPh4J8KOw==", null, false, "d02541d3-9468-4062-abbe-2defd4a8ed7a", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2061), new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2064) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2066), new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2066) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2068), new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2069) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2070), new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2070) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2072), new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2072) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2074), new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2074) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2076), new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2077) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2141), new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2141) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2143), new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2143) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2145), new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2145) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
