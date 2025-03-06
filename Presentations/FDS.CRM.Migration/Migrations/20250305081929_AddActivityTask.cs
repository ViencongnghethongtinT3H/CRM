using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FDS.CRM.Migration.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityTask : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityTask_Activities_ActivityId",
                table: "ActivityTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityTask",
                table: "ActivityTask");

            migrationBuilder.RenameTable(
                name: "ActivityTask",
                newName: "ActivityTasks");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityTask_ActivityId",
                table: "ActivityTasks",
                newName: "IX_ActivityTasks_ActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityTasks",
                table: "ActivityTasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityTasks_Activities_ActivityId",
                table: "ActivityTasks",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityTasks_Activities_ActivityId",
                table: "ActivityTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityTasks",
                table: "ActivityTasks");

            migrationBuilder.RenameTable(
                name: "ActivityTasks",
                newName: "ActivityTask");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityTasks_ActivityId",
                table: "ActivityTask",
                newName: "IX_ActivityTask_ActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityTask",
                table: "ActivityTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityTask_Activities_ActivityId",
                table: "ActivityTask",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
