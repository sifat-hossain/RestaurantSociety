using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spread.Connect.Infrastructure.Persistance.Brotherhood.Migrations
{
    public partial class RenamedTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrationPayments",
                table: "RegistrationPayments");

            migrationBuilder.RenameTable(
                name: "RegistrationPayments",
                newName: "PaymentRequests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentRequests",
                table: "PaymentRequests",
                column: "PaymentRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentRequests",
                table: "PaymentRequests");

            migrationBuilder.RenameTable(
                name: "PaymentRequests",
                newName: "RegistrationPayments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrationPayments",
                table: "RegistrationPayments",
                column: "PaymentRequestId");
        }
    }
}
