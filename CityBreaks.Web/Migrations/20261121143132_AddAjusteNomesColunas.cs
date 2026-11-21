using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityBreaks.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddAjusteNomesColunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Properties",
                newName: "nomePropriedade");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "Countries",
                newName: "nomePais");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cities",
                newName: "nomeCidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nomePropriedade",
                table: "Properties",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "nomePais",
                table: "Countries",
                newName: "CountryName");

            migrationBuilder.RenameColumn(
                name: "nomeCidade",
                table: "Cities",
                newName: "Name");
        }
    }
}
