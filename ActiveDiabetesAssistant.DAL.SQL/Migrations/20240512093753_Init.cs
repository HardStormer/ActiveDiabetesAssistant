using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActiveDiabetesAssistant.DAL.SQL.Migrations
{
	/// <inheritdoc />
	public partial class Init : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uuid", nullable: false),
					Name = table.Column<string>(type: "text", nullable: true),
					Login = table.Column<string>(type: "text", nullable: false),
					Password = table.Column<string>(type: "text", nullable: false),
					Bio = table.Column<string>(type: "text", nullable: false),
					TokenExpiredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
					CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
					IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}