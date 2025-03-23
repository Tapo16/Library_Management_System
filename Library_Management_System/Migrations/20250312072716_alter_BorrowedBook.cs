using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class alter_BorrowedBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblBorrwedBook_tblbook_BookId",
                table: "tblBorrwedBook");

            migrationBuilder.DropForeignKey(
                name: "FK_tblBorrwedBook_tbluser_UserEmail",
                table: "tblBorrwedBook");

            migrationBuilder.DropIndex(
                name: "IX_tblBorrwedBook_BookId",
                table: "tblBorrwedBook");

            migrationBuilder.DropIndex(
                name: "IX_tblBorrwedBook_UserEmail",
                table: "tblBorrwedBook");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "tblBorrwedBook");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "tblBorrwedBook",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "tblBorrwedBook",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "tblBorrwedBook",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_tblBorrwedBook_BookId",
                table: "tblBorrwedBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBorrwedBook_UserEmail",
                table: "tblBorrwedBook",
                column: "UserEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_tblBorrwedBook_tblbook_BookId",
                table: "tblBorrwedBook",
                column: "BookId",
                principalTable: "tblbook",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblBorrwedBook_tbluser_UserEmail",
                table: "tblBorrwedBook",
                column: "UserEmail",
                principalTable: "tbluser",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
