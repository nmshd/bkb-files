using Microsoft.EntityFrameworkCore.Migrations;

namespace Files.Infrastructure.Persistence.Database.Migrations
{
    public partial class MakeOwnerNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "FileMetadata",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(36)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "FileMetadata",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(36)",
                oldNullable: true);
        }
    }
}
