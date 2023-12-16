using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spread.Connect.Infrastructure.Persistance.Admin.Migrations
{
    public partial class ModifySpreadUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("ac870a8c-99ad-4e22-b7f9-1f65283393ea"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("f62abfd9-d8bc-47c2-be01-90a4b90fd7a6"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("0da3649e-e5ec-4c5b-a9c0-ec3b19f86e0c"),
                column: "Name",
                value: "User");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("0de3eb68-12aa-4f09-99d7-58ef9ca090c2"),
                column: "Name",
                value: "Finance");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Name" },
                values: new object[] { new Guid("fc67814d-11c7-486a-90d0-0c79c18de656"), "SuperAdmin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("fc67814d-11c7-486a-90d0-0c79c18de656"));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("0da3649e-e5ec-4c5b-a9c0-ec3b19f86e0c"),
                column: "Name",
                value: "Integration");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: new Guid("0de3eb68-12aa-4f09-99d7-58ef9ca090c2"),
                column: "Name",
                value: "Driver");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Inactive", "Name" },
                values: new object[,]
                {
                    { new Guid("ac870a8c-99ad-4e22-b7f9-1f65283393ea"), false, "Haulier" },
                    { new Guid("f62abfd9-d8bc-47c2-be01-90a4b90fd7a6"), false, "Customer" }
                });
        }
    }
}
