using GestionObra.Dominio;
using GestionObra.Dominio.Entidades;
using GestionObra.Dominio.MetaData;
using System.Linq;

namespace GestionObra.Infraestructura
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;
    using static GestionObra.Conexion.Conexion;

    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ObtenerCadenaConexionSql,
                prov => prov.CommandTimeout(60)).EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cambiando la forma en que se borra de cascada a restricto
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;


            modelBuilder.Entity<AsistenciaContratista>().HasOne(x => x.Jornal)
          .WithMany(x => x.AsistenciaContratista)
          .HasForeignKey(x => x.JornalId)
          .HasConstraintName("FK_AsistenciasContratista_Jornal")
          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AsistenciaContratista>().HasOne(x => x.Contratista)
        .WithMany(x => x.AsistenciasContratista)
        .HasForeignKey(x => x.ContratistaId)
        .HasConstraintName("FK_AsistenciasContratista_Contratista")
        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AsistenciaDiaria>()
                .HasOne(x => x.Empleado)
                .WithMany(x => x.AsistenciaDiarias)
                .HasForeignKey(x => x.EmpleadoId)
                .HasConstraintName("FK_AsistenciaDiarias_Empleado");

            modelBuilder.Entity<AsistenciaDiaria>()
              .HasOne(x => x.Jornal)
              .WithMany(x => x.AsistenciaDiarias)
              .HasForeignKey(x => x.JornalId)
              .HasConstraintName("FK_AsistenciaDiarias_Jornal");

            modelBuilder.Entity<ObraEmpleado>()
              .HasOne(x => x.Empleado)
              .WithMany(x => x.ObraEmpleados)
              .HasForeignKey(x => x.EmpleadoId)
              .HasConstraintName("FK_ObraEmpleados_Empleado");
            modelBuilder.Entity<ObraEmpleado>()
            .HasOne(x => x.Obra)
            .WithMany(x => x.ObraEmpleados)
            .HasForeignKey(x => x.ObraId)
            .HasConstraintName("FK_ObraEmpleados_Obra");
            //Banco

            #region Banco

            modelBuilder.Entity<Banco>().HasMany(x => x.CuentaCorrientes)
                .WithOne(x => x.Banco)
                .HasForeignKey(x => x.BancoId)
                .HasConstraintName("FK_CuentaCorriente_Banco");

            modelBuilder.Entity<Banco>().HasMany(x => x.FormaPagoCheques)
               .WithOne(x => x.Banco)
               .HasForeignKey(x => x.BancoId)
               .HasConstraintName("FK_FormaPagoCheque_Banco");

            modelBuilder.Entity<Banco>().HasMany(x => x.Transferencias)
             .WithOne(x => x.Banco)
             .HasForeignKey(x => x.BancoId)
             .HasConstraintName("FK_Transferencia_Banco");

            modelBuilder.Entity<Banco>().HasMany(x => x.Depositos)
           .WithOne(x => x.Banco)
           .HasForeignKey(x => x.BancoId)
           .HasConstraintName("FK_Deposito_Banco");

            modelBuilder.Entity<Banco>().HasMany(x => x.ChequesEntrada)
            .WithOne(x => x.Banco)
            .HasForeignKey(x => x.BancoId)
            .HasConstraintName("FK_ChequeEntrada_Banco");
            modelBuilder.Entity<Banco>().HasMany(x => x.ChequesSalida)
          .WithOne(x => x.Banco)
          .HasForeignKey(x => x.BancoId)
          .HasConstraintName("FK_ChequeSalida_Banco");
            #endregion

            //Caja

            #region Caja

            modelBuilder.Entity<Caja>().HasMany(x => x.DetalleCajas)
                .WithOne(x => x.Caja)
                .HasForeignKey(x => x.CajaId)
                .HasConstraintName("FK_DetalleCaja_Caja");

            modelBuilder.Entity<Caja>().HasMany(x => x.Movimientos)
                .WithOne(x => x.Caja)
                .HasForeignKey(x => x.CajaId)
                .HasConstraintName("FK_Movimiento_Caja");

            modelBuilder.Entity<Caja>().HasOne(x => x.UsuarioApertura)
                .WithMany(x => x.CajaApertura)
                .HasForeignKey(x => x.UsuarioAperturaId)
                .HasConstraintName("FK_CajaApertura_UsuarioApertura")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Caja>().HasOne(x => x.UsuarioCierre)
                .WithMany(x => x.CajaCierre)
                .HasForeignKey(x => x.UsuarioCierreId)
                .HasConstraintName("FK_CajaCierre_UsuarioCierre")
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
            modelBuilder.Entity<CausaFalta>()
                .HasMany(x => x.AsistenciaDiarias)
                .WithOne()
                .HasForeignKey(x => x.CausaId)
                .HasConstraintName("FK_AsistenciaDiarias_CausaFalta");

            modelBuilder.Entity<Categoria>()
              .HasMany(x => x.Empleados)
              .WithOne(x => x.Categoria)
              .HasForeignKey(x => x.CategoriaId)
              .HasConstraintName("FK_Empleados_Categoria");

            modelBuilder.Entity<Categoria>()
             .HasMany(x => x.SalariosMinimo)
             .WithOne(x => x.Categoria)
             .HasForeignKey(x => x.CategoriaId)
             .HasConstraintName("FK_SalarioMinimo_Categoria");
            //Comprobante

            modelBuilder.Entity<ComprobanteCompra>()
              .HasOne(x => x.Obra)
              .WithMany(x => x.ComprobanteCompras)
              .HasForeignKey(x => x.ObraId)
              .HasConstraintName("FK_DetalleComprobante_ComprobanteCompra");

            modelBuilder.Entity<ComprobanteCompra>()
              .HasOne(x => x.Proveedor)
              .WithMany(x => x.ComprobanteCompras)
              .HasForeignKey(x => x.ObraId)
              .HasConstraintName("FK_DetalleComprobante_Proveedor");

            modelBuilder.Entity<ComprobanteCompra>()
              .HasMany(x => x.DetalleComprobantes)
              .WithOne(x => x.Comprobante)
              .HasForeignKey(x => x.ComprobanteId)
              .HasConstraintName("FK_DetalleComprobante_ComprobanteCompra");

            #region Comprobante

            modelBuilder.Entity<ComprobanteEntrada>().HasOne(x => x.SubRubro)
                .WithMany(x => x.ComprobantesEntrada)
                .HasForeignKey(x => x.SubRubroId)
                .HasConstraintName("FK_ComprobanteEntrada_SubRubro");

            modelBuilder.Entity<ComprobanteEntrada>().HasOne(x => x.Usuario)
                .WithMany(x => x.ComprobantesEntrada)
                .HasForeignKey(x => x.UsuarioId)
                .HasConstraintName("FK_ComprobanteEntrada_Usuario");

            modelBuilder.Entity<ComprobanteSalida>().HasOne(x => x.SubRubro)
             .WithMany(x => x.ComprobantesSalida)
             .HasForeignKey(x => x.SubRubroId)
             .HasConstraintName("FK_ComprobanteSalida_SubRubro");

            modelBuilder.Entity<ComprobanteSalida>().HasOne(x => x.Usuario)
                .WithMany(x => x.ComprobantesSalida)
                .HasForeignKey(x => x.UsuarioId)
                .HasConstraintName("FK_ComprobanteSalida_Usuario");

            //modelBuilder.Entity<Comprobante>().HasMany(x => x.FormaPagos)
            //    .WithOne(x => x.Comprobante)
            //    .HasForeignKey(x => x.ComprobanteId)
            //    .HasConstraintName("FK_FormaPagos_Comprobante");

            //modelBuilder.Entity<Comprobante>().HasMany(x => x.Movimientos)
            //    .WithOne(x => x.Comprobante)
            //    .HasForeignKey(x => x.ComprobanteId)
            //    .HasConstraintName("FK_Movimiento_Comprobante");

            #endregion
            modelBuilder.Entity<Contratista>().HasMany(x => x.AsistenciasContratista)
             .WithOne(x => x.Contratista)
             .HasForeignKey(x => x.ContratistaId)
             .HasConstraintName("FK_AsistenciasContratista_Contratista")
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChequeSalida>()
                .HasOne(x => x.Banco)
                .WithMany(x => x.ChequesSalida)
                .HasForeignKey(x => x.BancoId)
                .HasConstraintName("FK_ChequeSalida_Banco");

            modelBuilder.Entity<ChequeEntrada>()
               .HasOne(x => x.Banco)
               .WithMany(x => x.ChequesEntrada)
               .HasForeignKey(x => x.BancoId)
               .HasConstraintName("FK_ChequeEntrada_Banco");

            //CuentaCorriente

            #region CuentaCorriente
            modelBuilder.Entity<CuentaCorriente>().HasOne(x => x.Banco)
                .WithMany(x => x.CuentaCorrientes)
                .HasForeignKey(x => x.BancoId)
                .HasConstraintName("FK_CuentaCorriente_Banco");

            modelBuilder.Entity<CuentaCorriente>().HasMany(x => x.Operaciones)
                .WithOne(x => x.CuentaCorriente)
                .HasForeignKey(x => x.CuentaCorrienteId)
                .HasConstraintName("FK_Operacion_CuentaCorriente");



            #endregion

            //CondicionIva

            #region CondicionIva

            modelBuilder.Entity<CondicionIva>().HasMany(x => x.Empresas)
                .WithOne(x => x.CondicionIva)
                .HasForeignKey(x => x.CondicionIvaId)
                .HasConstraintName("FK_Empresa_CondicionIva");

            #endregion

            //DescripcionTarea

            #region DescripcionTarea

            modelBuilder.Entity<DescripcionTarea>().HasMany(x => x.Tareas)
                .WithOne(x => x.DescripcionTarea)
                .HasForeignKey(x => x.DescripcionTareaId)
                .HasConstraintName("FK_Tarea_DescripcionTarea");

            #endregion

            //DetalleCaja

            #region DetalleCaja

            modelBuilder.Entity<DetalleCaja>().HasOne(x => x.Caja)
                .WithMany(x => x.DetalleCajas)
                .HasForeignKey(x => x.CajaId)
                .HasConstraintName("FK_DetalleCaja_Caja");


            #endregion


            modelBuilder.Entity<Deposito>().HasOne(x => x.Banco)
                       .WithMany(x => x.Depositos)
                       .HasForeignKey(x => x.BancoId)
                       .HasConstraintName("FK_Banco_Deposito");


            modelBuilder.Entity<Transferencia>().HasOne(x => x.Banco)
                       .WithMany(x => x.Transferencias)
                       .HasForeignKey(x => x.BancoId)
                       .HasConstraintName("FK_Banco_Transferencia");


            //DetalleComprobante

            #region DetalleComprobante

            modelBuilder.Entity<DetalleComprobante>()
                .HasOne(x => x.Comprobante)
                .WithMany(x => x.DetalleComprobantes)
                .HasForeignKey(x => x.ComprobanteId)
                .HasConstraintName("FK_DetalleComprobante_Comprobante");

            modelBuilder.Entity<DetalleComprobante>()
             .HasOne(x => x.Material)
             .WithMany(x => x.DetalleComprobantes)
             .HasForeignKey(x => x.MaterialId)
             .HasConstraintName("FK_DetalleComprobante_Material");

            #endregion

            modelBuilder.Entity<Empleado>()
               .HasMany(x => x.Usuarios)
               .WithOne(x => x.Empleado)
               .HasForeignKey(x => x.EmpleadoId)
               .HasConstraintName("FK_Usuario_Empleado");

            modelBuilder.Entity<Empleado>()
                .HasMany(x => x.AsistenciaDiarias)
                .WithOne(x => x.Empleado)
                .HasForeignKey(x => x.EmpleadoId)
                .HasConstraintName("FK_AsistenciaDiarias_Empleado");
            modelBuilder.Entity<Empleado>()
            .HasMany(x => x.ObraEmpleados)
            .WithOne(x => x.Empleado)
            .HasForeignKey(x => x.EmpleadoId)
            .HasConstraintName("FK_ObraEmpleados_Empleado");


            //Empresa


            #region Empresa

            modelBuilder.Entity<Empresa>().HasOne(x => x.CondicionIva)
                .WithMany(x => x.Empresas)
                .HasForeignKey(x => x.CondicionIvaId)
                .HasConstraintName("FK_Empresa_CondicionIva");

            modelBuilder.Entity<Empresa>().HasMany(x => x.FormasPagoCtaCte)
              .WithOne(x => x.Customer)
              .HasForeignKey(x => x.CustomerId)
              .HasConstraintName("FK_FormaPagoCtaCte_Empresa");

            modelBuilder.Entity<Empresa>().HasMany(x => x.Obras)
                .WithOne(x => x.Propietario)
                .HasForeignKey(x => x.PropietarioId)
                .HasConstraintName("FK_Obra_Propietario")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Empresa>().HasMany(x => x.Presupuestos)
               .WithOne(x => x.Empresa)
               .HasForeignKey(x => x.EmpresaId)
               .HasConstraintName("FK_Presupuestos_Empresa");

            #endregion

            //FormaPago

            #region FormaPago

            //modelBuilder.Entity<FormaPago>().HasOne(x => x.Comprobante)
            //    .WithMany(x => x.FormaPagos)
            //    .HasForeignKey(x => x.ComprobanteId)
            //    .HasConstraintName("FK_FormaPago_Comprobante");

            #endregion

            //FormaPagoCtaCte
            #region FormaPagoCtaCte
            modelBuilder.Entity<FormaPagoCtaCte>().ToTable("FormaPagoCtaCte");
            modelBuilder.Entity<FormaPagoCtaCte>().HasOne(x => x.Customer)
               .WithMany(x => x.FormasPagoCtaCte)
               .HasForeignKey(x => x.CustomerId)
               .HasConstraintName("FK_FormaPagoCtaCte_Empresa");

            #endregion

            //FormaPagoCheque
            #region FormaPagoCheque
            modelBuilder.Entity<FormaPagoCheque>().ToTable("FormaPagoCheque");
            modelBuilder.Entity<FormaPagoCheque>().HasOne(x => x.Banco)
              .WithMany(x => x.FormaPagoCheques)
              .HasForeignKey(x => x.BancoId)
              .HasConstraintName("FK_FormaPagoCheque_Banco");

            #endregion

            //Gasto

            #region Gasto

            modelBuilder.Entity<Gasto>().HasOne(x => x.TipoGasto)
                .WithMany(x => x.Gastos)
                .HasForeignKey(x => x.TipoGastoId)
                .HasConstraintName("FK_Gasto_TipoGasto");

            modelBuilder.Entity<Gasto>().HasOne(x => x.Presupuesto)
                .WithMany(x => x.Gastos)
                .HasForeignKey(x => x.PresupuestoId)
                .HasConstraintName("FK_Gasto_Presupuesto");

            #endregion
            //IngresoMaterial

            #region IngresoMaterial

            modelBuilder.Entity<IngresoMaterial>().HasOne(x => x.Obra)
                .WithMany(x => x.IngresoMateriales)
                .HasForeignKey(x => x.ObraId)
                .HasConstraintName("FK_IngresoMaterial_Obra");

            modelBuilder.Entity<IngresoMaterial>().HasOne(x => x.Encargado)
                .WithMany(x => x.IngresoMateriales)
                .HasForeignKey(x => x.EncargadoId)
                .HasConstraintName("FK_IngresoMaterial_Encargado");

            modelBuilder.Entity<IngresoMaterial>().HasOne(x => x.Material)
                .WithMany(x => x.IngresoMateriales)
                .HasForeignKey(x => x.MaterialId)
                .HasConstraintName("FK_IngresoMaterial_Material");
            #endregion

            //Limitacion
            modelBuilder.Entity<Jornal>().HasOne(x => x.Obra)
               .WithMany(x => x.Jornales)
               .HasForeignKey(x => x.ObraId)
               .HasConstraintName("FK_Jornales_Obra")
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Jornal>().HasMany(x => x.AsistenciaContratista)
           .WithOne(x => x.Jornal)
           .HasForeignKey(x => x.JornalId)
           .HasConstraintName("FK_AsistenciasContratista_Jornal")
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Jornal>().HasMany(x => x.AsistenciaDiarias)
           .WithOne(x => x.Jornal)
           .HasForeignKey(x => x.JornalId)
           .HasConstraintName("FK_AsistenciaDiarias_Jornal");

            modelBuilder.Entity<Jornal>().HasMany(x => x.JornalMateriales)
            .WithOne(x => x.Jornal)
            .HasForeignKey(x => x.JornalId)
            .HasConstraintName("FK_JornalMateriales_Jornal");

            //TODO

            modelBuilder.Entity<JornalMaterial>().HasOne(x => x.Jornal)
               .WithMany(x => x.JornalMateriales)
               .HasForeignKey(x => x.JornalId)
               .HasConstraintName("FK_JornalMateriales_Jornal");

            modelBuilder.Entity<JornalMaterial>().HasOne(x => x.Material)
             .WithMany(x => x.JornalMateriales)
             .HasForeignKey(x => x.MaterialId)
             .HasConstraintName("FK_JornalMateriales_Material");
            //Material

            #region Material

            modelBuilder.Entity<Material>().HasMany(x => x.Precios)
                .WithOne(x => x.Material)
                .HasForeignKey(x => x.MaterialId)
                .HasConstraintName("FK_Precio_Material");

            modelBuilder.Entity<Material>().HasMany(x => x.JornalMateriales)
              .WithOne(x => x.Material)
              .HasForeignKey(x => x.MaterialId)
              .HasConstraintName("FK_JornalMateriales_Material");

            modelBuilder.Entity<Material>().HasMany(x => x.IngresoMateriales)
                .WithOne(x => x.Material)
                .HasForeignKey(x => x.MaterialId)
                .HasConstraintName("FK_IngresoMaterial_Material");

            modelBuilder.Entity<Material>().HasMany(x => x.SalidaMateriales)
                .WithOne(x => x.Material)
                .HasForeignKey(x => x.MaterialId)
                .HasConstraintName("FK_SalidaMaterial_Material");

            modelBuilder.Entity<Material>().HasMany(x => x.Stocks)
                .WithOne(x => x.Material)
                .HasForeignKey(x => x.MaterialId)
                .HasConstraintName("FK_Stock_Material");

            modelBuilder.Entity<Material>().HasMany(x => x.DetalleComprobantes)
               .WithOne(x => x.Material)
               .HasForeignKey(x => x.MaterialId)
               .HasConstraintName("FK_DetalleComprobante_Material");
            #endregion

            //Movimiento

            #region Movimiento

            //modelBuilder.Entity<Movimiento>().HasOne(x => x.Comprobante)
            //    .WithMany(x => x.Movimientos)
            //    .HasForeignKey(x => x.ComprobanteId)
            //    .HasConstraintName("FK_Movimiento_Comprobante");

            modelBuilder.Entity<Movimiento>().HasOne(x => x.Usuario)
                .WithMany(x => x.Movimientos)
                .HasForeignKey(x => x.UsuarioId)
                .HasConstraintName("FK_Movimiento_Usuario");

            modelBuilder.Entity<Movimiento>().HasOne(x => x.Caja)
                .WithMany(x => x.Movimientos)
                .HasForeignKey(x => x.CajaId)
                .HasConstraintName("FK_Movimiento_Caja");

            #endregion

            //Obra

            #region Obra

            modelBuilder.Entity<Obra>().HasOne(x => x.Propietario)
                .WithMany(x => x.Obras)
                .HasForeignKey(x => x.PropietarioId)
                .HasConstraintName("FK_Obra_Propietario")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Obra>().HasMany(x => x.ObraEmpleados)
              .WithOne(x => x.Obra)
              .HasForeignKey(x => x.ObraId)
              .HasConstraintName("FK_ObraEmpleado_Obra")
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Obra>().HasOne(x => x.Encargado)
                .WithMany(x => x.Obras)
                .HasForeignKey(x => x.EncargadoId)
                .HasConstraintName("FK_Obra_Encargado");

            modelBuilder.Entity<Obra>().HasOne(x => x.Zona)
                .WithMany(x => x.Obras)
                .HasForeignKey(x => x.ZonaId)
                .HasConstraintName("FK_Obra_Zona");

            modelBuilder.Entity<Obra>().HasMany(x => x.IngresoMateriales)
                .WithOne(x => x.Obra)
                .HasForeignKey(x => x.ObraId)
                .HasConstraintName("FK_IngresoMaterial_Obra");

            modelBuilder.Entity<Obra>().HasMany(x => x.SalidaMaterialesPara)
                .WithOne(x => x.ParaObra)
                .HasForeignKey(x => x.ParaObraId)
                .HasConstraintName("FK_SalidaMaterialPara_ParaObra")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Obra>().HasMany(x => x.SalidaMaterialesDe)
                .WithOne(x => x.DeObra)
                .HasForeignKey(x => x.DeObraId)
                .HasConstraintName("FK_SalidaMaterialDe_DeObra")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Obra>().HasMany(x => x.Jornales)
               .WithOne(x => x.Obra)
               .HasForeignKey(x => x.ObraId)
               .HasConstraintName("FK_Jornales_Obra")
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Obra>().HasMany(x => x.ComprobanteCompras)
               .WithOne(x => x.Obra)
               .HasForeignKey(x => x.ObraId)
               .HasConstraintName("FK_ComprobanteCompra_Obra")
               .OnDelete(DeleteBehavior.Restrict);
            #endregion

            modelBuilder.Entity<Operacion>().HasOne(x => x.CuentaCorriente)
              .WithMany(x => x.Operaciones)
              .HasForeignKey(x => x.CuentaCorrienteId)
              .HasConstraintName("FK_Operacion_CuentaCorriente");

            //Persona

            #region Persona

            modelBuilder.Entity<Empleado>().HasMany(x => x.Usuarios)
                .WithOne(x => x.Empleado)
                .HasForeignKey(x => x.EmpleadoId)
                .HasConstraintName("FK_Usuario_Empleado");

            #endregion
            modelBuilder.Entity<Proveedor>().HasMany(x => x.ComprobanteCompras)
           .WithOne(x => x.Proveedor)
           .HasForeignKey(x => x.ProveedorId)
           .HasConstraintName("FK_ComprobanteCompra_Proveedor");
            //Precio

            #region Precio

            modelBuilder.Entity<Precio>().HasOne(x => x.Material)
                .WithMany(x => x.Precios)
                .HasForeignKey(x => x.MaterialId)
                .HasConstraintName("FK_Precio_Material");
            modelBuilder.Entity<Precio>().HasOne(x => x.Usuario)
                .WithMany(x => x.Precios)
                .HasForeignKey(x => x.UsuarioId)
                .HasConstraintName("FK_Precio_Usuario");

            #endregion

            //Presupuesto

            #region Presupuesto

            modelBuilder.Entity<Presupuesto>().HasMany(x => x.Gastos)
                .WithOne(x => x.Presupuesto)
                .HasForeignKey(x => x.PresupuestoId)
                .HasConstraintName("FK_Gasto_Presupuesto");

            modelBuilder.Entity<Presupuesto>().HasOne(x => x.Empresa)
                .WithMany(x => x.Presupuestos)
                .HasForeignKey(x => x.EmpresaId)
                .HasConstraintName("FK_Presupuestos_Empresa");

            modelBuilder.Entity<Presupuesto>()
                .HasOne(x => x.Obra)
                .WithMany()
                .HasForeignKey(x => x.ObraId)
               .HasConstraintName("FK_Presupuestos_Obra");

            #endregion

            //Rubro

            #region Rubro

            modelBuilder.Entity<Rubro>().HasMany(x => x.SubRubros)
                .WithOne(x => x.Rubro)
                .HasForeignKey(x => x.RubroId)
                .HasConstraintName("FK_SubRubro_Rubro");


            #endregion


            modelBuilder.Entity<SalarioMinimo>().HasOne(x => x.Categoria)
              .WithMany(x => x.SalariosMinimo)
              .HasForeignKey(x => x.CategoriaId)
              .HasConstraintName("FK_SalarioMinimo_Categorias");

            //SalidaMaterial

            #region SalidaMaterial
            modelBuilder.Entity<SalidaMaterial>().HasOne(x => x.Material)
                .WithMany(x => x.SalidaMateriales)
                .HasForeignKey(x => x.MaterialId)
                .HasConstraintName("FK_SalidaMaterial_Material");

            modelBuilder.Entity<SalidaMaterial>().HasOne(x => x.Responsable)
                .WithMany(x => x.SalidaMateriales)
                .HasForeignKey(x => x.ResponsableId)
                .HasConstraintName("FK_SalidaMaterial_Responsable");

            modelBuilder.Entity<SalidaMaterial>().HasOne(x => x.DeObra)
                .WithMany(x => x.SalidaMaterialesDe)
                .HasForeignKey(x => x.DeObraId)
                .HasConstraintName("FK_SalidaMaterialDe_DeObra")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalidaMaterial>().HasOne(x => x.ParaObra)
                .WithMany(x => x.SalidaMaterialesPara)
                .HasForeignKey(x => x.ParaObraId)
                .HasConstraintName("FK_SalidaMaterialPara_ParaObra")
                .OnDelete(DeleteBehavior.Restrict);



            #endregion

            //Stock

            #region Stock
            modelBuilder.Entity<Stock>().HasOne(x => x.Material)
                .WithMany(x => x.Stocks)
                .HasForeignKey(x => x.MaterialId)
                .HasConstraintName("FK_Stock_Material");

            modelBuilder.Entity<Stock>().HasOne(x => x.Usuario)
                .WithMany(x => x.Stocks)
                .HasForeignKey(x => x.UsuarioId)
                .HasConstraintName("FK_Stock_Usuario");



            #endregion


            //SubRubro
            #region SubRubro
            modelBuilder.Entity<SubRubro>().HasOne(x => x.Rubro)
               .WithMany(x => x.SubRubros)
               .HasForeignKey(x => x.RubroId)
               .HasConstraintName("FK_SubRubro_Rubro");

            modelBuilder.Entity<SubRubro>().HasMany(x => x.ComprobantesSalida)
               .WithOne(x => x.SubRubro)
               .HasForeignKey(x => x.SubRubroId)
               .HasConstraintName("FK_ComprobanteSalida_SubRubro");
            modelBuilder.Entity<SubRubro>().HasMany(x => x.ComprobantesEntrada)
   .WithOne(x => x.SubRubro)
   .HasForeignKey(x => x.SubRubroId)
   .HasConstraintName("FK_ComprobanteEntrada_SubRubro");
            #endregion

            //Tarea

            #region Tarea

            modelBuilder.Entity<Tarea>().HasOne(x => x.Obra)
                .WithMany(x => x.Tareas)
                .HasForeignKey(x => x.ObraId)
                .HasConstraintName("FK_Tarea_Obra");

            modelBuilder.Entity<Tarea>().HasOne(x => x.DescripcionTarea)
                .WithMany(x => x.Tareas)
                .HasForeignKey(x => x.DescripcionTareaId)
                .HasConstraintName("FK_Tarea_DescripcionTarea");

            #endregion

            //TipoGasto

            #region TipoGasto

            modelBuilder.Entity<TipoGasto>().HasMany(x => x.Gastos)
                .WithOne(x => x.TipoGasto)
                .HasForeignKey(x => x.TipoGastoId)
                .HasConstraintName("FK_Gasto_TipoGasto");

            #endregion

            //Usuario

            #region Usuario

            modelBuilder.Entity<Usuario>().HasOne(x => x.Empleado)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.EmpleadoId)
                .HasConstraintName("FK_Usuario_Persona");
            modelBuilder.Entity<Usuario>().HasOne<Identificacion>(x => x.Identificacion)
             .WithOne(x => x.Usuario)
             .HasForeignKey<Usuario>(x => x.IdentificacionId)
             .HasConstraintName("FK_Usuario_Identificacion");
            modelBuilder.Entity<Identificacion>().HasOne<Usuario>(x => x.Usuario)
               .WithOne(x => x.Identificacion)
               .HasForeignKey<Usuario>(x => x.IdentificacionId)
               .HasConstraintName("FK_Usuario_Identificacion");
            modelBuilder.Entity<Usuario>().HasMany(x => x.CajaApertura)
                .WithOne(x => x.UsuarioApertura)
                .HasForeignKey(x => x.UsuarioAperturaId)
                .HasConstraintName("FK_CajaApertura_UsuarioApertura")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>().HasMany(x => x.CajaCierre)
                .WithOne(x => x.UsuarioCierre)
                .HasForeignKey(x => x.UsuarioCierreId)
                .HasConstraintName("FK_CajaCierre_UsuarioCierre")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>().HasMany(x => x.Precios)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId)
                .HasConstraintName("FK_Precio_Usuario")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>().HasMany(x => x.Movimientos)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId)
                .HasConstraintName("FK_Movimiento_Usuario");

            modelBuilder.Entity<Usuario>().HasMany(x => x.ComprobantesSalida)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId)
                .HasConstraintName("FK_ComprobanteSalida_Usuario");
            modelBuilder.Entity<Usuario>().HasMany(x => x.ComprobantesEntrada)
              .WithOne(x => x.Usuario)
              .HasForeignKey(x => x.UsuarioId)
              .HasConstraintName("FK_ComprobanteEntrada_Usuario");
            modelBuilder.Entity<Usuario>().HasMany(x => x.Stocks)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId)
                .HasConstraintName("FK_Stock_Usuario");

            #endregion

            //Zona

            #region Zona

            modelBuilder.Entity<Zona>().HasMany(x => x.Obras)
                .WithOne(x => x.Zona)
                .HasForeignKey(x => x.ZonaId)
                .HasConstraintName("FK_Obra_Zona");


            #endregion

            //Configuracion de las entidades


            #region Configuracion de las entidades

            modelBuilder.ApplyConfiguration<ChequeSalida>(new ChequeSalidaMetadata());
            modelBuilder.ApplyConfiguration<ChequeEntrada>(new ChequeEntradaMetadata());
            modelBuilder.ApplyConfiguration<Contratista>(new ContratistaMetadata());
            modelBuilder.ApplyConfiguration<Empleado>(new EmpleadoMetadata());
            modelBuilder.ApplyConfiguration<AsistenciaContratista>(new AsistenciaContratistaMetadata());
            modelBuilder.ApplyConfiguration<AsistenciaDiaria>(new AsistenciaDiariaMetadata());
            modelBuilder.ApplyConfiguration<Deposito>(new DepositoMetadata());
            modelBuilder.ApplyConfiguration<Transferencia>(new TransferenciaMetadata());
            modelBuilder.ApplyConfiguration<Banco>(new BancoMetadata());
            modelBuilder.ApplyConfiguration<Caja>(new CajaMetadata());
            modelBuilder.ApplyConfiguration<Categoria>(new CategoriaMetadata());
            modelBuilder.ApplyConfiguration<CausaFalta>(new CausaFaltaMetadato());
            modelBuilder.ApplyConfiguration<ComprobanteEntrada>(new ComprobanteEntradaMetadata());
            modelBuilder.ApplyConfiguration<ComprobanteSalida>(new ComprobanteSalidaMetadata());
            modelBuilder.ApplyConfiguration<Operacion>(new OperacionMetadata());
            modelBuilder.ApplyConfiguration<Identificacion>(new IdentificacionMetadata());
            modelBuilder.ApplyConfiguration<CondicionIva>(new CondicionIvaMetadata());
            modelBuilder.ApplyConfiguration<CuentaCorriente>(new CuentaCorrienteMetadata());
            modelBuilder.ApplyConfiguration<DescripcionTarea>(new DescripcionTareaMetadata());
            modelBuilder.ApplyConfiguration<DetalleCaja>(new DetalleCajaMetadata());
            modelBuilder.ApplyConfiguration<DetalleComprobante>(new DetalleComprobanteMetadata());
            modelBuilder.ApplyConfiguration<Jornal>(new JornalMetadato());
            modelBuilder.ApplyConfiguration<JornalMaterial>(new JornalMaterialMetadato());
            modelBuilder.ApplyConfiguration<ObraEmpleado>(new JornalEmpleadoMetadato());
            modelBuilder.ApplyConfiguration<Empresa>(new EmpresaMetadata());
            modelBuilder.ApplyConfiguration<FormaPago>(new FormaPagoMetadata());
            modelBuilder.ApplyConfiguration<FormaPagoCheque>(new FormaPagoChequeMetadata());
            modelBuilder.ApplyConfiguration<FormaPagoCtaCte>(new FormaPagoCtaCteMetadata());
            modelBuilder.ApplyConfiguration<Gasto>(new GastoMetadata());
            modelBuilder.ApplyConfiguration<IngresoMaterial>(new IngresoMaterialMetadata());
            modelBuilder.ApplyConfiguration<Material>(new MaterialMetadata());
            modelBuilder.ApplyConfiguration<Movimiento>(new MovimientoMetadata());
            modelBuilder.ApplyConfiguration<Obra>(new ObraMetadata());
            modelBuilder.ApplyConfiguration<Precio>(new PrecioMetadata());
            modelBuilder.ApplyConfiguration<Presupuesto>(new PresupuestoMetadata());
            modelBuilder.ApplyConfiguration<Rubro>(new RubroMetadata());
            modelBuilder.ApplyConfiguration<SalidaMaterial>(new SalidaMaterialMetadata());
            modelBuilder.ApplyConfiguration<SalarioMinimo>(new SalarioMinimoMetadata());
            modelBuilder.ApplyConfiguration<SubRubro>(new SubRubroMetadata());
            modelBuilder.ApplyConfiguration<Stock>(new StockMetadata());
            modelBuilder.ApplyConfiguration<Tarea>(new TareaMetadata());
            modelBuilder.ApplyConfiguration<TipoGasto>(new TipoGastoMetadata());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioMetadata());
            modelBuilder.ApplyConfiguration<Zona>(new ZonaMetadata());

            #endregion

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entidad in ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted
                            && x.OriginalValues.Properties
                                .Any(p => p.Name.Contains("EstaEliminado"))))
            {
                entidad.State = EntityState.Unchanged;
                entidad.CurrentValues["EstaEliminado"] = true;
            }

            return base.SaveChangesAsync();
        }

        #region DbSets

        public DbSet<AsistenciaContratista> AsistenciaContratistas { get; set; }
        public DbSet<AsistenciaDiaria> AsistenciaDiarias { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<ChequeEntrada> ChequesEntrada { get; set; }
        public DbSet<ChequeSalida> ChequesSalida { get; set; }
        public DbSet<CausaFalta> CausaFaltas { get; set; }
        public DbSet<Caja> Cajas { get; set; }
        public DbSet<Contratista> Contratistas { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<ComprobanteEntrada> ComprobantesEntrada { get; set; }
        public DbSet<Identificacion> Identificaciones { get; set; }
        public DbSet<ComprobanteSalida> ComprobantesSalida { get; set; }
        public DbSet<ComprobanteCompra> ComprobanteCompras { get; set; }
        public DbSet<ObraEmpleado> ObraEmpleados { get; set; }
        public DbSet<JornalMaterial> JornalMateriales { get; set; }
        public DbSet<Jornal> Jornales { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CondicionIva> CondicionIvas { get; set; }
        public DbSet<CuentaCorriente> CuentaCorrientes { get; set; }
        public DbSet<DescripcionTarea> DescripcionTareas { get; set; }
        public DbSet<DetalleCaja> DetalleCajas { get; set; }
        public DbSet<DetalleComprobante> DetalleComprobantes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<FormaPago> FormaPagos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<IngresoMaterial> IngresoMateriales { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Precio> Precios { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<SalidaMaterial> SalidaMateriales { get; set; }
        public DbSet<SalarioMinimo> SalarioMinimos { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<SubRubro> SubRubros { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<TipoGasto> TipoGastos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Zona> Zonas { get; set; }

        #endregion

    }
}
