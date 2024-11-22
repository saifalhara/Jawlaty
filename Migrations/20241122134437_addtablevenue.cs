using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jawlaty.Migrations
{
    /// <inheritdoc />
    public partial class addtablevenue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Art",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CheakAge",
                table: "Venue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Chinese",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Food",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Glutenfree",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HASPOOL",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HASWIFI",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasCinema",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasGym",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasLiveMusic",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRestaurant",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasShopping",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSpa",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSport",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasTheater",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "History",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Indian",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Italian",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Mexican",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MiAmeicanddle",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Middle",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Parking",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Shopping",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Spa",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sports",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeInput",
                table: "Venue",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Timeout",
                table: "Venue",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Vagen",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Vegetarian",
                table: "Venue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01d5eb85-16de-4f3c-9f16-01c5f774cca3", "AQAAAAIAAYagAAAAELxqLG+fSHfeXMdPlY7vfGeYcfklNpY4pM5W4n9bJN2B8ykhIoM7FzlQiHSCibAKPA==", "56741130-6a75-41e2-8e59-592f4e35749d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Art",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "CheakAge",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Chinese",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Food",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Glutenfree",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "HASPOOL",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "HASWIFI",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "HasCinema",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "HasGym",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "HasLiveMusic",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "HasRestaurant",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "HasShopping",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "HasSpa",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "HasSport",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "HasTheater",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "History",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Indian",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Italian",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Mexican",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "MiAmeicanddle",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Middle",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Parking",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Shopping",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Spa",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Sports",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "TimeInput",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Timeout",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Vagen",
                table: "Venue");

            migrationBuilder.DropColumn(
                name: "Vegetarian",
                table: "Venue");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2b896dd-c8bb-4dea-922d-641306b3796e", "AQAAAAIAAYagAAAAEKTDFmo205Cj0buEbRYCLmHn3/7wctVVOfaiywleStloI5NwJxkDxCdZivaii5fVeQ==", "d004e5f1-2ff3-49a6-9849-7ab8f6b8c8a2" });
        }
    }
}
