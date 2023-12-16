using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spread.Connect.Infrastructure.Persistance.Admin.Migrations
{
    public partial class AddImagePathInSpreadUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "SpreadUser",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "SpreadUser");
        }
    }
}
