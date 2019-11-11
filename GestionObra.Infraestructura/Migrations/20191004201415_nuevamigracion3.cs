using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionObra.Infraestructura.Migrations
{
    public partial class nuevamigracion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFacturacion",
                table: "Presupuestos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Cae",
                table: "ComprobantesEntrada",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cae",
                table: "ComprobanteSalida",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 1L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 17, 14, 14, 948, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 2L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 17, 14, 14, 950, DateTimeKind.Local).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 3L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 17, 14, 14, 950, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 4L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 17, 14, 14, 950, DateTimeKind.Local).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 5L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 17, 14, 14, 950, DateTimeKind.Local).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 6L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 17, 14, 14, 950, DateTimeKind.Local).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 7L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 17, 14, 14, 950, DateTimeKind.Local).AddTicks(2340));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 8L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 17, 14, 14, 950, DateTimeKind.Local).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 9L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 17, 14, 14, 950, DateTimeKind.Local).AddTicks(2342));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFacturacion",
                table: "Presupuestos");

            migrationBuilder.DropColumn(
                name: "Cae",
                table: "ComprobantesEntrada");

            migrationBuilder.DropColumn(
                name: "Cae",
                table: "ComprobanteSalida");

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 1L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 2L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7462));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 3L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7468));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 4L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 5L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 6L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7475));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 7L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7478));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 8L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 9L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7481));
        }
    }
}
