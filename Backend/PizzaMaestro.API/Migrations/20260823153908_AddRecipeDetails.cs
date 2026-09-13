using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaMaestro.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BallWeight",
                table: "Recipes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Balls",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Recipes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "FlourGrams",
                table: "Recipes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FridgeHours",
                table: "Recipes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FridgeTemp",
                table: "Recipes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RoomHours",
                table: "Recipes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RoomTemp",
                table: "Recipes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SaltGrams",
                table: "Recipes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SourdoughFlourGrams",
                table: "Recipes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SourdoughWaterGrams",
                table: "Recipes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalDoughWeight",
                table: "Recipes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalHours",
                table: "Recipes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WaterGrams",
                table: "Recipes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "YeastGrams",
                table: "Recipes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "YeastLabel",
                table: "Recipes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BallWeight", "Balls", "CreatedAt", "FlourGrams", "FridgeHours", "FridgeTemp", "RoomHours", "RoomTemp", "SaltGrams", "SourdoughFlourGrams", "SourdoughWaterGrams", "TotalDoughWeight", "TotalHours", "WaterGrams", "YeastGrams", "YeastLabel" },
                values: new object[] { 0.0, 0, new DateTime(2026, 8, 23, 15, 39, 8, 255, DateTimeKind.Utc).AddTicks(5990), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, "" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BallWeight", "Balls", "CreatedAt", "FlourGrams", "FridgeHours", "FridgeTemp", "RoomHours", "RoomTemp", "SaltGrams", "SourdoughFlourGrams", "SourdoughWaterGrams", "TotalDoughWeight", "TotalHours", "WaterGrams", "YeastGrams", "YeastLabel" },
                values: new object[] { 0.0, 0, new DateTime(2026, 8, 23, 15, 39, 8, 255, DateTimeKind.Utc).AddTicks(5993), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, "" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BallWeight", "Balls", "CreatedAt", "FlourGrams", "FridgeHours", "FridgeTemp", "RoomHours", "RoomTemp", "SaltGrams", "SourdoughFlourGrams", "SourdoughWaterGrams", "TotalDoughWeight", "TotalHours", "WaterGrams", "YeastGrams", "YeastLabel" },
                values: new object[] { 0.0, 0, new DateTime(2026, 8, 23, 15, 39, 8, 255, DateTimeKind.Utc).AddTicks(5995), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BallWeight",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Balls",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "FlourGrams",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "FridgeHours",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "FridgeTemp",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RoomHours",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RoomTemp",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "SaltGrams",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "SourdoughFlourGrams",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "SourdoughWaterGrams",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "TotalDoughWeight",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "WaterGrams",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "YeastGrams",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "YeastLabel",
                table: "Recipes");
        }
    }
}
