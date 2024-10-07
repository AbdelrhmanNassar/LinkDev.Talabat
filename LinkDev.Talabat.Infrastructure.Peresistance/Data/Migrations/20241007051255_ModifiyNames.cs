using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkDev.Talabat.Infrastructure.Peresistance.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiyNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModigiedBy",
                table: "Products",
                newName: "LastModifiedBy");

            migrationBuilder.RenameColumn(
                name: "LastModigiedBy",
                table: "Categories",
                newName: "LastModifiedBy");

            migrationBuilder.RenameColumn(
                name: "LastModigiedBy",
                table: "Brands",
                newName: "LastModifiedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedBy",
                table: "Products",
                newName: "LastModigiedBy");

            migrationBuilder.RenameColumn(
                name: "LastModifiedBy",
                table: "Categories",
                newName: "LastModigiedBy");

            migrationBuilder.RenameColumn(
                name: "LastModifiedBy",
                table: "Brands",
                newName: "LastModigiedBy");
        }
    }
}
