using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class spUserPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var Sql_procedure = @"Create PROCEDURE spUserPost
                            @Param_id NVARCHAR(50)
                            AS 
                            SELECT [p].[Id], [p].[AppUserId], [p].[Created_At], [p].[Likes], [p].[Loves], [p].[Message], [p].[PostImage], [p].[Title], [p].[UserId]
                            FROM [Posts] AS [p]
                            LEFT JOIN [AspNetUsers] AS [a] ON [p].[AppUserId] = [a].[Id]
                            WHERE [a].[Id] = @Param_id";

            migrationBuilder.Sql(Sql_procedure);

        }

        /// <inheritdoc />
    }
}
