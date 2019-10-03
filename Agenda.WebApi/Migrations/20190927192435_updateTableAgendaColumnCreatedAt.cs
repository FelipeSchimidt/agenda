using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace aspApi.Migrations
{
    public partial class updateTableAgendaColumnCreatedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "versao",
                table: "Agendas");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Agendas",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Agendas");

            migrationBuilder.AddColumn<byte[]>(
                name: "versao",
                table: "Agendas",
                rowVersion: true,
                nullable: true);
        }
    }
}
