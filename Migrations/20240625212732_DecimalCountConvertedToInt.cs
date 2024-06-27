using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspect.Market.Migrations
{
    /// <inheritdoc />
    public partial class DecimalCountConvertedToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DecimalCount",
                table: "Cryptocurrencies",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6da3ce2-895a-45c1-9563-dae6312c26df", "AQAAAAIAAYagAAAAECxTqNvv4mkYra0aWMiDnPybeIvsbRJ19xmTXA+1GFGgfpkvxUt0Z2lIlvM5g6LNmQ==", "85bfd2a6-7131-4819-938b-a61c5c92f164" });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8745), 2, new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8752), 2, new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8752) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8754), 4, new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8754) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8756), 1, new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8756) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8758), 2, new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8758) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8760), 4, new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8762), 4, new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8762) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8764), 5, new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8764) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8766), 4, new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8766) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8767), 4, new DateTime(2024, 6, 25, 21, 27, 31, 892, DateTimeKind.Utc).AddTicks(8768) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "DecimalCount",
                table: "Cryptocurrencies",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b42421fa-1ee1-4c94-9882-195c69b7e21b", "AQAAAAIAAYagAAAAEH4YGVY1mrBXOcdaX4gY+TzQxfrhFvW3z+v4zWidnU/PxxdbqtxvfcpPHMkb2QaJOg==", "a017921c-341b-4c1c-843f-7f54f8397d36" });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8008), 2m, new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8012) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8016), 2m, new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8016) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8018), 4m, new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8019) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8021), 1m, new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8022) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8024), 2m, new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8024) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8026), 4m, new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8026) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8028), 4m, new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8028) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8030), 5m, new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8030) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8032), 4m, new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8032) });

            migrationBuilder.UpdateData(
                table: "Cryptocurrencies",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "DecimalCount", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8034), 4m, new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8034) });
        }
    }
}
