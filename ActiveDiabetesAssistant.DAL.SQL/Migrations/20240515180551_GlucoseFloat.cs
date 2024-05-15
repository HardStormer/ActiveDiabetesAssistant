using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActiveDiabetesAssistant.DAL.SQL.Migrations
{
    /// <inheritdoc />
    public partial class GlucoseFloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "GlucoseData",
                table: "GlucoseInfos",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "GlucoseData",
                table: "GlucoseInfos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
