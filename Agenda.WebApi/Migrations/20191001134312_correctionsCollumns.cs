using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aspApi.Migrations
{
    public partial class correctionsCollumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "versao",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "passwords",
                table: "Usuarios",
                newName: "Passwords");

            migrationBuilder.RenameColumn(
                name: "mail",
                table: "Usuarios",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Usuarios",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Usuarios",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "birth",
                table: "Usuarios",
                newName: "Birth");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Eventos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Eventos",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "dateEvent",
                table: "Eventos",
                newName: "DateEvent");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Eventos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "observacao",
                table: "Agendas",
                newName: "Observations");

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Agendas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Agendas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Agendas",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Agendas",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<int>(
                name: "Events",
                table: "Agendas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Users",
                table: "Agendas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendas",
                table: "Agendas",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Agendas_Users_Events",
                table: "Agendas",
                columns: new[] { "Users", "Events" });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_UsuarioId",
                table: "Agendas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Eventos_EventoId",
                table: "Agendas",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Usuarios_UsuarioId",
                table: "Agendas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Agendas_Users_Events",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_UsuarioId",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "Events",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "Users",
                table: "Agendas");

            migrationBuilder.RenameColumn(
                name: "Passwords",
                table: "Usuarios",
                newName: "passwords");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Usuarios",
                newName: "mail");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Usuarios",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Usuarios",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Birth",
                table: "Usuarios",
                newName: "birth");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuarios",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Eventos",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Eventos",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "DateEvent",
                table: "Eventos",
                newName: "dateEvent");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Eventos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Observations",
                table: "Agendas",
                newName: "observacao");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Agendas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Agendas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "versao",
                table: "Agendas",
                rowVersion: true,
                nullable: true);

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
    }
}
