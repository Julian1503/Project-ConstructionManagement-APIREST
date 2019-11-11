using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Constantes;
using GestionObra.Interfaces.Presupuesto.DTOs;

namespace GestionObra.Interfaces.Presupuesto
{
    public interface IPresupuestoRepositorio
    {
        Task Insertar(PresupuestoDto dto);
        Task CambioEstado(EstadoPresupuesto estado,long id);
        Task<IEnumerable<PresupuestoDto>> ObtenerTodos();
        Task<IEnumerable<PresupuestoDto>> ObtenerPorFiltro(string cadena);
        Task<PresupuestoDto> ObtenerPorId(long id);
        Task<int> ObtenerSinCobrar();
        Task<IEnumerable<PresupuestoDto>> ObtenerFacturados();
        Task<IEnumerable<PresupuestoDto>> ObtenerFinalizados();
        Task Borrar(long id);
        Task<IEnumerable<PresupuestoDto>> ObtenerPorFecha(DateTime Desde, DateTime Hasta);
        Task Modificar(PresupuestoDto dto);
        Task<IEnumerable<PresupuestoDto>> ObtenerPorCliente(DateTime desde, DateTime hasta, long clienteId);
        Task<IEnumerable<PresupuestoDto>> ObtenerFacturadosFecha(DateTime desde, DateTime hasta);
    }
}
