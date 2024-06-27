using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inspect.Market.Migrations
{
    /// <inheritdoc />
    public partial class DecimalCountAddedToCryptocurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey("PK_AspNetUserTokens", "AspNetUserTokens");
            migrationBuilder.DropPrimaryKey("PK_AspNetUserLogins", "AspNetUserLogins");

            migrationBuilder.AddColumn<decimal>(
                name: "DecimalCount",
                table: "Cryptocurrencies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                columns: new[] { "CreatedAt", "DecimalCount", "MaxSupply", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8016), 2m, -1m, new DateTime(2024, 6, 25, 21, 22, 57, 934, DateTimeKind.Utc).AddTicks(8016) });

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

            migrationBuilder.AddPrimaryKey("PK_AspNetUserTokens", "AspNetUserTokens", new string[] { "UserId", "LoginProvider", "Name" });
            migrationBuilder.AddPrimaryKey("PK_AspNetUserLogins", "AspNetUserLogins", new string[] { "LoginProvider", "ProviderKey" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DecimalCount",
                table: "Cryptocurrencies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c70d621-3058-42e3-a2c1-ee7882df818f", "AQAAAAIAAYagAAAAEL+r0GvyPAGJSs3SgsR1hlsa7xPeSkBS2p27Jzn6WOxSItEeHh03F1usIvPh4J8KOw==", "d02541d3-9468-4062-abbe-2defd4a8ed7a" });

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
                columns: new[] { "CreatedAt", "MaxSupply", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2066), null, new DateTime(2024, 6, 24, 23, 58, 50, 367, DateTimeKind.Utc).AddTicks(2066) });

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
        }
    }
}
