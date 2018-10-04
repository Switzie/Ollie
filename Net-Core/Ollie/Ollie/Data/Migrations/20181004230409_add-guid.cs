using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ollie.Data.Migrations
{
    public partial class addguid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Pet",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<Guid>(
                name: "PetGuid",
                table: "Pet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PetGuid",
                table: "Pet");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Pet",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
