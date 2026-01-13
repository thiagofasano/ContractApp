using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatesColunsAndNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnalysisUsage");

            migrationBuilder.RenameColumn(
                name: "Document",
                table: "Users",
                newName: "DocumentPerson");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AnalysisDownloads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AnalysisDownloads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "SubscriptionAnalysisUsage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnalysisCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionAnalysisUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionAnalysisUsage_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionAnalysisUsage_SubscriptionId",
                table: "SubscriptionAnalysisUsage",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionAnalysisUsage");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AnalysisDownloads");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AnalysisDownloads");

            migrationBuilder.RenameColumn(
                name: "DocumentPerson",
                table: "Users",
                newName: "Document");

            migrationBuilder.CreateTable(
                name: "UserAnalysisUsage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    AnalysisCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnalysisUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnalysisUsage_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnalysisUsage_SubscriptionId",
                table: "UserAnalysisUsage",
                column: "SubscriptionId");
        }
    }
}
