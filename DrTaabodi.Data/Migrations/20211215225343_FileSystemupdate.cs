using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrTaabodi.Data.Migrations
{
    public partial class FileSystemupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileFolderPath",
                table: "FileSystem",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileFolderPath",
                table: "FileSystem");
        }
    }
}
