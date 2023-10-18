using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDifficultiestoDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("24519670-e2cf-487f-920e-7df823ff0035"), "Hard" },
                    { new Guid("344d623f-88f7-46e4-a3a1-8a6fe433b040"), "Medium" },
                    { new Guid("d66f3123-77d1-4109-b4ec-f11a10dafeae"), "Easy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("24519670-e2cf-487f-920e-7df823ff0035"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("344d623f-88f7-46e4-a3a1-8a6fe433b040"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d66f3123-77d1-4109-b4ec-f11a10dafeae"));
        }
    }
}
