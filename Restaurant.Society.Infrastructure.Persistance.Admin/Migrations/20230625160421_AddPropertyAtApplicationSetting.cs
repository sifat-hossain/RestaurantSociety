using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spread.Connect.Infrastructure.Persistance.Admin.Migrations
{
    public partial class AddPropertyAtApplicationSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentHistory");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ApplicationSettings",
                newName: "Value3");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ApplicationSettings",
                newName: "ApplicationSettingId");

            migrationBuilder.AddColumn<string>(
                name: "Value1",
                table: "ApplicationSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value2",
                table: "ApplicationSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ApplicationSettings",
                keyColumn: "ApplicationSettingId",
                keyValue: 1,
                columns: new[] { "Value1", "Value3" },
                values: new object[] { "0da3649e-e5ec-4c5b-a9c0-ec3b19f86e0c", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value1",
                table: "ApplicationSettings");

            migrationBuilder.DropColumn(
                name: "Value2",
                table: "ApplicationSettings");

            migrationBuilder.RenameColumn(
                name: "Value3",
                table: "ApplicationSettings",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "ApplicationSettingId",
                table: "ApplicationSettings",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "PaymentHistory",
                columns: table => new
                {
                    PaymentHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PaymentHistoryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHistory", x => x.PaymentHistoryId);
                });

            migrationBuilder.UpdateData(
                table: "ApplicationSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Value",
                value: "0da3649e-e5ec-4c5b-a9c0-ec3b19f86e0c");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistory_TransactionId",
                table: "PaymentHistory",
                column: "TransactionId",
                unique: true);
        }
    }
}
