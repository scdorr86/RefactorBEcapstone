using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefactorBEcapstone.Migrations
{
    /// <inheritdoc />
    public partial class removeAuditable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ChristmasLists");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ChristmasLists");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ChristmasLists");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ChristmasLists");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ChristmasLists");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ChristmasLists");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ChristmasLists",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ChristmasLists",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "ChristmasLists",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ChristmasLists",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
