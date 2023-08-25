using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreAndFood.Migrations
{
    /// <inheritdoc />
    public partial class coreandfoodsfirst1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CaregoryName",
                table: "Categories",
                newName: "CategoryName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "CaregoryName");
        }
    }
}
