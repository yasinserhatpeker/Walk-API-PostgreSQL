using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Difficulties",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Difficulties",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
