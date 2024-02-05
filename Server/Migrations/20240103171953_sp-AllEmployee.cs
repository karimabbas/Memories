using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class spAllEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           var Sql_procedure = @"Create PROCEDURE AllEmployee
                            AS 
                            SELECT [e].[Id], [e].[Age], [e].[DepartmentId], [e].[Email], [e].[Employee_Name], [e].[Salary], [d].[Id], [d].[Dept_name], [d].[YearOfCreation]
                            FROM [Employees] AS [e]
                            INNER JOIN [Departments] AS [d] 
                            ON 
                            [e].[DepartmentId] = [d].[Id]";
 
            migrationBuilder.Sql(Sql_procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
