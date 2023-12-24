using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class init20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posts_User_Id",
                table: "Posts");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_User_Id",
                table: "Posts",
                column: "User_Id",
                unique: true,
                filter: "[User_Id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posts_User_Id",
                table: "Posts");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_User_Id",
                table: "Posts",
                column: "User_Id");
        }
    }
}
