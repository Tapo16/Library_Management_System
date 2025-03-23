using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblad",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblad", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "tblbook",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PublisherName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Dop = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    Cid = table.Column<int>(type: "int", nullable: false),
                    BookFilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblbook", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "tblcat",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcat", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "tbluser",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SecurityQuestion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SecurityAns = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbluser", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "tblBorrwedBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBorrwedBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblBorrwedBook_tblbook_BookId",
                        column: x => x.BookId,
                        principalTable: "tblbook",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblBorrwedBook_tbluser_UserEmail",
                        column: x => x.UserEmail,
                        principalTable: "tbluser",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblad",
                columns: new[] { "Email", "Password" },
                values: new object[,]
                {
                    { "admin123@gmail.com", "Ad@123" },
                    { "adminer456@gmail.com", "Ad@456" }
                });

            migrationBuilder.InsertData(
                table: "tblcat",
                columns: new[] { "CategoryId", "CatName" },
                values: new object[,]
                {
                    { 1, "History" },
                    { 2, "Cultural" },
                    { 3, "Mythology" },
                    { 4, "Self Improvement" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblBorrwedBook_BookId",
                table: "tblBorrwedBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_tblBorrwedBook_UserEmail",
                table: "tblBorrwedBook",
                column: "UserEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblad");

            migrationBuilder.DropTable(
                name: "tblBorrwedBook");

            migrationBuilder.DropTable(
                name: "tblcat");

            migrationBuilder.DropTable(
                name: "tblbook");

            migrationBuilder.DropTable(
                name: "tbluser");
        }
    }
}
