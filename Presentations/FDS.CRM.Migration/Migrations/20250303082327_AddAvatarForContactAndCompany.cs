using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FDS.CRM.Migration.Migrations
{
    /// <inheritdoc />
    public partial class AddAvatarForContactAndCompany : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Contacts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Companies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentTerms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Sortby = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserNameCreated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserNameUpdated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Filter = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField1 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ExtraField3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTerms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_BuyPaymentMethodId",
                table: "PurchaseTransactions",
                column: "BuyPaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseTransactions_BuyPaymentTermId",
                table: "PurchaseTransactions",
                column: "BuyPaymentTermId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseTransactions_PaymentMethods_BuyPaymentMethodId",
                table: "PurchaseTransactions",
                column: "BuyPaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseTransactions_PaymentTerms_BuyPaymentTermId",
                table: "PurchaseTransactions",
                column: "BuyPaymentTermId",
                principalTable: "PaymentTerms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseTransactions_PaymentMethods_BuyPaymentMethodId",
                table: "PurchaseTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseTransactions_PaymentTerms_BuyPaymentTermId",
                table: "PurchaseTransactions");

            migrationBuilder.DropTable(
                name: "PaymentTerms");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseTransactions_BuyPaymentMethodId",
                table: "PurchaseTransactions");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseTransactions_BuyPaymentTermId",
                table: "PurchaseTransactions");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Companies");
        }
    }
}
