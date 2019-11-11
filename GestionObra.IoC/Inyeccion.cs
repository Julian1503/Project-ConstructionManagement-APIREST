using GestionJornal.Implementacion.Jornal;
using GestionObra.Dominio;
using GestionObra.Dominio.Entidades;
using GestionObra.Dominio.Repositorio;
using GestionObra.Implementacion.AsistenciaContratista;
using GestionObra.Implementacion.AsistenciaDiaria;
using GestionObra.Implementacion.Banco;
using GestionObra.Implementacion.Caja;
using GestionObra.Implementacion.Categoria;
using GestionObra.Implementacion.CausaFalta;
using GestionObra.Implementacion.ChequeEntrada;
using GestionObra.Implementacion.ChequeSalida;
using GestionObra.Implementacion.ComprobanteCompra;
using GestionObra.Implementacion.ComprobanteEntrada;
using GestionObra.Implementacion.ComprobanteSalida;
using GestionObra.Implementacion.CondicionIva;
using GestionObra.Implementacion.Contratista;
using GestionObra.Implementacion.CuentaCorriente;
using GestionObra.Implementacion.Deposito;
using GestionObra.Implementacion.DescripcionTarea;
using GestionObra.Implementacion.DetalleCaja;
using GestionObra.Implementacion.DetalleComprobante;
using GestionObra.Implementacion.Empleado;
using GestionObra.Implementacion.Empresa;
using GestionObra.Implementacion.FormaPago;
using GestionObra.Implementacion.Gasto;
using GestionObra.Implementacion.Identificacion;
using GestionObra.Implementacion.IngresoMaterial;
using GestionObra.Implementacion.Jornal;
using GestionObra.Implementacion.Jornal.JornalEmpleado;
using GestionObra.Implementacion.JornalMaterial.JornalMaterialMaterial;
using GestionObra.Implementacion.Material;
using GestionObra.Implementacion.Movimiento;
using GestionObra.Implementacion.Obra;
using GestionObra.Implementacion.Operacion;
using GestionObra.Implementacion.Precio;
using GestionObra.Implementacion.Presupuesto;
using GestionObra.Implementacion.Proveedor;
using GestionObra.Implementacion.Rubro;
using GestionObra.Implementacion.SalarioMinimo;
using GestionObra.Implementacion.SalidaMaterial;
using GestionObra.Implementacion.Stock;
using GestionObra.Implementacion.SubRubro;
using GestionObra.Implementacion.Tarea;
using GestionObra.Implementacion.TipoGasto;
using GestionObra.Implementacion.Transferencia;
using GestionObra.Implementacion.Usuario;
using GestionObra.Implementacion.Zona;
using GestionObra.Infraestructura;
using GestionObra.Infraestructura.Repositorio;
using GestionObra.Interfaces.AsistenciaContratista;
using GestionObra.Interfaces.AsistenciaDiaria;
using GestionObra.Interfaces.Banco;
using GestionObra.Interfaces.Caja;
using GestionObra.Interfaces.Categoria;
using GestionObra.Interfaces.Causa;
using GestionObra.Interfaces.ChequeEntrada;
using GestionObra.Interfaces.ChequeSalida;
using GestionObra.Interfaces.ComprobanteCompra;
using GestionObra.Interfaces.ComprobanteEntrada;
using GestionObra.Interfaces.ComprobanteSalida;
using GestionObra.Interfaces.CondicionIva;
using GestionObra.Interfaces.Contratista;
using GestionObra.Interfaces.CuentaCorriente;
using GestionObra.Interfaces.Deposito;
using GestionObra.Interfaces.DescripcionTarea;
using GestionObra.Interfaces.DetalleCaja;
using GestionObra.Interfaces.DetalleComprobante;
using GestionObra.Interfaces.Empleado;
using GestionObra.Interfaces.Empresa;
using GestionObra.Interfaces.FormaPago;
using GestionObra.Interfaces.Gasto;
using GestionObra.Interfaces.Identificacion;
using GestionObra.Interfaces.IngresoMaterial;
using GestionObra.Interfaces.Jornal;
using GestionObra.Interfaces.Material;
using GestionObra.Interfaces.Movimiento;
using GestionObra.Interfaces.Obra;
using GestionObra.Interfaces.Operacion;
using GestionObra.Interfaces.Precio;
using GestionObra.Interfaces.Presupuesto;
using GestionObra.Interfaces.Proveedor;
using GestionObra.Interfaces.Rubro;
using GestionObra.Interfaces.SalarioMinimo;
using GestionObra.Interfaces.SalidaMaterial;
using GestionObra.Interfaces.Stock;
using GestionObra.Interfaces.SubRubro;
using GestionObra.Interfaces.Tarea;
using GestionObra.Interfaces.TipoGasto;
using GestionObra.Interfaces.Transferencia;
using GestionObra.Interfaces.Usuario;
using GestionObra.Interfaces.Zona;
using Microsoft.Extensions.DependencyInjection;

namespace GestionObra.IoC
{
    public class Inyeccion
    {
        public static void ConfigurationService(IServiceCollection servicios )
        {
            servicios.AddDbContext<DataContext>();

            servicios.AddTransient<IAsistenciaContratistaServicio, AsistenciaContratistaServicio>();
            servicios.AddTransient<IRepositorio<AsistenciaContratista>, Repositorio<AsistenciaContratista>>();

            servicios.AddTransient<IAsistenciaDiariaServicio,AsistenciaDiariaServicio>();
            servicios.AddTransient<IRepositorio<AsistenciaDiaria>, Repositorio<AsistenciaDiaria>>();

            servicios.AddTransient<IBancoRepositorio, BancoServicio>();
            servicios.AddTransient<IRepositorio<Banco>, Repositorio<Banco>>();

            servicios.AddTransient<ICajaRepositorio, CajaServicio>();
            servicios.AddTransient<IRepositorio<Caja>, Repositorio<Caja>>();

            servicios.AddTransient<ICategoriaServicio , CategoriaServicio>();
            servicios.AddTransient<IRepositorio<Categoria>, Repositorio<Categoria>>();

            servicios.AddTransient<IContratistaServicio, ContratistaServicio>();
            servicios.AddTransient<IRepositorio<Contratista>, Repositorio<Contratista>>();

            servicios.AddTransient<IChequeSalidaServicio, ChequeSalidaServicio>();
            servicios.AddTransient<IRepositorio<ChequeSalida>, Repositorio<ChequeSalida>>();

            servicios.AddTransient<IChequeEntradaServicio, ChequeEntradaServicio>();
            servicios.AddTransient<IRepositorio<ChequeEntrada>, Repositorio<ChequeEntrada>>();

            servicios.AddTransient<ICausaFaltaServicio, CausaFaltaServicio>();
            servicios.AddTransient<IRepositorio<CausaFalta>, Repositorio<CausaFalta>>();

            servicios.AddTransient<IComprobanteCompraServicio, ComprobanteCompraServicio>();
            servicios.AddTransient<IRepositorio<ComprobanteCompra>, Repositorio<ComprobanteCompra>>();

            servicios.AddTransient<IComprobanteEntradaRepositorio, ComprobanteEntradaServicio>();
            servicios.AddTransient<IRepositorio<ComprobanteEntrada>, Repositorio<ComprobanteEntrada>>();

            servicios.AddTransient<IComprobanteSalidaRepositorio, ComprobanteSalidaServicio>();
            servicios.AddTransient<IRepositorio<ComprobanteSalida>, Repositorio<ComprobanteSalida>>();

            servicios.AddTransient<ITransferenciaServicio, TransferenciaServicio>();
            servicios.AddTransient<IRepositorio<Transferencia>, Repositorio<Transferencia>>();

            servicios.AddTransient<IDepositoServicio, DepositoServicio>();
            servicios.AddTransient<IRepositorio<Deposito>, Repositorio<Deposito>>();

            servicios.AddTransient<ICondicionIvaRepositorio, CondicionIvaServicio>();
            servicios.AddTransient<IRepositorio<CondicionIva>, Repositorio<CondicionIva>>();

            servicios.AddTransient<ICuentaCorrienteRepositorio, CuentaCorrienteServicio>();
            servicios.AddTransient<IRepositorio<CuentaCorriente>, Repositorio<CuentaCorriente>>();

            servicios.AddTransient<IDescripcionTareaRepositorio, DescripcionTareaServicio>();
            servicios.AddTransient<IRepositorio<DescripcionTarea>, Repositorio<DescripcionTarea>>();

            servicios.AddTransient<IDetalleCajaRepositorio, DetalleCajaRepositorio>();
            servicios.AddTransient<IRepositorio<DetalleCaja>, Repositorio<DetalleCaja>>();

            servicios.AddTransient<IDetalleComprobanteRepositorio, DetalleComprobanteServicio>();
            servicios.AddTransient<IRepositorio<DetalleComprobante>, Repositorio<DetalleComprobante>>();

            servicios.AddTransient<IEmpresaRepositorio, EmpresaServicio>();
            servicios.AddTransient<IRepositorio<Empresa>, Repositorio<Empresa>>();

            servicios.AddTransient<IEmpleadoServicio, EmpleadoServicio>();
            servicios.AddTransient<IRepositorio<Empleado>, Repositorio<Empleado>>();

            servicios.AddTransient<IFormaPagoRepositorio, FormaPagoServicio>();
            servicios.AddTransient<IRepositorio<FormaPago>, Repositorio<FormaPago>>();

            servicios.AddTransient<IGastoRepositorio, GastoServicio>();
            servicios.AddTransient<IRepositorio<Gasto>, Repositorio<Gasto>>();

            servicios.AddTransient<IJornalServicio, JornalServicio>();
            servicios.AddTransient<IRepositorio<Jornal>, Repositorio<Jornal>>();

            servicios.AddTransient<IObraEmpleadoServicio, ObraEmpleadoServicio>();
            servicios.AddTransient<IRepositorio<ObraEmpleado>, Repositorio<ObraEmpleado>>();


            servicios.AddTransient<IIdentificacion, IdentificacionServicio>();
            servicios.AddTransient<IRepositorio<Identificacion>, Repositorio<Identificacion>>();

            servicios.AddTransient<IJornalMaterialServicio, JornalMaterialServicio>();
            servicios.AddTransient<IRepositorio<JornalMaterial>, Repositorio<JornalMaterial>>();

            servicios.AddTransient<IIngresoMaterialRepositorio, IngresoMaterialServicio>();
            servicios.AddTransient<IRepositorio<IngresoMaterial>, Repositorio<IngresoMaterial>>();

            servicios.AddTransient<IMaterialRepositorio, MaterialServicio>();
            servicios.AddTransient<IRepositorio<Material>, Repositorio<Material>>();

            servicios.AddTransient<IMovimientoRepositorio, MovimientoServicio>();
            servicios.AddTransient<IRepositorio<Movimiento>, Repositorio<Movimiento>>();

            servicios.AddTransient<IObraRepositorio, ObraServicio>();
            servicios.AddTransient<IRepositorio<Obra>, Repositorio<Obra>>();

            servicios.AddTransient<IOperacionServicio, OperacionServicio>();
            servicios.AddTransient<IRepositorio<Operacion>, Repositorio<Operacion>>();

            servicios.AddTransient<IProveedorServicio, ProveedorServicio>();
            servicios.AddTransient<IRepositorio<Proveedor>, Repositorio<Proveedor>>();

            servicios.AddTransient<IPrecioRepositorio, PrecioServicio>();
            servicios.AddTransient<IRepositorioPrecio, RepositorioPrecio>();

            servicios.AddTransient<IPresupuestoRepositorio, PresupuestoServicio>();
            servicios.AddTransient<IRepositorio<Presupuesto>, Repositorio<Presupuesto>>();

            servicios.AddTransient<IRubroRepositorio, RubroServicio>();
            servicios.AddTransient<IRepositorio<Rubro>, Repositorio<Rubro>>();

            servicios.AddTransient<ISalidaMaterialRepositorio, SalidaMaterialServicio>();
            servicios.AddTransient<IRepositorio<SalidaMaterial>, Repositorio<SalidaMaterial>>();

            servicios.AddTransient<IStockRepositorio, StockServicio>();
            servicios.AddTransient<IRepositorioStock, RepositorioStock>();

            servicios.AddTransient<ISalarioMinimoServicio, SalarioMinimoServicio>();
            servicios.AddTransient<IRepositorio<SalarioMinimo>, Repositorio<SalarioMinimo>>();

            servicios.AddTransient<ISubRubroServicio, SubRubroServicio>();
            servicios.AddTransient<IRepositorio<SubRubro>, Repositorio<SubRubro>>();

            servicios.AddTransient<ITareaRepositorio, TareaServicio>();
            servicios.AddTransient<IRepositorio<Tarea>, Repositorio<Tarea>>();

            servicios.AddTransient<ITipoGastoRepositorio, TipoGastoServicio>();
            servicios.AddTransient<IRepositorio<TipoGasto>, Repositorio<TipoGasto>>();

            servicios.AddTransient<IUsuarioRepositorio, UsuarioServicio>();
            servicios.AddTransient<IRepositorio<Usuario>, Repositorio<Usuario>>();

            servicios.AddTransient<IZonaRepositorio, ZonaServicio>();
            servicios.AddTransient<IRepositorio<Zona>, Repositorio<Zona>>();
        }
    }
}
