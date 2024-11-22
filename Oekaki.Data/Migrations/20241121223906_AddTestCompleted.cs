﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oekaki.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTestCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                schema: "Oekaki",
                table: "Tests",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                schema: "Oekaki",
                table: "Tests");
        }
    }
}
