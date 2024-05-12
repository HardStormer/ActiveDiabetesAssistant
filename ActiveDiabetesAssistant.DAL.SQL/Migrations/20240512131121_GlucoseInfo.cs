using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActiveDiabetesAssistant.DAL.SQL.Migrations
{
    /// <inheritdoc />
    public partial class GlucoseInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Users",
                newName: "Email");

            migrationBuilder.CreateTable(
                name: "PersonInfoDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    DiabetesType = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInfoDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonInfoDto_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GlucoseInfoDto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GlucoseData = table.Column<int>(type: "integer", nullable: false),
                    StepsCount = table.Column<int>(type: "integer", nullable: true),
                    PersonInfoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlucoseInfoDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlucoseInfoDto_PersonInfoDto_PersonInfoId",
                        column: x => x.PersonInfoId,
                        principalTable: "PersonInfoDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlucoseInfoDto_PersonInfoId",
                table: "GlucoseInfoDto",
                column: "PersonInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInfoDto_UserId",
                table: "PersonInfoDto",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlucoseInfoDto");

            migrationBuilder.DropTable(
                name: "PersonInfoDto");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Login");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: true);
        }
    }
}
