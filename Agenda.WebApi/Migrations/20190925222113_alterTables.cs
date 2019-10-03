using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aspApi.Migrations
{
    public partial class alterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Eventos_eventoid",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Usuarios_usuarioid",
                table: "Agendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_usuarioid",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "usuarioid",
                table: "Agendas",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "eventoid",
                table: "Agendas",
                newName: "EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_eventoid",
                table: "Agendas",
                newName: "IX_Agendas_EventoId");

            migrationBuilder.AddColumn<int>(
                name: "agendaId",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas",
                columns: new[] { "UsuarioId", "EventoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Eventos_EventoId",
                table: "Agendas",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Usuarios_UsuarioId",
                table: "Agendas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Eventos_EventoId",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Usuarios_UsuarioId",
                table: "Agendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "agendaId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "EventoId",
                table: "Agendas",
                newName: "eventoid");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Agendas",
                newName: "usuarioid");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_EventoId",
                table: "Agendas",
                newName: "IX_Agendas_eventoid");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Agendas",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_usuarioid",
                table: "Agendas",
                column: "usuarioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Eventos_eventoid",
                table: "Agendas",
                column: "eventoid",
                principalTable: "Eventos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Usuarios_usuarioid",
                table: "Agendas",
                column: "usuarioid",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
