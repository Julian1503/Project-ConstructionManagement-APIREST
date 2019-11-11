using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionObra.Infraestructura.Migrations
{
    public partial class nuevamigracion9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprobanteEntrada_SubRubro",
                table: "ComprobantesEntrada");

            migrationBuilder.AlterColumn<long>(
                name: "SubRubroId",
                table: "ComprobantesEntrada",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "NumeroComprobante",
                table: "ComprobantesEntrada",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_ComprobanteEntrada_SubRubro",
                table: "ComprobantesEntrada",
                column: "SubRubroId",
                principalTable: "SubRubros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprobanteEntrada_SubRubro",
                table: "ComprobantesEntrada");

            migrationBuilder.AlterColumn<long>(
                name: "SubRubroId",
                table: "ComprobantesEntrada",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumeroComprobante",
                table: "ComprobantesEntrada",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 1L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 28, 51, 959, DateTimeKind.Local).AddTicks(3867));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 2L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 28, 51, 960, DateTimeKind.Local).AddTicks(51));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 3L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 28, 51, 960, DateTimeKind.Local).AddTicks(58));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 4L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 28, 51, 960, DateTimeKind.Local).AddTicks(60));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 5L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 28, 51, 960, DateTimeKind.Local).AddTicks(61));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 6L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 28, 51, 960, DateTimeKind.Local).AddTicks(65));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 7L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 28, 51, 960, DateTimeKind.Local).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 8L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 28, 51, 960, DateTimeKind.Local).AddTicks(67));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 9L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 28, 51, 960, DateTimeKind.Local).AddTicks(68));

            migrationBuilder.AddForeignKey(
                name: "FK_ComprobanteEntrada_SubRubro",
                table: "ComprobantesEntrada",
                column: "SubRubroId",
                principalTable: "SubRubros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
