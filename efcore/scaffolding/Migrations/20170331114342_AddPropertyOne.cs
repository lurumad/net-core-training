using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace scaffolding.Migrations
{
    public partial class AddPropertyOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertyOne",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyOne",
                table: "Blogs");
        }
    }
}
