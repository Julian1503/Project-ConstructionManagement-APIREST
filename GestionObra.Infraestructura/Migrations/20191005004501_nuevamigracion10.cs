using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionObra.Infraestructura.Migrations
{
    public partial class nuevamigracion10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cae",
                table: "ComprobanteCompras",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroCompronte",
                table: "ComprobanteCompras",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 1L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 21, 45, 0, 755, DateTimeKind.Local).AddTicks(5796));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 2L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 21, 45, 0, 756, DateTimeKind.Local).AddTicks(3991));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 3L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 21, 45, 0, 756, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 4L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 21, 45, 0, 756, DateTimeKind.Local).AddTicks(4004));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 5L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 21, 45, 0, 756, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 6L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 21, 45, 0, 756, DateTimeKind.Local).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 7L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 21, 45, 0, 756, DateTimeKind.Local).AddTicks(4018));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 8L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 21, 45, 0, 756, DateTimeKind.Local).AddTicks(4019));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 9L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 21, 45, 0, 756, DateTimeKind.Local).AddTicks(4021));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cae",
                table: "ComprobanteCompras");

            migrationBuilder.DropColumn(
                name: "NumeroCompronte",
                table: "ComprobanteCompras");

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 1L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 50, 30, 393, DateTimeKind.Local).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 2L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 50, 30, 396, DateTimeKind.Local).AddTicks(8004));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 3L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 50, 30, 396, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 4L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 50, 30, 396, DateTimeKind.Local).AddTicks(8029));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 5L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 50, 30, 396, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 6L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 50, 30, 396, DateTimeKind.Local).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 7L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 50, 30, 396, DateTimeKind.Local).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 8L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 50, 30, 396, DateTimeKind.Local).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 9L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 50, 30, 396, DateTimeKind.Local).AddTicks(8071));
        }
    }
}
