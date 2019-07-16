using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.TipoGasto.DTOs;

namespace GestionObra.Interfaces.TipoGasto
{
    public interface ITipoGastoRepositorio
    {
        Task Insertar(TipoGastoDto dto);
        Task<IEnumerable<TipoGastoDto>> ObtenerTodos();
        Task<IEnumerable<TipoGastoDto>> ObtenerPorFiltro(string cadena);
        Task<TipoGastoDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(TipoGastoDto dto);
    }
}
