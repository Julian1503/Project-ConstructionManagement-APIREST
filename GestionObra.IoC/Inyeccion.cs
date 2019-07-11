using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Infraestructura;
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

            //servicios.AddTransient<IBancoRepositorio,>()
            //servicios.AddTransient<ICajaRepositorio,>()
            //servicios.AddTransient<IComprobanteEntradaRepositorio,>()
            //servicios.AddTransient<IComprobanteSalidaRepositorio,>()
            //servicios.AddTransient<ICondicionIvaRepositorio,>()
            //servicios.AddTransient<ICuentaCorrienteRepositorio,>()
            //servicios.AddTransient<IDescripcionTareaRepositorio,>()
            //servicios.AddTransient<IDetalleCajaRepositorio,>()
            //servicios.AddTransient<IDetalleComprobanteRepositorio,>()
            //servicios.AddTransient<IEmpresaRepositorio,>()
            //servicios.AddTransient<IFormaPagoRepositorio,>()
            //servicios.AddTransient<IGastoRepositorio,>()
            //servicios.AddTransient<IIngresoMaterialRepositorio,>()
            //servicios.AddTransient<IMaterialRepositorio,>()
            //servicios.AddTransient<IMovimientoRepositorio,>()
            //servicios.AddTransient<IObraRepositorio,>()
            //servicios.AddTransient<IPersonaRepositorio,>()
            //servicios.AddTransient<IPrecioRepositorio,>()
            //servicios.AddTransient<IRubroRepositorio,>()
            //servicios.AddTransient<ISalidaMaterialRepositorio,>()
            //servicios.AddTransient<IStockRepositorio,>()
            //servicios.AddTransient<ITareaRepositorio,>()
            //servicios.AddTransient<ITipoGastoRepositorio,>()
            //servicios.AddTransient<IUsuarioRepositorio,>()
            //servicios.AddTransient<IZonaRepositorio,>()
        }
    }
}
