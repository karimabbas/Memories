using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class PostReacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpActivity_Activity_ActivityID",
                table: "EmpActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpActivity_Employees_EmpID",
                table: "EmpActivity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpActivity",
                table: "EmpActivity");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "PostReacts");

            migrationBuilder.DropColumn(
                name: "Loves",
                table: "PostReacts");

            migrationBuilder.DropColumn(
                name: "Post_id",
                table: "PostReacts");

            migrationBuilder.RenameTable(
                name: "EmpActivity",
                newName: "EmpActivities");

            migrationBuilder.RenameIndex(
                name: "IX_EmpActivity_EmpID",
                table: "EmpActivities",
                newName: "IX_EmpActivities_EmpID");

            migrationBuilder.RenameIndex(
                name: "IX_EmpActivity_ActivityID",
                table: "EmpActivities",
                newName: "IX_EmpActivities_ActivityID");

            migrationBuilder.AddColumn<int>(
                name: "ReactsId",
                table: "PostReacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpActivities",
                table: "EmpActivities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Reacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReactType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reacts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostReacts_ReactsId",
                table: "PostReacts",
                column: "ReactsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpActivities_Activity_ActivityID",
                table: "EmpActivities",
                column: "ActivityID",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpActivities_Employees_EmpID",
                table: "EmpActivities",
                column: "EmpID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReacts_Reacts_ReactsId",
                table: "PostReacts",
                column: "ReactsId",
                principalTable: "Reacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpActivities_Activity_ActivityID",
                table: "EmpActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_EmpActivities_Employees_EmpID",
                table: "EmpActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReacts_Reacts_ReactsId",
                table: "PostReacts");

            migrationBuilder.DropTable(
                name: "Reacts");

            migrationBuilder.DropIndex(
                name: "IX_PostReacts_ReactsId",
                table: "PostReacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpActivities",
                table: "EmpActivities");

            migrationBuilder.DropColumn(
                name: "ReactsId",
                table: "PostReacts");

            migrationBuilder.RenameTable(
                name: "EmpActivities",
                newName: "EmpActivity");

            migrationBuilder.RenameIndex(
                name: "IX_EmpActivities_EmpID",
                table: "EmpActivity",
                newName: "IX_EmpActivity_EmpID");

            migrationBuilder.RenameIndex(
                name: "IX_EmpActivities_ActivityID",
                table: "EmpActivity",
                newName: "IX_EmpActivity_ActivityID");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "PostReacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Loves",
                table: "PostReacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Post_id",
                table: "PostReacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpActivity",
                table: "EmpActivity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpActivity_Activity_ActivityID",
                table: "EmpActivity",
                column: "ActivityID",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpActivity_Employees_EmpID",
                table: "EmpActivity",
                column: "EmpID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
