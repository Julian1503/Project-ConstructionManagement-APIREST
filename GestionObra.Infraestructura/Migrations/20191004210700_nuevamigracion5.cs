using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionObra.Infraestructura.Migrations
{
    public partial class nuevamigracion5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "NumeroFacturacion",
                table: "Presupuestos",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "Cae",
                table: "Presupuestos",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 1L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 6, 59, 556, DateTimeKind.Local).AddTicks(2086));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 2L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 6, 59, 556, DateTimeKind.Local).AddTicks(8689));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 3L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 6, 59, 556, DateTimeKind.Local).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 4L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 6, 59, 556, DateTimeKind.Local).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 5L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 6, 59, 556, DateTimeKind.Local).AddTicks(8701));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 6L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 6, 59, 556, DateTimeKind.Local).AddTicks(8764));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 7L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 6, 59, 556, DateTimeKind.Local).AddTicks(8766));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 8L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 6, 59, 556, DateTimeKind.Local).AddTicks(8767));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 9L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 6, 59, 556, DateTimeKind.Local).AddTicks(8768));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "NumeroFacturacion",
                table: "Presupuestos",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Cae",
                table: "Presupuestos",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 1L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 4, 28, 645, DateTimeKind.Local).AddTicks(1609));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 2L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 4, 28, 645, DateTimeKind.Local).AddTicks(7852));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 3L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 4, 28, 645, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 4L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 4, 28, 645, DateTimeKind.Local).AddTicks(7862));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 5L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 4, 28, 645, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 6L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 4, 28, 645, DateTimeKind.Local).AddTicks(7911));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 7L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 4, 28, 645, DateTimeKind.Local).AddTicks(7913));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 8L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 4, 28, 645, DateTimeKind.Local).AddTicks(7914));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 9L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 4, 18, 4, 28, 645, DateTimeKind.Local).AddTicks(7915));
        }
    }
}
