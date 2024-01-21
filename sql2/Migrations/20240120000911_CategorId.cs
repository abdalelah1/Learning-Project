using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sql2.Migrations
{
    /// <inheritdoc />
    public partial class CategorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoryid",
                table: "items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "categoryid",
                table: "items");
        }
    }
}
