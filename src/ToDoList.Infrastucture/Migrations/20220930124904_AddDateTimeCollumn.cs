using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class AddDateTimeCollumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ToDo");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "ToDo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ToDo",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "ToDo");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ToDo");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ToDo",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
