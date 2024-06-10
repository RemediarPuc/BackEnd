using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemediarAPI.Migrations
{
    /// <inheritdoc />
    public partial class RedefinindoEntidadeDoacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data",
                table: "Doacoes");

            migrationBuilder.DropColumn(
                name: "dataRetirada",
                table: "Doacoes");

            migrationBuilder.DropColumn(
                name: "endereco",
                table: "Doacoes");

            migrationBuilder.DropColumn(
                name: "horario",
                table: "Doacoes");

            migrationBuilder.DropColumn(
                name: "nomeDoador",
                table: "Doacoes");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Doacoes");

            migrationBuilder.DropColumn(
                name: "telefone",
                table: "Doacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "data",
                table: "Doacoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dataRetirada",
                table: "Doacoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "Doacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "horario",
                table: "Doacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nomeDoador",
                table: "Doacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Doacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "telefone",
                table: "Doacoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
