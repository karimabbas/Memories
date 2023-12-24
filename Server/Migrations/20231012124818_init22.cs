using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class init22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_User_Id",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "User_Id",
                table: "Posts",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_User_Id",
                table: "Posts",
                newName: "IX_Posts_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AppUserId",
                table: "Posts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AppUserId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Posts",
                newName: "User_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AppUserId",
                table: "Posts",
                newName: "IX_Posts_User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_User_Id",
                table: "Posts",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
