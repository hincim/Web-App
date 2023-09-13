﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.Data.Migrations
{
    public partial class AddColumnProductIsHome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isApproved",
                table: "Products",
                newName: "IsApproved");

            migrationBuilder.AddColumn<bool>(
                name: "IsHome",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHome",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Products",
                newName: "isApproved");
        }
    }
}
