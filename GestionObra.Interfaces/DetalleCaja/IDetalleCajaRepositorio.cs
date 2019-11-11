using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.DetalleCaja.DTOs;

namespace GestionObra.Interfaces.DetalleCaja
{
    public interface IDetalleCajaRepositorio
    {
        Task Insertar(DetalleCajaDto dto);
        Task<IEnumerable<DetalleCajaDto>> ObtenerTodos( );
        Task<DetalleCajaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task<IEnumerable<DetalleCajaDto>> ObtenerPorPaguese(DateTime desde, DateTime hasta);
        Task<IEnumerable<DetalleCajaDto>> ObtenerPorCaja(long id);
        Task Modificar(DetalleCajaDto dto);
        Task<IEnumerable<DetalleCajaDto>> ObtenerConFiltro(string cadena);
    }
}
