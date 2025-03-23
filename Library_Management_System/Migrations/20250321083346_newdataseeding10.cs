using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class newdataseeding10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeactivated",
                table: "tbluser");

            migrationBuilder.AddColumn<bool>(
                name: "isDeactivated",
                table: "tblBorrwedBook",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeactivated",
                table: "tblBorrwedBook");

            migrationBuilder.AddColumn<bool>(
                name: "isDeactivated",
                table: "tbluser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
