using GestionObra.Interfaces.AsistenciaDiaria.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.AsistenciaDiaria
{
   public interface IAsistenciaDiariaServicio
    {
        Task Insertar(AsistenciaDiariaDto dto);
        Task<IEnumerable<AsistenciaDiariaDto>> ObtenerPorFiltro(string cadena);
        Task<AsistenciaDiariaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(AsistenciaDiariaDto dto);
        Task<IEnumerable<AsistenciaDiariaDto>> ObtenerTodos();
        Task<IEnumerable<AsistenciaDiariaDto>> ObtenerPorDesde(DateTime desde, DateTime hasta, long id);
        Task<IEnumerable<AsistenciaDiariaDto>> ObtenerPorJornal(long id);
    }
}
