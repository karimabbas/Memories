using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class spGetEmp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             var Sql_procedure = @"Create PROCEDURE GET_EMP
                            @Param_id NVARCHAR(50) 
                            AS 
                            SELECT [e].[Id], [e].[Age], [e].[DepartmentId], [e].[Email], [e].[Employee_Name], [e].[Salary], [d].[Id], [d].[Dept_name], [d].[YearOfCreation]
                            FROM [Employees] AS [e]
                            LEFT JOIN [Departments] AS [d] ON [e].[DepartmentId] = [d].[Id]
                            WHERE [e].[Id] = @Param_id";

            migrationBuilder.Sql(Sql_procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
