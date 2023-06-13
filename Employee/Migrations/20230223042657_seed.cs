using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Employee.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "_Employees",
                columns: new[] { "Id", "Department", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 1, "ali@hotmail.com", "ali" },
                    { 2, 2, "ali@hotmail.com", "ali" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "_Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "_Employees",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
