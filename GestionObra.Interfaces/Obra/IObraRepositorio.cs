using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Obra.DTOs;

namespace GestionObra.Interfaces.Obra
{
    public interface IObraRepositorio
    {
        Task Insertar(ObraDto dto);
        Task<IEnumerable<ObraDto>> ObtenerPorFiltro(string cadena);
        Task<IEnumerable<ObraDto>> ObtenerTodos();
        Task<ObraDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task<int[]> ObtenerEnMarcha();
        Task<IEnumerable<ObraDto>> ObtenePendientes();
        Task<IEnumerable<ObraDto>> ObtenerEnProceso();
        Task Modificar(ObraDto dto);
        Task<IEnumerable<ObraDto>> ObtenerPlanificando();
    }
}
