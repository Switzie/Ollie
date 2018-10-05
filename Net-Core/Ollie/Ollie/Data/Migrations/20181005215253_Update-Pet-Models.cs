using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ollie.Data.Migrations
{
    public partial class UpdatePetModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Pet");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "User",
                nullable: true);
        }
    }
}
