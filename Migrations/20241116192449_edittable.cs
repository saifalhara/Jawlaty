using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jawlaty.Migrations
{
    /// <inheritdoc />
    public partial class edittable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Chinese",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Glutenfree",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Indian",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Italian",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Mexican",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MiAmeicanddle",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Middle",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeInput",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Timeout",
                table: "Restaurants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Vagen",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Vegetarian",
                table: "Restaurants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HASPOOL",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HASWIFI",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasGym",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRestaurant",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSpa",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Parking",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CheakAge",
                table: "Entertainments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasCinema",
                table: "Entertainments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasLiveMusic",
                table: "Entertainments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasShopping",
                table: "Entertainments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSport",
                table: "Entertainments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasTheater",
                table: "Entertainments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Spa",
                table: "Entertainments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fd07073-93c7-42ce-bfda-517946875cff", "AQAAAAIAAYagAAAAEF3/9pJspULvDbueG7Qsexz6L0rPuINStYLXfepkgsrd+QvqsNofdh6+qhMqixmO8w==", "294fb466-360e-4c40-85c1-83d8b260a778" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chinese",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Glutenfree",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Indian",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Italian",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Mexican",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MiAmeicanddle",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Middle",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "TimeInput",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Timeout",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Vagen",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Vegetarian",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "HASPOOL",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HASWIFI",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HasGym",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HasRestaurant",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HasSpa",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Parking",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CheakAge",
                table: "Entertainments");

            migrationBuilder.DropColumn(
                name: "HasCinema",
                table: "Entertainments");

            migrationBuilder.DropColumn(
                name: "HasLiveMusic",
                table: "Entertainments");

            migrationBuilder.DropColumn(
                name: "HasShopping",
                table: "Entertainments");

            migrationBuilder.DropColumn(
                name: "HasSport",
                table: "Entertainments");

            migrationBuilder.DropColumn(
                name: "HasTheater",
                table: "Entertainments");

            migrationBuilder.DropColumn(
                name: "Spa",
                table: "Entertainments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ede2c54-a1c3-4c19-ad7e-cc2aba9a6857", "AQAAAAIAAYagAAAAEDOE17tOQ64Z3PF9ebyF3xH8I1psgg0qhL3sPmfTykZvOJIfqZzJ6cby9PysuzdqIw==", "2622de32-977b-44f1-a3b0-532cd5766293" });
        }
    }
}
