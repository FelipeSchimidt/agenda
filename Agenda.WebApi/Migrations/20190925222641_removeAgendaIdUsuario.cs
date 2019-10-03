using Microsoft.EntityFrameworkCore.Migrations;

namespace aspApi.Migrations
{
    public partial class removeAgendaIdUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "agendaId",
                table: "Usuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "agendaId",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);
        }
    }
}
