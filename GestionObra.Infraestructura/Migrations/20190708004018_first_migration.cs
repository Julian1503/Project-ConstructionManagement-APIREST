using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionObra.Infraestructura.Migrations
{
    public partial class first_migration : Migration
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
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.Id);
                });

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
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Nombre = table.Column<string>(maxLength: 250, nullable: false),
                    Apellido = table.Column<string>(maxLength: 250, nullable: false),
                    Dni = table.Column<string>(maxLength: 8, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Telefono = table.Column<string>(maxLength: 20, nullable: true),
                    Celular = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Sexo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Presupuestos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ImprevistoPesos = table.Column<decimal>(type: "Numeric", nullable: false),
                    ImprevistoPorcentual = table.Column<decimal>(type: "Numeric", nullable: false),
                    EstadoPresupuesto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuestos", x => x.Id);
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
                    Descripcion = table.Column<string>(nullable: false)
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
                    LimitacionesId = table.Column<long>(nullable: false),
                    PersonaId = table.Column<long>(nullable: false),
                    EstaBloqueado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gasto",
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
                    table.PrimaryKey("PK_Gasto", x => x.Id);
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
                    Observiacion = table.Column<string>(maxLength: 4000, nullable: false),
                    FechaEstimadaInicio = table.Column<DateTime>(type: "DateTime", nullable: false),
                    PropietarioId = table.Column<long>(nullable: false),
                    EncargadoId = table.Column<long>(nullable: false),
                    ZonaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obra_Encargado",
                        column: x => x.EncargadoId,
                        principalTable: "Personas",
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
                name: "Comprobantes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    NumeroComprobante = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(type: "DateTime", nullable: false),
                    EmpresaId = table.Column<long>(nullable: false),
                    UsuarioId = table.Column<long>(nullable: false),
                    RubroId = table.Column<long>(nullable: false),
                    Descuento = table.Column<decimal>(type: "Numeric", nullable: false),
                    Monto = table.Column<decimal>(type: "Numeric", nullable: false),
                    Detalle = table.Column<string>(maxLength: 400, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Perioricidad = table.Column<int>(nullable: true),
                    TipoComprobanteSalida = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comprobante_Empresa",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comprobante_Rubro",
                        column: x => x.RubroId,
                        principalTable: "Rubros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comprobante_Usuario",
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
                    PropietarioId = table.Column<long>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngresoMateriales", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_IngresoMaterial_Propietario",
                        column: x => x.PropietarioId,
                        principalTable: "Empresas",
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
                        principalTable: "Personas",
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
                    TipoPago = table.Column<int>(nullable: false)
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
                name: "CuentaCorrientes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    BancoId = table.Column<long>(nullable: false),
                    ClienteId = table.Column<long>(nullable: false),
                    ComprobanteId = table.Column<long>(nullable: false),
                    TotalVendido = table.Column<decimal>(type: "Numeric", nullable: false),
                    TotalCobrado = table.Column<decimal>(type: "Numeric", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "DateTime", nullable: false)
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
                        name: "FK_CuentaCorriente_Cliente",
                        column: x => x.ClienteId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CuentaCorriente_Comprobante",
                        column: x => x.ComprobanteId,
                        principalTable: "Comprobantes",
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
                        principalTable: "Comprobantes",
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
                    Monto = table.Column<decimal>(type: "Numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormaPago_Comprobante",
                        column: x => x.ComprobanteId,
                        principalTable: "Comprobantes",
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
                        name: "FK_Movimiento_Comprobante",
                        column: x => x.ComprobanteId,
                        principalTable: "Comprobantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimiento_Usuario",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "Descripcion", "EstaEliminado" },
                values: new object[] { 1L, "BANCO MACRO", false });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "Descripcion", "EstaEliminado" },
                values: new object[] { 2L, "BANCO NACION", false });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "Descripcion", "EstaEliminado" },
                values: new object[] { 3L, "ICBC", false });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "Descripcion", "EstaEliminado" },
                values: new object[] { 4L, "BBVA", false });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "Descripcion", "EstaEliminado" },
                values: new object[] { 5L, "GALICIA", false });

            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "Descripcion", "EstaEliminado" },
                values: new object[] { 6L, "SANTANDER RIO", false });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 19L, "Mantenimiento", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 20L, "Materiales", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 21L, "Préstamo", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 22L, " Refrigerios Administración", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 23L, " Refrigerios Comercial", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 24L, " Refrigerios Obras", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 27L, "Servicios", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 26L, "Salarios", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 18L, "Limpieza Taller", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 28L, "Vehículo", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 29L, "Viáticos Administración", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 30L, "Viáticos Comercial", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 31L, "Viáticos Taller", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 25L, "Repuestos", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 17L, "Limpieza Administración", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 14L, "Honorarios Administración", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 15L, "Honorarios Terceros", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 1L, "Banco", false, 1 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 2L, "Cheque", false, 1 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 3L, "Devolucion", false, 1 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 4L, "Inversión", false, 1 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 5L, "Otro", false, 1 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 6L, "Préstamo", false, 1 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 16L, "Impuestos", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 7L, "Ventas", false, 1 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 9L, "Anticipos Administración", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 10L, "Contratistas", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 11L, "Depósito", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 12L, "Gastos Administrativos", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 13L, "Gastos Varios", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 32L, "Alquiler", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 8L, "Anticipos", false, 2 });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Descripcion", "EstaEliminado", "TipoRubro" },
                values: new object[] { 33L, "Otro", false, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Cajas_UsuarioAperturaId",
                table: "Cajas",
                column: "UsuarioAperturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cajas_UsuarioCierreId",
                table: "Cajas",
                column: "UsuarioCierreId");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_EmpresaId",
                table: "Comprobantes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_RubroId",
                table: "Comprobantes",
                column: "RubroId");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_UsuarioId",
                table: "Comprobantes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCorrientes_BancoId",
                table: "CuentaCorrientes",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCorrientes_ClienteId",
                table: "CuentaCorrientes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCorrientes_ComprobanteId",
                table: "CuentaCorrientes",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCajas_CajaId",
                table: "DetalleCajas",
                column: "CajaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobantes_ComprobanteId",
                table: "DetalleComprobantes",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CondicionIvaId",
                table: "Empresas",
                column: "CondicionIvaId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaPagos_ComprobanteId",
                table: "FormaPagos",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasto_PresupuestoId",
                table: "Gasto",
                column: "PresupuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Gasto_TipoGastoId",
                table: "Gasto",
                column: "TipoGastoId");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoMateriales_MaterialId",
                table: "IngresoMateriales",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoMateriales_ObraId",
                table: "IngresoMateriales",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_IngresoMateriales_PropietarioId",
                table: "IngresoMateriales",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_CajaId",
                table: "Movimientos",
                column: "CajaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_ComprobanteId",
                table: "Movimientos",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_UsuarioId",
                table: "Movimientos",
                column: "UsuarioId");

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
                name: "IX_Precios_MaterialId",
                table: "Precios",
                column: "MaterialId");

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
                name: "IX_Tareas_DescripcionTareaId",
                table: "Tareas",
                column: "DescripcionTareaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_ObraId",
                table: "Tareas",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usuarios",
                column: "PersonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprobanteEntradas");

            migrationBuilder.DropTable(
                name: "CuentaCorrientes");

            migrationBuilder.DropTable(
                name: "DetalleCajas");

            migrationBuilder.DropTable(
                name: "DetalleComprobantes");

            migrationBuilder.DropTable(
                name: "FormaPagos");

            migrationBuilder.DropTable(
                name: "Gasto");

            migrationBuilder.DropTable(
                name: "IngresoMateriales");

            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Precios");

            migrationBuilder.DropTable(
                name: "SalidaMateriales");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Bancos");

            migrationBuilder.DropTable(
                name: "Presupuestos");

            migrationBuilder.DropTable(
                name: "TipoGastos");

            migrationBuilder.DropTable(
                name: "Cajas");

            migrationBuilder.DropTable(
                name: "Comprobantes");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "DescripcionTareas");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "Rubros");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Zonas");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "CondicionIvas");
        }
    }
}
