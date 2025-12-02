using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC04.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IsActiveCoulmn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
               name: "IsActive",
               table: "Employees",
               type: "bit",
               nullable: false,
               defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "IsActive",
            table: "Employees");
        }
    }
}
