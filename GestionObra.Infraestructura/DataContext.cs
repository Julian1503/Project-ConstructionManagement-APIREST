using System.Linq;
using System.Security.Cryptography.X509Certificates;
using GestionObra.Dominio;
using GestionObra.Dominio.Entidades;
using GestionObra.Dominio.MetaData;

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
            optionsBuilder.UseSqlServer(ObtenerCadenaConexionWin,
                prov => prov.CommandTimeout(60));
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

            //Banco

            #region Banco

            modelBuilder.Entity<Banco>().HasMany(x => x.CuentaCorrientes)
                .WithOne(x=>x.Banco)
                .HasForeignKey(x=>x.BancoId)
                .HasConstraintName("FK_CuentaCorriente_Banco");

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

            //Comprobante

            #region Comprobante

            modelBuilder.Entity<Comprobante>().HasOne(x => x.Empresa)
                .WithMany(x => x.Comprobantes)
                .HasForeignKey(x => x.EmpresaId)
                .HasConstraintName("FK_Comprobante_Empresa");

            modelBuilder.Entity<Comprobante>().HasOne(x => x.Rubro)
                .WithMany(x => x.Comprobantes)
                .HasForeignKey(x => x.RubroId)
                .HasConstraintName("FK_Comprobante_Rubro");

            modelBuilder.Entity<Comprobante>().HasOne(x => x.Usuario)
                .WithMany(x => x.Comprobantes)
                .HasForeignKey(x => x.UsuarioId)
                .HasConstraintName("FK_Comprobante_Usuario");

            modelBuilder.Entity<Comprobante>()
                .HasMany(x => x.DetalleComprobantes)
                .WithOne(x => x.Comprobante)
                .HasForeignKey(x => x.ComprobanteId)
                .HasConstraintName("FK_DetalleComprobante_Comprobante");

            modelBuilder.Entity<Comprobante>().HasMany(x => x.CuentaCorrientes)
                .WithOne(x => x.Comprobante)
                .HasForeignKey(x => x.ComprobanteId)
                .HasConstraintName("FK_CuentaCorriente_Comprobante");

            modelBuilder.Entity<Comprobante>().HasMany(x => x.FormaPagos)
                .WithOne(x => x.Comprobante)
                .HasForeignKey(x => x.ComprobanteId)
                .HasConstraintName("FK_FormaPagos_Comprobante");

            modelBuilder.Entity<Comprobante>().HasMany(x => x.Movimientos)
                .WithOne(x => x.Comprobante)
                .HasForeignKey(x => x.ComprobanteId)
                .HasConstraintName("FK_Movimiento_Comprobante");

            #endregion

            //CuentaCorriente

            #region CuentaCorriente
            modelBuilder.Entity<CuentaCorriente>().HasOne(x => x.Banco)
                .WithMany(x => x.CuentaCorrientes)
                .HasForeignKey(x => x.BancoId)
                .HasConstraintName("FK_CuentaCorriente_Banco");

            modelBuilder.Entity<CuentaCorriente>().HasOne(x => x.Comprobante)
                .WithMany(x => x.CuentaCorrientes)
                .HasForeignKey(x => x.ComprobanteId)
                .HasConstraintName("FK_CuentaCorriente_Comprobante");

            modelBuilder.Entity<CuentaCorriente>().HasOne(x => x.Cliente)
                .WithMany(x => x.CuentaCorrientes)
                .HasForeignKey(x => x.ClienteId)
                .HasConstraintName("FK_CuentaCorriente_Cliente");


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

            //DetalleComprobante

            #region DetalleComprobante

            modelBuilder.Entity<DetalleComprobante>()
                .HasOne(x => x.Comprobante)
                .WithMany(x => x.DetalleComprobantes)
                .HasForeignKey(x => x.ComprobanteId)
                .HasConstraintName("FK_DetalleComprobante_Comprobante");

            #endregion

            //Empresa

            #region Empresa

            modelBuilder.Entity<Empresa>().HasOne(x => x.CondicionIva)
                .WithMany(x => x.Empresas)
                .HasForeignKey(x => x.CondicionIvaId)
                .HasConstraintName("FK_Empresa_CondicionIva");

            modelBuilder.Entity<Empresa>().HasMany(x => x.Comprobantes)
                .WithOne(x => x.Empresa)
                .HasForeignKey(x => x.EmpresaId)
                .HasConstraintName("FK_Comprobante_Empresa");

            modelBuilder.Entity<Empresa>().HasMany(x => x.IngresoMateriales)
                .WithOne(x => x.Propietario)
                .HasForeignKey(x => x.PropietarioId)
                .HasConstraintName("FK_IngresoMateriales_Propietario");

            modelBuilder.Entity<Empresa>().HasMany(x => x.CuentaCorrientes)
                .WithOne(x => x.Cliente)
                .HasForeignKey(x => x.ClienteId)
                .HasConstraintName("FK_CuentaCorriente_Cliente");

            modelBuilder.Entity<Empresa>().HasMany(x => x.Obras)
                .WithOne(x => x.Empresa)
                .HasForeignKey(x => x.PropietarioId)
                .HasConstraintName("FK_Obra_Propietario")
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            //FormaPago

            #region FormaPago

            modelBuilder.Entity<FormaPago>().HasOne(x => x.Comprobante)
                .WithMany(x => x.FormaPagos)
                .HasForeignKey(x => x.ComprobanteId)
                .HasConstraintName("FK_FormaPago_Comprobante");

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

            modelBuilder.Entity<IngresoMaterial>().HasOne(x => x.Propietario)
                .WithMany(x => x.IngresoMateriales)
                .HasForeignKey(x => x.PropietarioId)
                .HasConstraintName("FK_IngresoMaterial_Propietario");

            modelBuilder.Entity<IngresoMaterial>().HasOne(x => x.Material)
                .WithMany(x => x.IngresoMateriales)
                .HasForeignKey(x => x.MaterialId)
                .HasConstraintName("FK_IngresoMaterial_Material");
            #endregion

            //Limitacion
            //TODO

            //Material

            #region Material

            modelBuilder.Entity<Material>().HasMany(x => x.Precios)
                .WithOne(x => x.Material)
                .HasForeignKey(x => x.MaterialId)
                .HasConstraintName("FK_Precio_Material");

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
            #endregion

            //Movimiento

            #region Movimiento

            modelBuilder.Entity<Movimiento>().HasOne(x => x.Comprobante)
                .WithMany(x => x.Movimientos)
                .HasForeignKey(x => x.ComprobanteId)
                .HasConstraintName("FK_Movimiento_Comprobante");

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

            modelBuilder.Entity<Obra>().HasOne(x => x.Empresa)
                .WithMany(x => x.Obras)
                .HasForeignKey(x => x.PropietarioId)
                .HasConstraintName("FK_Obra_Propietario")
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

            modelBuilder.Entity<Obra>().HasMany(x => x.Tareas)
                .WithOne(x => x.Obra)
                .HasForeignKey(x => x.ObraId)
                .HasConstraintName("FK_Tarea_Obra");
            #endregion

            //Persona

            #region Persona

            modelBuilder.Entity<Persona>().HasMany(x => x.SalidaMateriales)
                .WithOne(x => x.Responsable)
                .HasForeignKey(x => x.ResponsableId)
                .HasConstraintName("FK_SalidaMaterial_Responsable");

            modelBuilder.Entity<Persona>().HasMany(x => x.Obras)
                .WithOne(x => x.Encargado)
                .HasForeignKey(x => x.EncargadoId)
                .HasConstraintName("FK_Obra_Encargado"); 

            modelBuilder.Entity<Persona>().HasMany(x => x.Usuarios)
                .WithOne(x => x.Persona)
                .HasForeignKey(x => x.PersonaId)
                .HasConstraintName("FK_Usuario_Persona");

            #endregion

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

            #endregion

            //Rubro

            #region Rubro

            modelBuilder.Entity<Rubro>().HasMany(x => x.Comprobantes)
                .WithOne(x => x.Rubro)
                .HasForeignKey(x => x.RubroId)
                .HasConstraintName("FK_Comprobante_Rubro");


            #endregion

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

            modelBuilder.Entity<Usuario>().HasOne(x => x.Persona)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.PersonaId)
                .HasConstraintName("FK_Usuario_Persona");

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

            modelBuilder.Entity<Usuario>().HasMany(x => x.Comprobantes)
                .WithOne(x => x.Usuario)
                .HasForeignKey(x => x.UsuarioId)
                .HasConstraintName("FK_Comprobante_Usuario");

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

            modelBuilder.ApplyConfiguration<Banco>(new BancoMetadata());
            modelBuilder.ApplyConfiguration<Caja>(new CajaMetadata());
            modelBuilder.ApplyConfiguration<ComprobanteEntrada>(new ComprobanteEntradaMetadata());
            modelBuilder.ApplyConfiguration<ComprobanteSalida>(new ComprobanteSalidaMetadata());
            modelBuilder.ApplyConfiguration<Comprobante>(new ComprobanteMetadata());
            modelBuilder.ApplyConfiguration<CondicionIva>(new CondicionIvaMetadata());
            modelBuilder.ApplyConfiguration<CuentaCorriente>(new CuentaCorrienteMetadata());
            modelBuilder.ApplyConfiguration<DescripcionTarea>(new DescripcionTareaMetadata());
            modelBuilder.ApplyConfiguration<DetalleCaja>(new DetalleCajaMetadata());
            modelBuilder.ApplyConfiguration<DetalleComprobante>(new DetalleComprobanteMetadata());
            modelBuilder.ApplyConfiguration<Empresa>(new EmpresaMetadata());
            modelBuilder.ApplyConfiguration<FormaPago>(new FormaPagoMetadata());
            modelBuilder.ApplyConfiguration<Gasto>(new GastoMetadata());
            modelBuilder.ApplyConfiguration<IngresoMaterial>(new IngresoMaterialMetadata());
            modelBuilder.ApplyConfiguration<Material>(new MaterialMetadata());
            modelBuilder.ApplyConfiguration<Movimiento>(new MovimientoMetadata());
            modelBuilder.ApplyConfiguration<Obra>(new ObraMetadata());
            modelBuilder.ApplyConfiguration<Persona>(new PersonaMetadata());
            modelBuilder.ApplyConfiguration<Precio>(new PrecioMetadata());
            modelBuilder.ApplyConfiguration<Presupuesto>(new PresupuestoMetadata());
            modelBuilder.ApplyConfiguration<Rubro>(new RubroMetadata());
            modelBuilder.ApplyConfiguration<SalidaMaterial>(new SalidaMaterialMetadata());
            modelBuilder.ApplyConfiguration<Stock>(new StockMetadata());
            modelBuilder.ApplyConfiguration<Tarea>(new TareaMetadata());
            modelBuilder.ApplyConfiguration<TipoGasto>(new TipoGastoMetadata());
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioMetadata());
            modelBuilder.ApplyConfiguration<Zona>(new ZonaMetadata());

            #endregion

            base.OnModelCreating(modelBuilder);
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

        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Caja> Cajas { get; set; }
        public DbSet<Comprobante> Comprobantes { get; set; }
        public DbSet<ComprobanteEntrada> ComprobanteEntradas { get; set; }
        public DbSet<ComprobanteSalida> ComprobanteSalidas { get; set; }
        public DbSet<CondicionIva> CondicionIvas { get; set; }
        public DbSet<CuentaCorriente> CuentaCorrientes { get; set; }
        public DbSet<DescripcionTarea> DescripcionTareas { get; set; }
        public DbSet<DetalleCaja> DetalleCajas { get; set; }
        public DbSet<DetalleComprobante> DetalleComprobantes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<FormaPago> FormaPagos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<IngresoMaterial> IngresoMateriales { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Precio> Precios { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<SalidaMaterial> SalidaMateriales { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<TipoGasto> TipoGastos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Zona> Zonas { get; set; }

        #endregion

    }
}
