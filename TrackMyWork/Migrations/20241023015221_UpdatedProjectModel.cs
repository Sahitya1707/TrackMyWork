using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackMyWork.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProjectModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DaysToComplete",
                table: "Projects",
                newName: "Status");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadlineDate",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeadlineDate",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Projects",
                newName: "DaysToComplete");
        }
    }
}
