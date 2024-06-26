using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefactorBEcapstone.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDeleteProps2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Giftees",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Giftees",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ChristmasYears",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ChristmasYears",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ChristmasLists",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ChristmasLists",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Giftees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Giftees");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ChristmasYears");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ChristmasYears");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ChristmasLists");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ChristmasLists");
        }
    }
}
