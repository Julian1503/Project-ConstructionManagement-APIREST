using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Gasto.DTOs;

namespace GestionObra.Interfaces.Gasto
{
    public interface IGastoRepositorio
    {
        Task Insertar(GastoDto dto);
        Task<IEnumerable<GastoDto>> ObtenerTodos();
        Task<GastoDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(GastoDto dto);
        Task<IEnumerable<GastoDto>> ObtenerConFiltro(string cadena);
        Task<IEnumerable<GastoDto>> ObtenerPorPresupuesto(int id);
    }
}
