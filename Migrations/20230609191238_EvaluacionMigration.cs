using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eval_3.Migrations
{
    /// <inheritdoc />
    public partial class EvaluacionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    faculty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_last_reserve = table.Column<DateTime>(type: "datetime2", nullable: true),
                    cant_reserves_last_month = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Book_reservations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_reserve = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Book_reservations_Books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_reservations_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Ea non nesciunt distinctio aspernatur eum id id.", "Yvette Corwin V" },
                    { 2, "Iure quibusdam aut quo qui pariatur eum libero.", "Felipa Lindgren DVM" },
                    { 3, "At velit et hic modi sunt iure consequatur.", "Ollie Rowe" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "cant_reserves_last_month", "date_last_reserve", "faculty", "name" },
                values: new object[,]
                {
                    { 1, null, null, "Voluptatibus quia voluptatem quia nisi.", "Prof. Aleen Konopelski" },
                    { 2, null, null, "Animi laboriosam voluptatum assumenda odit.", "Antoinette Mayer" },
                    { 3, null, null, "Et sed quos enim ut quis hic.", "Yvonne Terry" }
                });

            migrationBuilder.InsertData(
                table: "Book_reservations",
                columns: new[] { "id", "book_id", "code", "date_reserve", "user_id" },
                values: new object[,]
                {
                    { 1, 1, "cgLFZuT6Y8q7cf0byW", new DateTime(2023, 6, 9, 19, 37, 54, 0, DateTimeKind.Local), 1 },
                    { 2, 2, "6xvGgDMVCYy28epj83P9BUOd", new DateTime(2023, 5, 8, 19, 37, 54, 0, DateTimeKind.Local), 1 },
                    { 3, 3, "If0VJg6Py60FS2Er318", new DateTime(2023, 6, 8, 19, 37, 54, 0, DateTimeKind.Local), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_reservations_book_id",
                table: "Book_reservations",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_Book_reservations_user_id",
                table: "Book_reservations",
                column: "user_id");
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
