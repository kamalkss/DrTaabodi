using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrTaabodi.Data.Migrations
{
    public partial class FileSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileSystem",
                columns: table => new
                {
                    FileSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastWriteTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: true),
                    HasChilds = table.Column<bool>(type: "bit", nullable: true),
                    IsFile = table.Column<bool>(type: "bit", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageRuntimeVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Compilation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileSystem", x => x.FileSystemId);
                    table.ForeignKey(
                        name: "FK_FileSystem_FileSystem_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FileSystem",
                        principalColumn: "FileSystemId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileSystem_ParentId",
                table: "FileSystem",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileSystem");
        }
    }
}
