using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spread.Connect.Infrastructure.Persistance.Brotherhood.Migrations
{
    public partial class RenamedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentRequests",
                table: "PaymentRequests");

            migrationBuilder.RenameTable(
                name: "PaymentRequests",
                newName: "PaymentRequest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentRequest",
                table: "PaymentRequest",
                column: "PaymentRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentRequest",
                table: "PaymentRequest");

            migrationBuilder.RenameTable(
                name: "PaymentRequest",
                newName: "PaymentRequests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentRequests",
                table: "PaymentRequests",
                column: "PaymentRequestId");
        }
    }
}
