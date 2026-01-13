using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Users_UserId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnalysisUsage_Plans_PlanId",
                table: "UserAnalysisUsage");

            migrationBuilder.DropIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Plans_UserId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Guid1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "PaymentToken",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "YearMonth",
                table: "UserAnalysisUsage",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "UserAnalysisUsage",
                newName: "SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnalysisUsage_PlanId",
                table: "UserAnalysisUsage",
                newName: "IX_UserAnalysisUsage_SubscriptionId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Plans",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ProcessedAt",
                table: "Payments",
                newName: "PaidAt");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AnalysisCount",
                table: "UserAnalysisUsage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "UserAnalysisUsage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MonthlyAnalysisLimit",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentToken",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Users_UserId",
                table: "Subscriptions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnalysisUsage_Subscriptions_SubscriptionId",
                table: "UserAnalysisUsage",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Users_UserId",
                table: "Subscriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnalysisUsage_Subscriptions_SubscriptionId",
                table: "UserAnalysisUsage");

            migrationBuilder.DropIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AnalysisCount",
                table: "UserAnalysisUsage");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "UserAnalysisUsage");

            migrationBuilder.DropColumn(
                name: "MonthlyAnalysisLimit",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PaymentToken",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "UserAnalysisUsage",
                newName: "YearMonth");

            migrationBuilder.RenameColumn(
                name: "SubscriptionId",
                table: "UserAnalysisUsage",
                newName: "PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnalysisUsage_SubscriptionId",
                table: "UserAnalysisUsage",
                newName: "IX_UserAnalysisUsage_PlanId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Plans",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PaidAt",
                table: "Payments",
                newName: "ProcessedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Guid",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid1",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "isActive",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentToken",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plans_UserId",
                table: "Plans",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Users_UserId",
                table: "Plans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnalysisUsage_Plans_PlanId",
                table: "UserAnalysisUsage",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
