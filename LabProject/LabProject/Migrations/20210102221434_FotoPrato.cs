using Microsoft.EntityFrameworkCore.Migrations;

namespace LabProject.Migrations
{
    public partial class FotoPrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "foto",
                table: "Restaurante");

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Utilizador",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Utilizador");

            migrationBuilder.AddColumn<string>(
                name: "foto",
                table: "Restaurante",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
