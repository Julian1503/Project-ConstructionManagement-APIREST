using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionObra.Infraestructura.Migrations
{
    public partial class nuevamigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RazonSocial = table.Column<string>(maxLength: 250, nullable: false),
                    NombreFantasia = table.Column<string>(maxLength: 250, nullable: false),
                    Cuit = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Mail = table.Column<string>(maxLength: 60, nullable: true),
                    CBU = table.Column<string>(nullable: true),
                    Sucursal = table.Column<string>(maxLength: 200, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: true),
                    Path = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    SalarioMinimoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CausaFaltas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CausaFaltas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CondicionIvas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicionIvas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contratistas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RazonSocial = table.Column<string>(maxLength: 250, nullable: false),
                    NombreFantasia = table.Column<string>(maxLength: 250, nullable: false),
                    Cuit = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Mail = table.Column<string>(maxLength: 60, nullable: true),
                    Sucursal = table.Column<string>(maxLength: 200, nullable: true),
                    Path = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DescripcionTareas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescripcionTareas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Identificaciones",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Tesoreria = table.Column<bool>(nullable: false),
                    Obra = table.Column<bool>(nullable: false),
                    Configuracion = table.Column<bool>(nullable: false),
                    Administracion = table.Column<bool>(nullable: false),
                    Usuarios = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identificaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Codigo = table.Column<string>(maxLength: 50, nullable: true),
                    TipoMaterial = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Detalle = table.Column<string>(maxLength: 3000, nullable: true),
                    Path = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rubros",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    Codigo = table.Column<long>(nullable: false),
                    TipoRubro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoGastos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoGastos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChequesEntrada",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    FechaDesde = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "DateTime", nullable: false),
                    BancoId = table.Column<long>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Usado = table.Column<int>(nullable: false),
                    Serie = table.Column<string>(nullable: false),
                    Concepto = table.Column<string>(maxLength: 250, nullable: true),
                    Monto = table.Column<decimal>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    EmitidoPor = table.Column<string>(maxLength: 250, nullable: true),
                    Descontado = table.Column<bool>(nullable: false),
                    MontoDescontado = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChequesEntrada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChequeEntrada_Banco",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChequesSalida",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    FechaDesde = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FechaHasta = table.Column<DateTime>(type: "DateTime", nullable: false),
                    BancoId = table.Column<long>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Usado = table.Column<int>(nullable: false),
                    Serie = table.Column<string>(nullable: false),
                    Concepto = table.Column<string>(maxLength: 250, nullable: true),
                    Monto = table.Column<decimal>(nullable: false),
                    PagueseA = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChequesSalida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChequeSalida_Banco",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transferencias",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Usado = table.Column<int>(nullable: false),
                    BancoId = table.Column<long>(nullable: false),
                    PagueseA = table.Column<string>(nullable: true),
                    Entrada = table.Column<bool>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Numero = table.Column<long>(nullable: false),
                    ImpuestoBancario = table.Column<decimal>(nullable: false),
                    Concepto = table.Column<string>(maxLength: 250, nullable: false),
                    Fecha = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banco_Transferencia",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Legajo = table.Column<long>(nullable: false),
                    FechaIncio = table.Column<DateTime>(type: "DateTime", nullable: false),
                    CategoriaId = table.Column<long>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 250, nullable: false),
                    Apellido = table.Column<string>(maxLength: 250, nullable: false),
                    Path = table.Column<string>(nullable: true),
                    CUIT = table.Column<string>(maxLength: 12, nullable: false),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Celular = table.Column<string>(maxLength: 20, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Dni = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Categoria",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalarioMinimos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Salario = table.Column<decimal>(type: "Numeric", nullable: false),
                    CategoriaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalarioMinimos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalarioMinimo_Categorias",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CondicionIvaId = table.Column<long>(nullable: true),
                    RazonSocial = table.Column<string>(maxLength: 250, nullable: false),
                    NombreFantasia = table.Column<string>(maxLength: 250, nullable: false),
                    Cuit = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Mail = table.Column<string>(maxLength: 60, nullable: true),
                    Sucursal = table.Column<string>(maxLength: 200, nullable: true),
                    Path = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_CondicionIva",
                        column: x => x.CondicionIvaId,
                        principalTable: "CondicionIvas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    NombreFantasia = table.Column<string>(nullable: true),
                    RazonSocial = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Contacto = table.Column<string>(nullable: true),
                    CondicionIvaId = table.Column<long>(nullable: true),
                    Cuit = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedores_CondicionIvas_CondicionIvaId",
                        column: x => x.CondicionIvaId,
                        principalTable: "CondicionIvas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubRubros",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Codigo = table.Column<long>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    RubroId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRubros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubRubro_Rubro",
                        column: x => x.RubroId,
                        principalTable: "Rubros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserName = table.Column<string>(maxLength: 60, nullable: false),
                    Password = table.Column<string>(maxLength: 60, nullable: false),
                    EmpleadoId = table.Column<long>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    EstaBloqueado = table.Column<bool>(type: "bit", nullable: false),
                    IdentificacionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Identificacion",
                        column: x => x.IdentificacionId,
                        principalTable: "Identificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CuentaCorrientes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    BancoId = table.Column<long>(nullable: false),
                    MontoMaximo = table.Column<decimal>(nullable: false),
                    EmpresaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaCorrientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuentaCorriente_Banco",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CuentaCorrientes_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Depositos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Usado = table.Column<int>(nullable: false),
                    BancoId = table.Column<long>(nullable: false),
                    DePara = table.Column<string>(nullable: true),
                    Numero = table.Column<long>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Entrada = table.Column<bool>(nullable: false),
                    ImpuestoBancario = table.Column<decimal>(nullable: false),
                    Concepto = table.Column<string>(maxLength: 250, nullable: false),
                    Fecha = table.Column<DateTime>(type: "DateTime", nullable: false),
                    EmpresaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banco_Deposito",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Depositos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ComprobanteId = table.Column<long>(nullable: false),
                    TipoFormaPago = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(type: "Numeric", nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    BancoId = table.Column<long>(nullable: true),
                    Numero = table.Column<string>(maxLength: 250, nullable: true),
                    EnteEmisor = table.Column<string>(maxLength: 250, nullable: true),
                    FechaEmision = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Dias = table.Column<int>(nullable: true),
                    CustomerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormaPagoCheque_Banco",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormaPagoCtaCte_Empresa",
                        column: x => x.CustomerId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    Codigo = table.Column<string>(maxLength: 30, nullable: false),
                    Observacion = table.Column<string>(maxLength: 4000, nullable: true),
                    FechaEstimadaInicio = table.Column<DateTime>(type: "DateTime", nullable: false),
                    EstadoObra = table.Column<int>(nullable: false),
                    PropietarioId = table.Column<long>(nullable: true),
                    EncargadoId = table.Column<long>(nullable: false),
                    ZonaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obra_Encargado",
                        column: x => x.EncargadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obra_Propietario",
                        column: x => x.PropietarioId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Obra_Zona",
                        column: x => x.ZonaId,
                        principalTable: "Zonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cajas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    FechaCierre = table.Column<DateTime>(type: "DateTime", nullable: true),
                    FechaApertura = table.Column<DateTime>(type: "DateTime", nullable: false),
                    MontoApertura = table.Column<decimal>(nullable: false),
                    MontoCierre = table.Column<decimal>(nullable: false),
                    UsuarioAperturaId = table.Column<long>(nullable: false),
                    UsuarioCierreId = table.Column<long>(nullable: true),
                    MontoSistema = table.Column<decimal>(type: "Numeric", nullable: false),
                    Diferencia = table.Column<decimal>(type: "Numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cajas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CajaApertura_UsuarioApertura",
                        column: x => x.UsuarioAperturaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CajaCierre_UsuarioCierre",
                        column: x => x.UsuarioCierreId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComprobanteSalida",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UsuarioId = table.Column<long>(nullable: false),
                    SubRubroId = table.Column<long>(nullable: false),
                    Monto = table.Column<decimal>(type: "Numeric", nullable: false),
                    Descuento = table.Column<decimal>(nullable: false),
                    Interes = table.Column<decimal>(nullable: false),
                    Percepciones = table.Column<decimal>(nullable: false),
                    Usado = table.Column<int>(nullable: false),
                    Retenciones = table.Column<decimal>(nullable: false),
                    Iva = table.Column<decimal>(nullable: false),
                    Detalle = table.Column<string>(maxLength: 400, nullable: false),
                    Fecha = table.Column<DateTime>(type: "DateTime", nullable: false),
                    NumeroComprobante = table.Column<int>(nullable: false),
                    TipoComprobanteSalida = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobanteSalida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprobanteSalida_SubRubro",
                        column: x => x.SubRubroId,
                        principalTable: "SubRubros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComprobanteSalida_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComprobantesEntrada",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UsuarioId = table.Column<long>(nullable: false),
                    SubRubroId = table.Column<long>(nullable: false),
                    Monto = table.Column<decimal>(type: "Numeric", nullable: false),
                    Descuento = table.Column<decimal>(nullable: false),
                    Interes = table.Column<decimal>(nullable: false),
                    Iva = table.Column<decimal>(nullable: false),
                    Detalle = table.Column<string>(maxLength: 400, nullable: false),
                    Usado = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "DateTime", nullable: false),
                    NumeroComprobante = table.Column<int>(nullable: false),
                    TipoComprobanteEntrada = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobantesEntrada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprobanteEntrada_SubRubro",
                        column: x => x.SubRubroId,
                        principalTable: "SubRubros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComprobanteEntrada_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Precios",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UsuarioId = table.Column<long>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "DateTime", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "Numeric", nullable: false),
                    MaterialId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Precio_Material",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Precio_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UsuarioId = table.Column<long>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "DateTime", nullable: false),
                    StockActual = table.Column<int>(nullable: false),
                    StockMinimo = table.Column<int>(nullable: false),
                    MaterialId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Material",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stock_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operaciones",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CuentaCorrienteId = table.Column<long>(nullable: false),
                    Debe = table.Column<decimal>(type: "Numeric", nullable: true),
                    Haber = table.Column<decimal>(type: "Numeric", nullable: true),
                    Referencia = table.Column<long>(nullable: false),
                    Descontado = table.Column<decimal>(nullable: true),
                    DePara = table.Column<string>(nullable: true),
                    Concepto = table.Column<string>(nullable: true),
                    TipoOperacion = table.Column<int>(nullable: false),
                    CodigoCausal = table.Column<string>(maxLength: 250, nullable: true),
                    FechaEmision = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ReferenciaPlus = table.Column<string>(maxLength: 250, nullable: false),
                    EstaEnResumen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operacion_CuentaCorriente",
                        column: x => x.CuentaCorrienteId,
                        principalTable: "CuentaCorrientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComprobanteCompras",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Monto = table.Column<decimal>(nullable: false),
                    Descuento = table.Column<decimal>(nullable: false),
                    Iva = table.Column<decimal>(nullable: false),
                    Percepciones = table.Column<decimal>(nullable: false),
                    Recargos = table.Column<decimal>(nullable: false),
                    Retenciones = table.Column<decimal>(nullable: false),
                    ProveedorId = table.Column<long>(nullable: true),
                    ObraId = table.Column<long>(nullable: true),
                    TipoPago = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Pagado = table.Column<bool>(nullable: false),
                    EstadoCompra = table.Column<int>(nullable: false),
                    NumeroCompra = table.Column<int>(nullable: false),
                    Cuit = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Pagando = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprobanteCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprobanteCompra_Obra",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComprobanteCompra_Proveedor",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngresoMateriales",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "DateTime", nullable: false),
                    MaterialId = table.Column<long>(nullable: false),
                    ObraId = table.Column<long>(nullable: false),
                    EncargadoId = table.Column<long>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    CantidadDevuelta = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngresoMateriales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngresoMateriales_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngresoMaterial_Encargado",
                        column: x => x.EncargadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngresoMaterial_Material",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngresoMaterial_Obra",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jornales",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    NumeroOrden = table.Column<int>(nullable: false),
                    ObraId = table.Column<long>(nullable: false),
                    Viatico = table.Column<decimal>(nullable: false),
                    Multas = table.Column<decimal>(nullable: false),
                    Gasolina = table.Column<decimal>(nullable: false),
                    Repuestos = table.Column<decimal>(nullable: false),
                    Otros = table.Column<decimal>(nullable: false),
                    DiaJornal = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jornales_Obra",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObraEmpleados",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ObraId = table.Column<long>(nullable: false),
                    EmpleadoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObraEmpleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObraEmpleados_Empleado",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ObraEmpleado_Obra",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Presupuestos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Numero = table.Column<long>(nullable: false),
                    FechaPresupuesto = table.Column<DateTime>(type: "DateTime", nullable: false),
                    EstadoPresupuesto = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<long>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    Observacion = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    ObraId = table.Column<long>(nullable: false),
                    PrecioCliente = table.Column<decimal>(type: "Numeric", nullable: false),
                    EstadoDeCobro = table.Column<int>(nullable: false),
                    Cobrado = table.Column<decimal>(nullable: false),
                    Beneficio = table.Column<decimal>(type: "Numeric", nullable: false),
                    ImprevistoPorcentual = table.Column<decimal>(type: "Numeric", nullable: false),
                    Impuestos = table.Column<decimal>(type: "Numeric", nullable: false),
                    SubTotal = table.Column<decimal>(type: "Numeric", nullable: false),
                    Descuento = table.Column<decimal>(nullable: false),
                    Interes = table.Column<decimal>(nullable: false),
                    Percepciones = table.Column<decimal>(nullable: false),
                    Retenciones = table.Column<decimal>(nullable: false),
                    Iva = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuestos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presupuestos_Empresa",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presupuestos_Obra",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalidaMateriales",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    FechaEgreso = table.Column<DateTime>(type: "DateTime", nullable: false),
                    MaterialId = table.Column<long>(nullable: false),
                    DeObraId = table.Column<long>(nullable: false),
                    ResponsableId = table.Column<long>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    ParaObraId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalidaMateriales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalidaMaterialDe_DeObra",
                        column: x => x.DeObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalidaMaterial_Material",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalidaMaterialPara_ParaObra",
                        column: x => x.ParaObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalidaMaterial_Responsable",
                        column: x => x.ResponsableId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    DescripcionTareaId = table.Column<long>(nullable: false),
                    NumeroOrden = table.Column<int>(nullable: false),
                    Precede = table.Column<bool>(nullable: false),
                    Observacion = table.Column<string>(maxLength: 4000, nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    ObraId = table.Column<long>(nullable: false),
                    Duracion = table.Column<TimeSpan>(type: "Time", nullable: false),
                    TiempoEmpleado = table.Column<TimeSpan>(type: "Time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarea_DescripcionTarea",
                        column: x => x.DescripcionTareaId,
                        principalTable: "DescripcionTareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarea_Obra",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCajas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CajaId = table.Column<long>(nullable: false),
                    Monto = table.Column<decimal>(type: "Numeric", nullable: false),
                    TipoPago = table.Column<int>(nullable: false),
                    TipoMovimiento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCajas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleCaja_Caja",
                        column: x => x.CajaId,
                        principalTable: "Cajas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CajaId = table.Column<long>(nullable: false),
                    UsuarioId = table.Column<long>(nullable: false),
                    ComprobanteId = table.Column<long>(nullable: false),
                    FechaMovimiento = table.Column<DateTime>(type: "DateTime", nullable: false),
                    TipoMovimento = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(type: "Numeric", nullable: false),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimiento_Caja",
                        column: x => x.CajaId,
                        principalTable: "Cajas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimiento_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleComprobantes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ComprobanteId = table.Column<long>(nullable: false),
                    Codigo = table.Column<string>(nullable: false),
                    MaterialId = table.Column<long>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "Numeric", nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    SubTotal = table.Column<decimal>(type: "Numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleComprobantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleComprobante_Comprobante",
                        column: x => x.ComprobanteId,
                        principalTable: "ComprobanteCompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleComprobante_Material",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AsistenciaContratistas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ContratistaId = table.Column<long>(nullable: false),
                    JornalId = table.Column<long>(nullable: false),
                    Entrada = table.Column<TimeSpan>(nullable: false),
                    Salida = table.Column<TimeSpan>(nullable: false),
                    Observacion = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsistenciaContratistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsistenciasContratista_Contratista",
                        column: x => x.ContratistaId,
                        principalTable: "Contratistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AsistenciasContratista_Jornal",
                        column: x => x.JornalId,
                        principalTable: "Jornales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AsistenciaDiarias",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    EmpleadoId = table.Column<long>(nullable: false),
                    JornalId = table.Column<long>(nullable: false),
                    Asistio = table.Column<bool>(nullable: false),
                    Entrada = table.Column<TimeSpan>(nullable: false),
                    Salida = table.Column<TimeSpan>(nullable: false),
                    CausaId = table.Column<long>(nullable: true),
                    Observacion = table.Column<string>(maxLength: 250, nullable: false),
                    CausaId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsistenciaDiarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AsistenciaDiarias_CausaFalta",
                        column: x => x.CausaId,
                        principalTable: "CausaFaltas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AsistenciaDiarias_CausaFaltas_CausaId1",
                        column: x => x.CausaId1,
                        principalTable: "CausaFaltas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AsistenciaDiarias_Empleado",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AsistenciaDiarias_Jornal",
                        column: x => x.JornalId,
                        principalTable: "Jornales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JornalMateriales",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    MaterialId = table.Column<long>(nullable: false),
                    JornalId = table.Column<long>(nullable: false),
                    CantidadUsado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JornalMateriales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JornalMateriales_Jornal",
                        column: x => x.JornalId,
                        principalTable: "Jornales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JornalMateriales_Material",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gastos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    TipoGastoId = table.Column<long>(nullable: false),
                    Monto = table.Column<decimal>(type: "Numeric", nullable: false),
                    PresupuestoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gasto_Presupuesto",
                        column: x => x.PresupuestoId,
                        principalTable: "Presupuestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gasto_TipoGasto",
                        column: x => x.TipoGastoId,
                        principalTable: "TipoGastos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "CBU", "Cuit", "Descripcion", "EstaEliminado", "Mail", "NombreFantasia", "Path", "RazonSocial", "Sucursal", "Telefono" },
                values: new object[] { 1L, "12312312312", "12312321", "", false, "asd", "Banco Macro", "https://d1nzec96y7u1ro.cloudfront.net/wp-content/uploads/2017/10/24145915/macro_4-01.png", "Banco Macro", "Centro", "1231231" });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "CBU", "Cuit", "Descripcion", "EstaEliminado", "Mail", "NombreFantasia", "Path", "RazonSocial", "Sucursal", "Telefono" },
                values: new object[] { 2L, "12312312312", "12312321", "", false, "asd", "Banco Nacion", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Logo_Banco_de_la_Nacion_Argentina.svg/500px-Logo_Banco_de_la_Nacion_Argentina.svg.png", "Banco Nacion", "Centro", "1231231" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "SalarioMinimoId" },
                values: new object[] { 1L, "Auxiliar", false, 0L });

            migrationBuilder.InsertData(
                table: "Identificaciones",
                columns: new[] { "Id", "Administracion", "Configuracion", "EstaEliminado", "Obra", "Tesoreria", "Usuarios" },
                values: new object[] { 1L, true, true, false, true, true, true });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 18L, 3100000L, "Capital Social", false, 3 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 17L, 2600000L, "Otras Deudas Fiscales", false, 5 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 16L, 2500000L, "Deudas Sociales", false, 5 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 15L, 2400000L, "Deudas Financieras", false, 5 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 14L, 2300000L, "Deudas Bancarias", false, 5 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 13L, 2200000L, "Deudas Comerciales", false, 5 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 12L, 2100000L, "Activo No Corriente", false, 4 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 11L, 1200000L, "Activo No Corriente", false, 4 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 10L, 1100000L, "Activo Corriente", false, 4 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 8L, 5900000L, "Egreso financieros", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 19L, 3200000L, "Reservas", false, 3 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 7L, 5800000L, "Comericalizacion", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 6L, 5700000L, "Administracion", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 5L, 5600000L, "Vehiculos y maquinaria", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 4L, 550000L, "Produccion", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 3L, 4300000L, "Otros Ingresos", false, 1 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 2L, 4200000L, "Ingreso financiero", false, 1 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 1L, 4100000L, "Ingreso por ventas", false, 1 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 9L, 6000000L, "Otros Egresos", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 20L, 3300000L, "Resultado No Asignado", false, 3 });

            migrationBuilder.InsertData(
                table: "CuentaCorrientes",
                columns: new[] { "Id", "BancoId", "EmpresaId", "EstaEliminado", "MontoMaximo" },
                values: new object[] { 1L, 1L, null, false, 3800000m });

            migrationBuilder.InsertData(
                table: "CuentaCorrientes",
                columns: new[] { "Id", "BancoId", "EmpresaId", "EstaEliminado", "MontoMaximo" },
                values: new object[] { 2L, 2L, null, false, 3800000m });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "Id", "Apellido", "CUIT", "CategoriaId", "Celular", "Dni", "EstaEliminado", "FechaIncio", "FechaNacimiento", "Legajo", "Nombre", "Path", "Telefono" },
                values: new object[] { 1L, "Delgado", "3815451043", 1L, "3815451043", "38154510", false, new DateTime(2019, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Julian", "", "3815451043" });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 48L, 5712300L, "Servicios De Terceros", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 47L, 5712200L, "Sellados Y Permisos Municipales", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 46L, 5712100L, "Combustible", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 45L, 5712000L, "Gastos Generales", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 44L, 5711900L, "Gastos Judiciales", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 43L, 5711800L, "Estacionamiento", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 41L, 5711600L, "Seguros", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 49L, 5712400L, "Ieric - Insc. Anual Y Tarjetas", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 40L, 5711500L, "Gastos De Movilidad", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 39L, 5711400L, "Gastos De Viaje", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 38L, 5711300L, "Gastos De Representacion", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 37L, 5711100L, "Gastos De Refrigerio", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 36L, 5711000L, "Papeleria, Impresos Y Utiles", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 42L, 5711700L, "Franqueo", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 50L, 5712500L, "Alquileres", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 51L, 5712600L, "Mantenimeinto Y Limpieza", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 52L, 5712700L, "Fletes", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 53L, 5712800L, "Multas Impositivas", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 54L, 5712900L, "Gastos De Leasing", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 55L, 5800100L, "Honorarios Comerciales", false, 7L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 56L, 5800200L, "Publicidad Y Propaganda", false, 7L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 57L, 5800300L, "Gastos De Representacion", false, 7L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 58L, 5800400L, "Gastos De Viaje", false, 7L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 59L, 5800500L, "Donaciones", false, 7L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 60L, 5800700L, "Combustible", false, 7L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 61L, 5800600L, "Obsequios Empresariales", false, 7L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 62L, 5900100L, "Comisiones Y Gastos Bancarios", false, 8L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 63L, 5900200L, "Impuestos Al Deb Y Cred Bancarios", false, 8L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 64L, 5900300L, "Interes Bancario", false, 8L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 65L, 5900400L, "Interes Y Act. Org. Oficiales", false, 8L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 35L, 5710900L, "Servicio De Internet", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 34L, 5710800L, "Agua", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 33L, 5710700L, "Gas", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 32L, 5710600L, "Telefono", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 1L, 410100L, "Ingresos Por Obra", false, 1L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 2L, 410200L, "Ingresos Por Alquiler De Grua", false, 1L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 3L, 410300L, "Ingresos Por Venta De Materiales", false, 1L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 4L, 420100L, "Intereses Plazo Fijo", false, 2L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 5L, 430100L, "Reintegro Art", false, 3L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 6L, 430200L, "Venta Bs De Uso", false, 3L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 7L, 5510100L, "Materiales Utilizados", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 8L, 5510200L, "Personal De Produccion", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 9L, 5510300L, "Cargas Sociales Personal De Produccion", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 10L, 5510400L, "Honorarios Directos, Tec. Profesionales", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 11L, 5510500L, "Servicios De Terceros", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 12L, 5510600L, "Fletes", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 13L, 5510700L, "Equipo De Trabajo", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 14L, 5510800L, "Refrigerio De Obras", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 66L, 5900500L, "Redondeo", false, 8L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 15L, 5510900L, "Seguros Del Personal", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 17L, 5511100L, "Peajes", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 19L, 5511200L, "Gastos De Viaje", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 20L, 5511300L, "Permisos Municipales", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 21L, 5511400L, "Seguros De Caucion", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 22L, 5511500L, "Bienes Consumibles En Obra", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 23L, 5610100L, "Combustible", false, 5L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 24L, 5610200L, "Aceite Y Lubricantes", false, 5L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 25L, 5610300L, "Repuestos Y Reparaciones", false, 5L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 26L, 5610400L, "Seguros Automotores", false, 5L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 27L, 5710100L, "Honorarios Administracion", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 28L, 5710200L, "Honorarios Contables", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 29L, 5710300L, "Sueldos Administracion", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 30L, 5710400L, "Cargas Sociales Administracion", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 31L, 5710500L, "Luz", false, 6L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 16L, 5511000L, "Gastos Generales", false, 4L });

            migrationBuilder.InsertData(
                table: "SubRubros",
                columns: new[] { "Id", "Codigo", "Descripcion", "EstaEliminado", "RubroId" },
                values: new object[] { 67L, 5900600L, "Intereses Comerciales", false, 8L });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "Id", "Codigo", "Descripcion", "EncargadoId", "EstaEliminado", "EstadoObra", "FechaEstimadaInicio", "Observacion", "PropietarioId", "ZonaId" },
                values: new object[] { 1L, "", "Oficina", 1L, false, 0, new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(1344), null, null, null });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "Id", "Codigo", "Descripcion", "EncargadoId", "EstaEliminado", "EstadoObra", "FechaEstimadaInicio", "Observacion", "PropietarioId", "ZonaId" },
                values: new object[] { 2L, "", "Taller", 1L, false, 0, new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7462), null, null, null });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "Id", "Codigo", "Descripcion", "EncargadoId", "EstaEliminado", "EstadoObra", "FechaEstimadaInicio", "Observacion", "PropietarioId", "ZonaId" },
                values: new object[] { 3L, "Compras personales", "Alicia", 1L, false, 0, new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7468), null, null, null });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "Id", "Codigo", "Descripcion", "EncargadoId", "EstaEliminado", "EstadoObra", "FechaEstimadaInicio", "Observacion", "PropietarioId", "ZonaId" },
                values: new object[] { 4L, "Compras personales", "Carla", 1L, false, 0, new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7470), null, null, null });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "Id", "Codigo", "Descripcion", "EncargadoId", "EstaEliminado", "EstadoObra", "FechaEstimadaInicio", "Observacion", "PropietarioId", "ZonaId" },
                values: new object[] { 5L, "Compras personales", "Eduardo", 1L, false, 0, new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7471), null, null, null });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "Id", "Codigo", "Descripcion", "EncargadoId", "EstaEliminado", "EstadoObra", "FechaEstimadaInicio", "Observacion", "PropietarioId", "ZonaId" },
                values: new object[] { 6L, "Compras personales", "Marcos", 1L, false, 0, new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7475), null, null, null });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "Id", "Codigo", "Descripcion", "EncargadoId", "EstaEliminado", "EstadoObra", "FechaEstimadaInicio", "Observacion", "PropietarioId", "ZonaId" },
                values: new object[] { 7L, "Compras personales", "Pablo", 1L, false, 0, new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7478), null, null, null });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "Id", "Codigo", "Descripcion", "EncargadoId", "EstaEliminado", "EstadoObra", "FechaEstimadaInicio", "Observacion", "PropietarioId", "ZonaId" },
                values: new object[] { 8L, "Compras personales", "Raul", 1L, false, 0, new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7480), null, null, null });

            migrationBuilder.InsertData(
                table: "Obras",
                columns: new[] { "Id", "Codigo", "Descripcion", "EncargadoId", "EstaEliminado", "EstadoObra", "FechaEstimadaInicio", "Observacion", "PropietarioId", "ZonaId" },
                values: new object[] { 9L, "", "Otros", 1L, false, 0, new DateTime(2019, 10, 2, 15, 11, 34, 63, DateTimeKind.Local).AddTicks(7481), null, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaContratistas_ContratistaId",
                table: "AsistenciaContratistas",
                column: "ContratistaId");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaContratistas_JornalId",
                table: "AsistenciaContratistas",
                column: "JornalId");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaDiarias_CausaId",
                table: "AsistenciaDiarias",
                column: "CausaId");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaDiarias_CausaId1",
                table: "AsistenciaDiarias",
                column: "CausaId1");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaDiarias_EmpleadoId",
                table: "AsistenciaDiarias",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaDiarias_JornalId",
                table: "AsistenciaDiarias",
                column: "JornalId");

            migrationBuilder.CreateIndex(
                name: "IX_Cajas_UsuarioAperturaId",
                table: "Cajas",
                column: "UsuarioAperturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cajas_UsuarioCierreId",
                table: "Cajas",
                column: "UsuarioCierreId");

            migrationBuilder.CreateIndex(
                name: "IX_ChequesEntrada_BancoId",
                table: "ChequesEntrada",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChequesSalida_BancoId",
                table: "ChequesSalida",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteCompras_ObraId",
                table: "ComprobanteCompras",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteCompras_ProveedorId",
                table: "ComprobanteCompras",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteSalida_SubRubroId",
                table: "ComprobanteSalida",
                column: "SubRubroId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobanteSalida_UsuarioId",
                table: "ComprobanteSalida",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesEntrada_SubRubroId",
                table: "ComprobantesEntrada",
                column: "SubRubroId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprobantesEntrada_UsuarioId",
                table: "ComprobantesEntrada",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCorrientes_BancoId",
                table: "CuentaCorrientes",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCorrientes_EmpresaId",
                table: "CuentaCorrientes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_BancoId",
                table: "Depositos",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_EmpresaId",
                table: "Depositos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCajas_CajaId",
                table: "DetalleCajas",
                column: "CajaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobantes_ComprobanteId",
                table: "DetalleComprobantes",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobantes_MaterialId",
                table: "DetalleComprobantes",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_CategoriaId",
                table: "Empleados",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CondicionIvaId",
                table: "Empresas",
                column: "CondicionIvaId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaPagos_BancoId",
                table: "FormaPagos",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaPagos_CustomerId",
                table: "FormaPagos",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_PresupuestoId",
                table: "Gastos",
                column: "PresupuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_TipoGastoId",
                table: "Gastos",
                column: "TipoGastoId");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoMateriales_EmpresaId",
                table: "IngresoMateriales",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoMateriales_EncargadoId",
                table: "IngresoMateriales",
                column: "EncargadoId");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoMateriales_MaterialId",
                table: "IngresoMateriales",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoMateriales_ObraId",
                table: "IngresoMateriales",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Jornales_ObraId",
                table: "Jornales",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_JornalMateriales_JornalId",
                table: "JornalMateriales",
                column: "JornalId");

            migrationBuilder.CreateIndex(
                name: "IX_JornalMateriales_MaterialId",
                table: "JornalMateriales",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_CajaId",
                table: "Movimientos",
                column: "CajaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_UsuarioId",
                table: "Movimientos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ObraEmpleados_EmpleadoId",
                table: "ObraEmpleados",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ObraEmpleados_ObraId",
                table: "ObraEmpleados",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_EncargadoId",
                table: "Obras",
                column: "EncargadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_PropietarioId",
                table: "Obras",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_ZonaId",
                table: "Obras",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Operaciones_CuentaCorrienteId",
                table: "Operaciones",
                column: "CuentaCorrienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Precios_MaterialId",
                table: "Precios",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Precios_UsuarioId",
                table: "Precios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_EmpresaId",
                table: "Presupuestos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuestos_ObraId",
                table: "Presupuestos",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_CondicionIvaId",
                table: "Proveedores",
                column: "CondicionIvaId");

            migrationBuilder.CreateIndex(
                name: "IX_SalarioMinimos_CategoriaId",
                table: "SalarioMinimos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaMateriales_DeObraId",
                table: "SalidaMateriales",
                column: "DeObraId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaMateriales_MaterialId",
                table: "SalidaMateriales",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaMateriales_ParaObraId",
                table: "SalidaMateriales",
                column: "ParaObraId");

            migrationBuilder.CreateIndex(
                name: "IX_SalidaMateriales_ResponsableId",
                table: "SalidaMateriales",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_MaterialId",
                table: "Stocks",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_UsuarioId",
                table: "Stocks",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SubRubros_RubroId",
                table: "SubRubros",
                column: "RubroId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_DescripcionTareaId",
                table: "Tareas",
                column: "DescripcionTareaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_ObraId",
                table: "Tareas",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_BancoId",
                table: "Transferencias",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpleadoId",
                table: "Usuarios",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdentificacionId",
                table: "Usuarios",
                column: "IdentificacionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsistenciaContratistas");

            migrationBuilder.DropTable(
                name: "AsistenciaDiarias");

            migrationBuilder.DropTable(
                name: "ChequesEntrada");

            migrationBuilder.DropTable(
                name: "ChequesSalida");

            migrationBuilder.DropTable(
                name: "ComprobanteSalida");

            migrationBuilder.DropTable(
                name: "ComprobantesEntrada");

            migrationBuilder.DropTable(
                name: "Depositos");

            migrationBuilder.DropTable(
                name: "DetalleCajas");

            migrationBuilder.DropTable(
                name: "DetalleComprobantes");

            migrationBuilder.DropTable(
                name: "FormaPagos");

            migrationBuilder.DropTable(
                name: "Gastos");

            migrationBuilder.DropTable(
                name: "IngresoMateriales");

            migrationBuilder.DropTable(
                name: "JornalMateriales");

            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "ObraEmpleados");

            migrationBuilder.DropTable(
                name: "Operaciones");

            migrationBuilder.DropTable(
                name: "Precios");

            migrationBuilder.DropTable(
                name: "SalarioMinimos");

            migrationBuilder.DropTable(
                name: "SalidaMateriales");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Transferencias");

            migrationBuilder.DropTable(
                name: "Contratistas");

            migrationBuilder.DropTable(
                name: "CausaFaltas");

            migrationBuilder.DropTable(
                name: "SubRubros");

            migrationBuilder.DropTable(
                name: "ComprobanteCompras");

            migrationBuilder.DropTable(
                name: "Presupuestos");

            migrationBuilder.DropTable(
                name: "TipoGastos");

            migrationBuilder.DropTable(
                name: "Jornales");

            migrationBuilder.DropTable(
                name: "Cajas");

            migrationBuilder.DropTable(
                name: "CuentaCorrientes");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "DescripcionTareas");

            migrationBuilder.DropTable(
                name: "Rubros");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Bancos");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Zonas");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Identificaciones");

            migrationBuilder.DropTable(
                name: "CondicionIvas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
