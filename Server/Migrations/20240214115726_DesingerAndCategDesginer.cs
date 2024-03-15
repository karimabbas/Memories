using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class DesingerAndCategDesginer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desginers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desginers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CateDesigners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_id = table.Column<int>(type: "int", nullable: true),
                    Desginer_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CateDesigners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CateDesigners_Categories_Category_id",
                        column: x => x.Category_id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CateDesigners_Desginers_Desginer_id",
                        column: x => x.Desginer_id,
                        principalTable: "Desginers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CateDesigners_Category_id",
                table: "CateDesigners",
                column: "Category_id");

            migrationBuilder.CreateIndex(
                name: "IX_CateDesigners_Desginer_id",
                table: "CateDesigners",
                column: "Desginer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CateDesigners");

            migrationBuilder.DropTable(
                name: "Desginers");
        }
    }
}
