using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrTaabodi.Data.Migrations
{
    public partial class Main : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Question",
                table: "QnATbl",
                type: "nvarchar(2500)",
                maxLength: 2500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "QnATbl",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<Guid>(
                name: "MetaTblMetaId",
                table: "PstTbl",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MetaTbl",
                columns: table => new
                {
                    MetaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MetaKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetaValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaTbl", x => x.MetaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PstTbl_MetaTblMetaId",
                table: "PstTbl",
                column: "MetaTblMetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PstTbl_MetaTbl_MetaTblMetaId",
                table: "PstTbl",
                column: "MetaTblMetaId",
                principalTable: "MetaTbl",
                principalColumn: "MetaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PstTbl_MetaTbl_MetaTblMetaId",
                table: "PstTbl");

            migrationBuilder.DropTable(
                name: "MetaTbl");

            migrationBuilder.DropIndex(
                name: "IX_PstTbl_MetaTblMetaId",
                table: "PstTbl");

            migrationBuilder.DropColumn(
                name: "MetaTblMetaId",
                table: "PstTbl");

            migrationBuilder.AlterColumn<string>(
                name: "Question",
                table: "QnATbl",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2500)",
                oldMaxLength: 2500);

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "QnATbl",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
