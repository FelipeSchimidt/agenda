using Microsoft.EntityFrameworkCore.Migrations;

namespace aspApi.Migrations
{
    public partial class fieldImagemUrlUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "Usuarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "Usuarios");
        }
    }
}
