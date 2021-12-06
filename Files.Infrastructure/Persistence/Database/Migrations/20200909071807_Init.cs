using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Files.Infrastructure.Persistence.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileMetadata",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(20)", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "char(36)", nullable: false),
                    CreatedByDevice = table.Column<string>(type: "char(20)", nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(type: "char(36)", nullable: false),
                    ModifiedByDevice = table.Column<string>(type: "char(20)", nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<string>(type: "char(36)", nullable: true),
                    DeletedByDevice = table.Column<string>(type: "char(20)", nullable: true),
                    Owner = table.Column<string>(type: "char(36)", nullable: false),
                    OwnerSignature = table.Column<byte[]>(nullable: false),
                    CipherSize = table.Column<long>(nullable: false),
                    CipherHash = table.Column<byte[]>(nullable: false),
                    ExpiresAt = table.Column<DateTime>(nullable: false),
                    EncryptedProperties = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadata", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileMetadata_CreatedBy",
                table: "FileMetadata",
                column: "CreatedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileMetadata");
        }
    }
}
