using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class spGetEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var Sql_procedure = @"Create PROCEDURE GET_EMPLOYEE
                            @Param_id NVARCHAR(50) 
                            AS 
                            select E.Employee_Name ,E.Salary,E.Email,E.Age,D.Dept_name
                            from Employees AS E
                            left join
                            Departments As D 
                            on 
                            E.DepartmentId = D.id
                            where E.id = @Param_id
                            Go";

            migrationBuilder.Sql(Sql_procedure);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
