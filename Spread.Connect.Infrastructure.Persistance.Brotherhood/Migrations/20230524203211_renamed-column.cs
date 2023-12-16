using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spread.Connect.Infrastructure.Persistance.Brotherhood.Migrations
{
    public partial class renamedcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentUrl",
                table: "RegistrationPayments",
                newName: "PaymentLink");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentLink",
                table: "RegistrationPayments",
                newName: "PaymentUrl");
        }
    }
}
