using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aspApi.Migrations
{
    public partial class relationshipAgendaUsuarioEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Eventos_Eventoid",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Usuarios_Usuarioid",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "Usuarioid",
                table: "Agendas",
                newName: "usuarioid");

            migrationBuilder.RenameColumn(
                name: "Observacao",
                table: "Agendas",
                newName: "observacao");

            migrationBuilder.RenameColumn(
                name: "Eventoid",
                table: "Agendas",
                newName: "eventoid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Agendas",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_Usuarioid",
                table: "Agendas",
                newName: "IX_Agendas_usuarioid");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_Eventoid",
                table: "Agendas",
                newName: "IX_Agendas_eventoid");

            migrationBuilder.AddColumn<byte[]>(
                name: "versao",
                table: "Agendas",
                rowVersion: true,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Eventos_eventoid",
                table: "Agendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Usuarios_usuarioid",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "versao",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "usuarioid",
                table: "Agendas",
                newName: "Usuarioid");

            migrationBuilder.RenameColumn(
                name: "observacao",
                table: "Agendas",
                newName: "Observacao");

            migrationBuilder.RenameColumn(
                name: "eventoid",
                table: "Agendas",
                newName: "Eventoid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Agendas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_usuarioid",
                table: "Agendas",
                newName: "IX_Agendas_Usuarioid");

            migrationBuilder.RenameIndex(
                name: "IX_Agendas_eventoid",
                table: "Agendas",
                newName: "IX_Agendas_Eventoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Eventos_Eventoid",
                table: "Agendas",
                column: "Eventoid",
                principalTable: "Eventos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Usuarios_Usuarioid",
                table: "Agendas",
                column: "Usuarioid",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
