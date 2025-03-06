using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FDS.CRM.Migration.Migrations
{
    /// <inheritdoc />
    public partial class ChangeActivityTable : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityAppointments_Users_OwnerId",
                table: "ActivityAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityCalls_Users_OwnerId",
                table: "ActivityCalls");

            migrationBuilder.DropIndex(
                name: "IX_ActivityCalls_OwnerId",
                table: "ActivityCalls");

            migrationBuilder.DropIndex(
                name: "IX_ActivityAppointments_OwnerId",
                table: "ActivityAppointments");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ActivityTask");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ActivityCalls");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "ActivityAppointments");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PaymentMethods",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PaymentMethods",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "ActivityTask",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "ActivityCalls",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "ActivityAppointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCalls_OwnerId",
                table: "ActivityCalls",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityAppointments_OwnerId",
                table: "ActivityAppointments",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityAppointments_Users_OwnerId",
                table: "ActivityAppointments",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityCalls_Users_OwnerId",
                table: "ActivityCalls",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
