using GestionObra.Interfaces.AsistenciaContratista.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.AsistenciaContratista
{
    public interface IAsistenciaContratistaServicio
    {
        Task Insertar(AsistenciaContratistaDto dto);
        Task<IEnumerable<AsistenciaContratistaDto>> ObtenerPorFiltro(string cadena);
        Task<AsistenciaContratistaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(AsistenciaContratistaDto dto);
        Task<IEnumerable<AsistenciaContratistaDto>> ObtenerTodos();
        Task<IEnumerable<AsistenciaContratistaDto>> ObtenerPorJornal(long id);
        Task<IEnumerable<AsistenciaContratistaDto>> ObtenerPorDesde(DateTime desde,DateTime hasta,long id);
    }
}
