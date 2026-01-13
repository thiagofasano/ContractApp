using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelaUserAnalysisUsage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnalysisUsage_Users_UserId",
                table: "UserAnalysisUsage");

            migrationBuilder.DropIndex(
                name: "IX_UserAnalysisUsage_UserId",
                table: "UserAnalysisUsage");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAnalysisUsage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserAnalysisUsage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserAnalysisUsage_UserId",
                table: "UserAnalysisUsage",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnalysisUsage_Users_UserId",
                table: "UserAnalysisUsage",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
