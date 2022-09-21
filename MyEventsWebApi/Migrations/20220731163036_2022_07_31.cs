using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyEventsEntityFrameworkDb.Migrations
{
    public partial class _2022_07_31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageBytes",
                table: "Images",
                type: "image",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBytes",
                table: "Images");
        }
    }
}
