using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oekaki.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserNicknameSlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                schema: "Oekaki",
                table: "AspNetUsers",
                type: "character varying(24)",
                maxLength: 24,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "URISlug",
                schema: "Oekaki",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_URISlug",
                schema: "Oekaki",
                table: "AspNetUsers",
                column: "URISlug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_URISlug",
                schema: "Oekaki",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nickname",
                schema: "Oekaki",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "URISlug",
                schema: "Oekaki",
                table: "AspNetUsers");
        }
    }
}
