using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkShop.Model.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CtreatingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    ModifingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifierId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DescriptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPrice = table.Column<double>(type: "float", nullable: false),
                    HasAvailableStock = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: false),
                    DeletingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CtreatingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<long>(type: "bigint", nullable: false),
                    ModifingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifierId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
