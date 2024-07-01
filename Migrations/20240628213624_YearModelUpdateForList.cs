using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RefactorBEcapstone.Migrations
{
    /// <inheritdoc />
    public partial class YearModelUpdateForList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ListName = table.Column<string>(type: "text", nullable: false),
                    GifteeId = table.Column<int>(type: "integer", nullable: false),
                    ChristmasYearId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ListTotal = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListResponse_ChristmasYears_ChristmasYearId",
                        column: x => x.ChristmasYearId,
                        principalTable: "ChristmasYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListResponse_ChristmasYearId",
                table: "ListResponse",
                column: "ChristmasYearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListResponse");
        }
    }
}
