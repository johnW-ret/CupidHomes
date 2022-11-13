using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cupid.Models.Migrations
{
    public partial class AddedSaleNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaleNote",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "getutcdate()"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleNote", x => new { x.SaleId, x.CreatedOn });
                    table.ForeignKey(
                        name: "FK_SaleNote_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleNote");
        }
    }
}
