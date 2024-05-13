using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EX.Data.Migrations
{
    /// <inheritdoc />
    public partial class ddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConseillerFK",
                table: "Conseillers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConseillerFK",
                table: "Conseillers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
