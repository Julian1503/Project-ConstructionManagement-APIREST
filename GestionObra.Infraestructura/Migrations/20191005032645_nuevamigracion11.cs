using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionObra.Infraestructura.Migrations
{
    public partial class nuevamigracion11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "CBU", "Cuit", "Descripcion", "EstaEliminado", "Mail", "NombreFantasia", "Path", "RazonSocial", "Sucursal", "Telefono" },
                values: new object[] { 3L, "Valores a depositor", "Valores a depositor", "Valores A Depositor", false, "Valores a depositor", "Valores a depositor", "", "Valores a depositor", "Valores a depositor", "Valores a depositor" });

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 1L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 5, 0, 26, 44, 749, DateTimeKind.Local).AddTicks(179));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 2L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 5, 0, 26, 44, 749, DateTimeKind.Local).AddTicks(9893));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 3L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 5, 0, 26, 44, 749, DateTimeKind.Local).AddTicks(9907));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 4L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 5, 0, 26, 44, 749, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 5L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 5, 0, 26, 44, 749, DateTimeKind.Local).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 6L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 5, 0, 26, 44, 749, DateTimeKind.Local).AddTicks(9921));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 7L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 5, 0, 26, 44, 749, DateTimeKind.Local).AddTicks(9923));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 8L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 5, 0, 26, 44, 749, DateTimeKind.Local).AddTicks(9926));

            migrationBuilder.UpdateData(
                table: "Obras",
                keyColumn: "Id",
                keyValue: 9L,
                column: "FechaEstimadaInicio",
                value: new DateTime(2019, 10, 5, 0, 26, 44, 749, DateTimeKind.Local).AddTicks(9928));

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "EmpleadoId", "EstaBloqueado", "EstaEliminado", "IdentificacionId", "Password", "Token", "UserName" },
                values: new object[] { 1L, 1L, false, false, 1L, "Nh99FqfGzhSeHmdP4ERhcw==", null, "juliamm1503" });

            migrationBuilder.InsertData(
                table: "CuentaCorrientes",
                columns: new[] { "Id", "BancoId", "EmpresaId", "EstaEliminado", "MontoMaximo" },
                values: new object[] { 3L, 3L, null, false, 3800000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CuentaCorrientes",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Bancos",
                keyColumn: "Id",
                keyValue: 3L);

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
    }
}
