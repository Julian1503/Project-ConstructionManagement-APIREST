using GestionObra.Interfaces.Contratista.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.Contratista
{
    public interface IContratistaServicio
    {
        Task Insertar(ContratistaDto dto);
        Task<IEnumerable<ContratistaDto>> ObtenerPorFiltro(string cadena);
        Task<ContratistaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(ContratistaDto dto);
        Task<IEnumerable<ContratistaDto>> ObtenerTodos();
    }
}
