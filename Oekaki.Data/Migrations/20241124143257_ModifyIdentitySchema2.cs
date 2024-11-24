using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oekaki.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyIdentitySchema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId2",
                schema: "Oekaki",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId2",
                schema: "Oekaki",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId2",
                schema: "Oekaki",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId2",
                schema: "Oekaki",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserTokens_UserId2",
                schema: "Oekaki",
                table: "UserTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserId2",
                schema: "Oekaki",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserLogins_UserId2",
                schema: "Oekaki",
                table: "UserLogins");

            migrationBuilder.DropIndex(
                name: "IX_UserClaims_UserId2",
                schema: "Oekaki",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "UserId2",
                schema: "Oekaki",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "UserId2",
                schema: "Oekaki",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UserId2",
                schema: "Oekaki",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "UserId2",
                schema: "Oekaki",
                table: "UserClaims");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId2",
                schema: "Oekaki",
                table: "UserTokens",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId2",
                schema: "Oekaki",
                table: "UserRoles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId2",
                schema: "Oekaki",
                table: "UserLogins",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId2",
                schema: "Oekaki",
                table: "UserClaims",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId2",
                schema: "Oekaki",
                table: "UserTokens",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId2",
                schema: "Oekaki",
                table: "UserRoles",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId2",
                schema: "Oekaki",
                table: "UserLogins",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId2",
                schema: "Oekaki",
                table: "UserClaims",
                column: "UserId2");

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId2",
                schema: "Oekaki",
                table: "UserClaims",
                column: "UserId2",
                principalSchema: "Oekaki",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId2",
                schema: "Oekaki",
                table: "UserLogins",
                column: "UserId2",
                principalSchema: "Oekaki",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId2",
                schema: "Oekaki",
                table: "UserRoles",
                column: "UserId2",
                principalSchema: "Oekaki",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId2",
                schema: "Oekaki",
                table: "UserTokens",
                column: "UserId2",
                principalSchema: "Oekaki",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
