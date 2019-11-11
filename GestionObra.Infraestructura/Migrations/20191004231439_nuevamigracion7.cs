using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionObra.Infraestructura.Migrations
{
    public partial class nuevamigracion7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprobanteEntrada_SubRubro",
                table: "ComprobantesEntrada");

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 1L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 14, 38, 783, DateTimeKind.Local).AddTicks(5889));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 2L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 14, 38, 784, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 3L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 14, 38, 784, DateTimeKind.Local).AddTicks(3124));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 4L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 14, 38, 784, DateTimeKind.Local).AddTicks(3126));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 5L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 14, 38, 784, DateTimeKind.Local).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 6L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 14, 38, 784, DateTimeKind.Local).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 7L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 14, 38, 784, DateTimeKind.Local).AddTicks(3137));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 8L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 14, 38, 784, DateTimeKind.Local).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 9L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 20, 14, 38, 784, DateTimeKind.Local).AddTicks(3139));

            migrationBuilder.AddForeignKey(
                name: "FK_ComprobanteEntrada_SubRubro",
                table: "ComprobantesEntrada",
                column: "SubRubroId",
                principalTable: "SubRubros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprobanteEntrada_SubRubro",
                table: "ComprobantesEntrada");

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 1L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 50, 31, 114, DateTimeKind.Local).AddTicks(1789));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 2L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 50, 31, 115, DateTimeKind.Local).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 3L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 50, 31, 115, DateTimeKind.Local).AddTicks(2143));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 4L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 50, 31, 115, DateTimeKind.Local).AddTicks(2145));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 5L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 50, 31, 115, DateTimeKind.Local).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 6L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 50, 31, 115, DateTimeKind.Local).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 7L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 50, 31, 115, DateTimeKind.Local).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 8L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 50, 31, 115, DateTimeKind.Local).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 9L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 50, 31, 115, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.AddForeignKey(
                name: "FK_ComprobanteEntrada_SubRubro",
                table: "ComprobantesEntrada",
                column: "SubRubroId",
                principalTable: "SubRubros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
