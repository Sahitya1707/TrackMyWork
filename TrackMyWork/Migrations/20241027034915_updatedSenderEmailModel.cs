using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackMyWork.Migrations
{
    /// <inheritdoc />
    public partial class updatedSenderEmailModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderMail",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderMail",
                table: "Messages");
        }
    }
}
