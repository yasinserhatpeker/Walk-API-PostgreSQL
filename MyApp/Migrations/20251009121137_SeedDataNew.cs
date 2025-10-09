using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1c51f771-3e0f-4031-93b9-b7a9c7506cb2"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7a03fce2-fda2-42ac-a2a3-21d9a434d391"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a29e6dcf-7966-40ef-b322-7716381850a0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6a7051de-7b78-4ee2-a900-3dad73eb6a83"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cfcced9a-694f-4fce-b187-3969616347fd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ea6533a5-1095-44f3-946f-19e327e537ee"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"), null, "Easy", null },
                    { new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"), null, "Medium", null },
                    { new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"), null, "Hard", null }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f808ddcd-b5e5-4d80-b732-1ca523e48434"));

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
                table: "Difficulties",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1c51f771-3e0f-4031-93b9-b7a9c7506cb2"), null, "Hard", null },
                    { new Guid("7a03fce2-fda2-42ac-a2a3-21d9a434d391"), null, "Easy", null },
                    { new Guid("a29e6dcf-7966-40ef-b322-7716381850a0"), null, "Medium", null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6a7051de-7b78-4ee2-a900-3dad73eb6a83"), "New Zealand" },
                    { new Guid("cfcced9a-694f-4fce-b187-3969616347fd"), "New Oakland" },
                    { new Guid("ea6533a5-1095-44f3-946f-19e327e537ee"), "New Jersey" }
                });
        }
    }
}
