using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class UserReacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Reacts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reacts_AppUserId",
                table: "Reacts",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reacts_AspNetUsers_AppUserId",
                table: "Reacts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reacts_AspNetUsers_AppUserId",
                table: "Reacts");

            migrationBuilder.DropIndex(
                name: "IX_Reacts_AppUserId",
                table: "Reacts");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Reacts");
        }
    }
}
