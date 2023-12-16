using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spread.Connect.Infrastructure.Persistance.Brotherhood.Migrations
{
    public partial class PaymentHistoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "RegistrationPayments");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "RegistrationPayments",
                newName: "Vendor");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "RegistrationPayments",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "RegistrationPayments",
                newName: "DateTime");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RegistrationPayments",
                newName: "PaymentRequestId");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentLink",
                table: "RegistrationPayments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RegistrationPayments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "RegistrationPayments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Campaign",
                table: "RegistrationPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentAmount",
                table: "RegistrationPayments",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "RegistrationPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RegistrationPayments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentHistory",
                columns: table => new
                {
                    PaymentHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StoreAmount = table.Column<int>(type: "int", nullable: false),
                    TrxId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Campaign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHistory", x => x.PaymentHistoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistory_TrxId",
                table: "PaymentHistory",
                column: "TrxId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentHistory");

            migrationBuilder.DropColumn(
                name: "Campaign",
                table: "RegistrationPayments");

            migrationBuilder.DropColumn(
                name: "PaymentAmount",
                table: "RegistrationPayments");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "RegistrationPayments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RegistrationPayments");

            migrationBuilder.RenameColumn(
                name: "Vendor",
                table: "RegistrationPayments",
                newName: "Result");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "RegistrationPayments",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "RegistrationPayments",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "PaymentRequestId",
                table: "RegistrationPayments",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentLink",
                table: "RegistrationPayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RegistrationPayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "RegistrationPayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Amount",
                table: "RegistrationPayments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
