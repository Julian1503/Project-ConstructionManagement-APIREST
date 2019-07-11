using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Movimiento.DTOs;

namespace GestionObra.Interfaces.Movimiento
{
    public interface IMovimientoRepositorio
    {
        Task Insertar(MovimientoDto dto);
        Task<IEnumerable<MovimientoDto>> ObtenerTodos();
        Task<MovimientoDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(MovimientoDto dto);
    }
}
