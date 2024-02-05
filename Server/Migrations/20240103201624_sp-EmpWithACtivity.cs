using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class spEmpWithACtivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var Sql_procedure = @"Create PROCEDURE spEmpWithACtivity
                            @Param_id NVARCHAR(50)
                            AS 
                            SELECT [e].[Id], [e].[Age], [e].[DepartmentId], [e].[Email], [e].[Employee_Name], [e].[Salary], [t].[Id], [t].[ActivityID], [t].[EmpID],[t].[Id0], [t].[Activity_name]
                            FROM [Employees] AS [e]
                            LEFT JOIN (
                            SELECT [e0].[Id], [e0].[ActivityID], [e0].[EmpID], [a].[Id] AS [Id0], [a].[Activity_name]
                            FROM [EmpActivities] AS [e0]
                            INNER JOIN [Activity] AS [a]
                            ON 
                            [e0].[ActivityID] = [a].[Id]) AS [t] ON [e].[Id] = [t].[EmpID]
                            WHERE [e].[Id] = @Param_id
                            ORDER BY [e].[Id], [t].[Id]";

            migrationBuilder.Sql(Sql_procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
