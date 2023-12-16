using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spread.Connect.Infrastructure.Persistance.Admin.Migrations
{
    public partial class initialMigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentHistory",
                columns: table => new
                {
                    PaymentHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UserMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentHistoryType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHistory", x => x.PaymentHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SpreadUser",
                columns: table => new
                {
                    SpreadUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PrimaryPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AlternatePhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    NID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PresentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    College = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LoginAttempts = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RequiresPasswordReset = table.Column<bool>(type: "bit", nullable: false),
                    IsSuspended = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SuspendedUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPasswordReset = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpreadUser", x => x.SpreadUserId);
                });

            migrationBuilder.CreateTable(
                name: "UnregisterBrotherhoodUser",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnregisterBrotherhoodUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "SpreadUserRole",
                columns: table => new
                {
                    SpreadUserRoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    SpreadUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpreadUserRole", x => x.SpreadUserRoleId);
                    table.ForeignKey(
                        name: "FK_SpreadUserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpreadUserRole_SpreadUser_SpreadUserId",
                        column: x => x.SpreadUserId,
                        principalTable: "SpreadUser",
                        principalColumn: "SpreadUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { new Guid("0da3649e-e5ec-4c5b-a9c0-ec3b19f86e0c"), "Integration" },
                    { new Guid("0de3eb68-12aa-4f09-99d7-58ef9ca090c2"), "Driver" },
                    { new Guid("ac870a8c-99ad-4e22-b7f9-1f65283393ea"), "Haulier" },
                    { new Guid("f62abfd9-d8bc-47c2-be01-90a4b90fd7a6"), "Customer" },
                    { new Guid("fc67814d-11c7-486a-90d0-0c79c18de655"), "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistory_TransactionId",
                table: "PaymentHistory",
                column: "TransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                table: "Role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpreadUser_Email",
                table: "SpreadUser",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpreadUser_NID",
                table: "SpreadUser",
                column: "NID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpreadUser_UserName",
                table: "SpreadUser",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpreadUserRole_RoleId",
                table: "SpreadUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SpreadUserRole_SpreadUserId",
                table: "SpreadUserRole",
                column: "SpreadUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentHistory");

            migrationBuilder.DropTable(
                name: "SpreadUserRole");

            migrationBuilder.DropTable(
                name: "UnregisterBrotherhoodUser");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "SpreadUser");
        }
    }
}
