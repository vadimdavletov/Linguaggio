using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Editor.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "words",
                columns: table => new
                {
                    word_id = table.Column<Guid>(type: "uuid", nullable: false),
                    word_value = table.Column<string>(type: "text", nullable: true),
                    transcription = table.Column<string>(type: "text", nullable: true),
                    language = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_words", x => x.word_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_words_word_id",
                table: "words",
                column: "word_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "words");
        }
    }
}
