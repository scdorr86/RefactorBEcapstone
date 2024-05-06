using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RefactorBEcapstone.Migrations
{
    /// <inheritdoc />
    public partial class updateGiftGiftee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Giftees");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Giftees");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Giftees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Giftees");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Giftees");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Giftees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Gifts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Gifts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Gifts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Gifts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Giftees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Giftees",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Giftees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Giftees",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
