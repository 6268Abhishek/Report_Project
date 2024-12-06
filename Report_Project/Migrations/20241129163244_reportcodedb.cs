using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Report_Project.Migrations
{
    /// <inheritdoc />
    public partial class reportcodedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reports",
                columns: table => new
                {
                    Report_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Report_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Receiver_active_Inactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reports", x => x.Report_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reports");
        }
    }
}
