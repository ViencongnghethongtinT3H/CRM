using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FDS.CRM.Migration.Migrations
{
    /// <inheritdoc />
    public partial class ChangeContact : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_CommonSettings_CommonSettingId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CommonSettingId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CommonSettingId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Industry",
                table: "Contacts",
                newName: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_IndustryId",
                table: "Contacts",
                column: "IndustryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_CommonSettings_IndustryId",
                table: "Contacts",
                column: "IndustryId",
                principalTable: "CommonSettings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_CommonSettings_IndustryId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_IndustryId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "IndustryId",
                table: "Contacts",
                newName: "Industry");

            migrationBuilder.AddColumn<Guid>(
                name: "CommonSettingId",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CommonSettingId",
                table: "Contacts",
                column: "CommonSettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_CommonSettings_CommonSettingId",
                table: "Contacts",
                column: "CommonSettingId",
                principalTable: "CommonSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
