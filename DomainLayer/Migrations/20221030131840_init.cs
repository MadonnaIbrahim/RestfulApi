using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ImgURL = table.Column<string>(nullable: true),
                    CateogryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CateogryId",
                        column: x => x.CateogryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CateogryId",
                table: "Product",
                column: "CateogryId");

            migrationBuilder.Sql(@"USE [RestfulActivity]
GO
INSERT [dbo].[Category] ([Id], [CreationDate], [ModificationDate], [Name]) VALUES (N'e2c68c7b-ab79-4ae2-a201-49296373cf85', CAST(N'2022-10-30T15:20:11.3330000' AS DateTime2), CAST(N'2022-10-30T15:20:11.3330000' AS DateTime2), N'Category2')
GO
INSERT [dbo].[Category] ([Id], [CreationDate], [ModificationDate], [Name]) VALUES (N'5b3832b3-a9e3-4151-a5f9-a55f7f5b2256', CAST(N'2022-10-30T15:20:11.3330000' AS DateTime2), CAST(N'2022-10-30T15:20:11.3330000' AS DateTime2), N'Category1')
GO
INSERT [dbo].[Category] ([Id], [CreationDate], [ModificationDate], [Name]) VALUES (N'd2b2e08f-2ffc-488b-85a9-f6ed4589ed7f', CAST(N'2022-10-30T15:20:11.3330000' AS DateTime2), CAST(N'2022-10-30T15:20:11.3330000' AS DateTime2), N'Category3')
GO
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
