using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefactorBEcapstone.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteProps1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Gifts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Gifts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Gifts");
        }
    }
}
