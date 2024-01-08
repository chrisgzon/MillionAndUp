using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MU.Infrastructure.Persistence.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    IdOwner = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address_Line1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address_Line2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Birthay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.IdOwner);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    IdProperty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address_Line1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address_Line2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PriceSale = table.Column<double>(type: "float(28)", precision: 28, scale: 6, nullable: false),
                    CodeInternal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    YearBuild = table.Column<int>(type: "int", nullable: false),
                    IdOwner = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.IdProperty);
                    table.ForeignKey(
                        name: "FK_Property_Owner_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "Owner",
                        principalColumn: "IdOwner",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyImage",
                columns: table => new
                {
                    IdPropertyImage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProperty = table.Column<int>(type: "int", nullable: false),
                    File = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImage", x => x.IdPropertyImage);
                    table.ForeignKey(
                        name: "FK_PropertyImage_Property_IdProperty",
                        column: x => x.IdProperty,
                        principalTable: "Property",
                        principalColumn: "IdProperty",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTrace",
                columns: table => new
                {
                    IdPropertyTrace = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameClient = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<double>(type: "float(28)", precision: 28, scale: 6, nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    IdProperty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTrace", x => x.IdPropertyTrace);
                    table.ForeignKey(
                        name: "FK_PropertyTrace_Property_IdProperty",
                        column: x => x.IdProperty,
                        principalTable: "Property",
                        principalColumn: "IdProperty",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Property_IdOwner",
                table: "Property",
                column: "IdOwner");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImage_IdProperty",
                table: "PropertyImage",
                column: "IdProperty");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyTrace_IdProperty",
                table: "PropertyTrace",
                column: "IdProperty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyImage");

            migrationBuilder.DropTable(
                name: "PropertyTrace");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
