using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrixusJa.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "username", "created_at", "password" },
                values: new object[,]
                {
                    { "crixus", new DateTime(2022, 11, 8, 21, 47, 8, 660, DateTimeKind.Local).AddTicks(8976), "international" },
                    { "mgenius", new DateTime(2022, 11, 8, 21, 47, 8, 660, DateTimeKind.Local).AddTicks(8966), "password" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "username",
                keyValue: "crixus");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "username",
                keyValue: "mgenius");
        }
    }
}
