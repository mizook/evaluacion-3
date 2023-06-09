using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eval_3.Migrations
{
    /// <inheritdoc />
    public partial class EvaluacionMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    faculty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_last_reserve = table.Column<DateTime>(type: "datetime2", nullable: true),
                    cant_reserves_last_mont = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reservesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                    table.ForeignKey(
                        name: "FK_Books_Users_reservesid",
                        column: x => x.reservesid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Book_reservations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    date_reserve = table.Column<DateTime>(type: "datetime2", nullable: true),
                    userid = table.Column<int>(type: "int", nullable: true),
                    bookid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Book_reservations_Books_bookid",
                        column: x => x.bookid,
                        principalTable: "Books",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Book_reservations_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Book_reservations",
                columns: new[] { "id", "book_id", "bookid", "code", "date_reserve", "user_id", "userid" },
                values: new object[,]
                {
                    { 1, 1, null, "cgLFZuT6Y8q7cf0byW", new DateTime(2023, 6, 9, 19, 37, 54, 0, DateTimeKind.Local), 1, null },
                    { 2, 2, null, "6xvGgDMVCYy28epj83P9BUOd", new DateTime(2023, 6, 8, 19, 37, 54, 0, DateTimeKind.Local), 3, null },
                    { 3, 3, null, "If0VJg6Py60FS2Er318", new DateTime(2023, 6, 8, 19, 37, 54, 0, DateTimeKind.Local), 3, null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "description", "name", "reservesid" },
                values: new object[,]
                {
                    { 1, "Ea non nesciunt distinctio aspernatur eum id id.", "Yvette Corwin V", null },
                    { 2, "Iure quibusdam aut quo qui pariatur eum libero.", "Felipa Lindgren DVM", null },
                    { 3, "At velit et hic modi sunt iure consequatur.", "Ollie Rowe", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "cant_reserves_last_mont", "date_last_reserve", "faculty", "name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 6, 9, 19, 37, 54, 0, DateTimeKind.Local), "Voluptatibus quia voluptatem quia nisi.", "Prof. Aleen Konopelski" },
                    { 2, 0, null, "Animi laboriosam voluptatum assumenda odit.", "Antoinette Mayer" },
                    { 3, 1, new DateTime(2023, 6, 8, 19, 37, 54, 0, DateTimeKind.Local), "Et sed quos enim ut quis hic.", "Yvonne Terry" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_reservations_bookid",
                table: "Book_reservations",
                column: "bookid");

            migrationBuilder.CreateIndex(
                name: "IX_Book_reservations_userid",
                table: "Book_reservations",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Books_reservesid",
                table: "Books",
                column: "reservesid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_reservations");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
