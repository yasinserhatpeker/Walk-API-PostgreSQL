using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataBrandNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0269afa2-4702-4f14-b3c7-835749324850"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6a0452d9-5e0c-4354-8672-36736c7a3eaf"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cc52959b-75f5-4f95-84bb-92508cec0b5a"));

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48414"), "New Zealand" },
                    { new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48424"), "New Oakland" },
                    { new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48494"), "New Jersey" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48414"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48424"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48494"));

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0269afa2-4702-4f14-b3c7-835749324850"), "New Oakland" },
                    { new Guid("6a0452d9-5e0c-4354-8672-36736c7a3eaf"), "New Jersey" },
                    { new Guid("cc52959b-75f5-4f95-84bb-92508cec0b5a"), "New Zealand" }
                });
        }
    }
}
