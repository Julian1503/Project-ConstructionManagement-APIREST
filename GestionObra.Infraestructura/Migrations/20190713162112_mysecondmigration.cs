using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionObra.Infraestructura.Migrations
{
    public partial class mysecondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprobanteEntradas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gasto",
                table: "Gasto");

            migrationBuilder.RenameTable(
                name: "Gasto",
                newName: "Gastos");

            migrationBuilder.RenameIndex(
                name: "IX_Gasto_TipoGastoId",
                table: "Gastos",
                newName: "IX_Gastos_TipoGastoId");

            migrationBuilder.RenameIndex(
                name: "IX_Gasto_PresupuestoId",
                table: "Gastos",
                newName: "IX_Gastos_PresupuestoId");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "TipoGastos",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "CantidadUsado",
                table: "IngresoMateriales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoComprobanteEntrada",
                table: "Comprobantes",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoApertura",
                table: "Cajas",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoCierre",
                table: "Cajas",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gastos",
                table: "Gastos",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Bancos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Descripcion",
                value: "Banco Macro");

            migrationBuilder.UpdateData(
                table: "Bancos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Descripcion",
                value: "Banco Nacion");

            migrationBuilder.UpdateData(
                table: "Bancos",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Descripcion",
                value: "Galicia");

            migrationBuilder.UpdateData(
                table: "Bancos",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Descripcion",
                value: "Santander Rio");

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Apellido", "Celular", "Dni", "Email", "EstaEliminado", "FechaNacimiento", "Nombre", "Sexo", "Telefono" },
                values: new object[] { 1L, "Delgado", "3815451043", "39481311", "julianedelgado@hotmail.com", false, new DateTime(1996, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julian", 1, "4332244" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "EstaBloqueado", "EstaEliminado", "LimitacionesId", "Password", "PersonaId", "UserName" },
                values: new object[] { 1L, false, false, 0L, "123456", 1L, "juliamm1503" });

            migrationBuilder.CreateIndex(
                name: "IX_Precios_UsuarioId",
                table: "Precios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Precio_Usuario",
                table: "Precios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Precio_Usuario",
                table: "Precios");

            migrationBuilder.DropIndex(
                name: "IX_Precios_UsuarioId",
                table: "Precios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gastos",
                table: "Gastos");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DropColumn(
                name: "CantidadUsado",
                table: "IngresoMateriales");

            migrationBuilder.DropColumn(
                name: "TipoComprobanteEntrada",
                table: "Comprobantes");

            migrationBuilder.DropColumn(
                name: "MontoApertura",
                table: "Cajas");

            migrationBuilder.DropColumn(
                name: "MontoCierre",
                table: "Cajas");

            migrationBuilder.RenameTable(
                name: "Gastos",
                newName: "Gasto");

            migrationBuilder.RenameIndex(
                name: "IX_Gastos_TipoGastoId",
                table: "Gasto",
                newName: "IX_Gasto_TipoGastoId");

            migrationBuilder.RenameIndex(
                name: "IX_Gastos_PresupuestoId",
                table: "Gasto",
                newName: "IX_Gasto_PresupuestoId");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "TipoGastos",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gasto",
                table: "Gasto",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ComprobanteEntradas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TipoComprobanteEntrada = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobanteEntradas", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Bancos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Descripcion",
                value: "BANCO MACRO");

            migrationBuilder.UpdateData(
                table: "Bancos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Descripcion",
                value: "BANCO NACION");

            migrationBuilder.UpdateData(
                table: "Bancos",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Descripcion",
                value: "GALICIA");

            migrationBuilder.UpdateData(
                table: "Bancos",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Descripcion",
                value: "SANTANDER RIO");
        }
    }
}
