using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActiveDiabetesAssistant.DAL.SQL.Migrations
{
    /// <inheritdoc />
    public partial class TableRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlucoseInfoDto_PersonInfoDto_PersonInfoId",
                table: "GlucoseInfoDto");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInfoDto_Users_UserId",
                table: "PersonInfoDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInfoDto",
                table: "PersonInfoDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlucoseInfoDto",
                table: "GlucoseInfoDto");

            migrationBuilder.RenameTable(
                name: "PersonInfoDto",
                newName: "PersonInfos");

            migrationBuilder.RenameTable(
                name: "GlucoseInfoDto",
                newName: "GlucoseInfos");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInfoDto_UserId",
                table: "PersonInfos",
                newName: "IX_PersonInfos_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GlucoseInfoDto_PersonInfoId",
                table: "GlucoseInfos",
                newName: "IX_GlucoseInfos_PersonInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInfos",
                table: "PersonInfos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlucoseInfos",
                table: "GlucoseInfos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GlucoseInfos_PersonInfos_PersonInfoId",
                table: "GlucoseInfos",
                column: "PersonInfoId",
                principalTable: "PersonInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInfos_Users_UserId",
                table: "PersonInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlucoseInfos_PersonInfos_PersonInfoId",
                table: "GlucoseInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInfos_Users_UserId",
                table: "PersonInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInfos",
                table: "PersonInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlucoseInfos",
                table: "GlucoseInfos");

            migrationBuilder.RenameTable(
                name: "PersonInfos",
                newName: "PersonInfoDto");

            migrationBuilder.RenameTable(
                name: "GlucoseInfos",
                newName: "GlucoseInfoDto");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInfos_UserId",
                table: "PersonInfoDto",
                newName: "IX_PersonInfoDto_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_GlucoseInfos_PersonInfoId",
                table: "GlucoseInfoDto",
                newName: "IX_GlucoseInfoDto_PersonInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInfoDto",
                table: "PersonInfoDto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlucoseInfoDto",
                table: "GlucoseInfoDto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GlucoseInfoDto_PersonInfoDto_PersonInfoId",
                table: "GlucoseInfoDto",
                column: "PersonInfoId",
                principalTable: "PersonInfoDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInfoDto_Users_UserId",
                table: "PersonInfoDto",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
