using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Dominio;
using GestionObra.Dominio.Entidades;
using GestionObra.Implementacion.Banco;
using GestionObra.Implementacion.Caja;
using GestionObra.Implementacion.ComprobanteEntrada;
using GestionObra.Implementacion.ComprobanteSalida;
using GestionObra.Implementacion.CondicionIva;
using GestionObra.Implementacion.CuentaCorriente;
using GestionObra.Implementacion.DescripcionTarea;
using GestionObra.Implementacion.DetalleCaja;
using GestionObra.Implementacion.DetalleComprobante;
using GestionObra.Implementacion.Empresa;
using GestionObra.Implementacion.FormaPago;
using GestionObra.Implementacion.Gasto;
using GestionObra.Implementacion.IngresoMaterial;
using GestionObra.Implementacion.Material;
using GestionObra.Implementacion.Movimiento;
using GestionObra.Implementacion.Obra;
using GestionObra.Implementacion.Persona;
using GestionObra.Implementacion.Precio;
using GestionObra.Implementacion.Rubro;
using GestionObra.Implementacion.SalidaMaterial;
using GestionObra.Implementacion.Stock;
using GestionObra.Implementacion.Tarea;
using GestionObra.Implementacion.TipoGasto;
using GestionObra.Implementacion.Usuario;
using GestionObra.Implementacion.Zona;
using GestionObra.Infraestructura;
using GestionObra.Infraestructura.Repositorio;
using GestionObra.Interfaces.Banco;
using GestionObra.Interfaces.Caja;
using GestionObra.Interfaces.ComprobanteEntrada;
using GestionObra.Interfaces.ComprobanteSalida;
using GestionObra.Interfaces.CondicionIva;
using GestionObra.Interfaces.CuentaCorriente;
using GestionObra.Interfaces.DescripcionTarea;
using GestionObra.Interfaces.DetalleCaja;
using GestionObra.Interfaces.DetalleComprobante;
using GestionObra.Interfaces.Empresa;
using GestionObra.Interfaces.FormaPago;
using GestionObra.Interfaces.Gasto;
using GestionObra.Interfaces.IngresoMaterial;
using GestionObra.Interfaces.Material;
using GestionObra.Interfaces.Movimiento;
using GestionObra.Interfaces.Obra;
using GestionObra.Interfaces.Persona;
using GestionObra.Interfaces.Precio;
using GestionObra.Interfaces.Rubro;
using GestionObra.Interfaces.SalidaMaterial;
using GestionObra.Interfaces.Stock;
using GestionObra.Interfaces.Tarea;
using GestionObra.Interfaces.TipoGasto;
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

            servicios.AddTransient<IBancoRepositorio, BancoServicio>();
            servicios.AddTransient<IRepositorio<Banco>, Repositorio<Banco>>();

            servicios.AddTransient<ICajaRepositorio, CajaServicio>();
            servicios.AddTransient<IRepositorio<Caja>, Repositorio<Caja>>();

            servicios.AddTransient<IComprobanteEntradaRepositorio, ComprobanteEntradaServicio>();
            servicios.AddTransient<IRepositorio<ComprobanteEntrada>, Repositorio<ComprobanteEntrada>>();

            servicios.AddTransient<IComprobanteSalidaRepositorio, ComprobanteSalidaServicio>();
            servicios.AddTransient<IRepositorio<ComprobanteSalida>, Repositorio<ComprobanteSalida>>();

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

            servicios.AddTransient<IFormaPagoRepositorio, FormaPagoServicio>();
            servicios.AddTransient<IRepositorio<FormaPago>, Repositorio<FormaPago>>();

            servicios.AddTransient<IGastoRepositorio, GastoServicio>();
            servicios.AddTransient<IRepositorio<Gasto>, Repositorio<Gasto>>();

            servicios.AddTransient<IIngresoMaterialRepositorio, IngresoMaterialServicio>();
            servicios.AddTransient<IRepositorio<IngresoMaterial>, Repositorio<IngresoMaterial>>();

            servicios.AddTransient<IMaterialRepositorio, MaterialServicio>();
            servicios.AddTransient<IRepositorio<Material>, Repositorio<Material>>();

            servicios.AddTransient<IMovimientoRepositorio, MovimientoServicio>();
            servicios.AddTransient<IRepositorio<Movimiento>, Repositorio<Movimiento>>();

            servicios.AddTransient<IObraRepositorio, ObraServicio>();
            servicios.AddTransient<IRepositorio<Obra>, Repositorio<Obra>>();

            servicios.AddTransient<IPersonaRepositorio, PersonaServicio>();
            servicios.AddTransient<IRepositorio<Persona>, Repositorio<Persona>>();

            servicios.AddTransient<IPrecioRepositorio, PrecioServicio>();
            servicios.AddTransient<IRepositorio<Precio>, Repositorio<Precio>>();

            servicios.AddTransient<IRubroRepositorio, RubroServicio>();
            servicios.AddTransient<IRepositorio<Rubro>, Repositorio<Rubro>>();

            servicios.AddTransient<ISalidaMaterialRepositorio, SalidaMaterialServicio>();
            servicios.AddTransient<IRepositorio<SalidaMaterial>, Repositorio<SalidaMaterial>>();

            servicios.AddTransient<IStockRepositorio, StockServicio>();
            servicios.AddTransient<IRepositorio<Stock>, Repositorio<Stock>>();

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
