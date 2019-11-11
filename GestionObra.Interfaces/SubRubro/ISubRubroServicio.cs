using GestionObra.Interfaces.SubRubro.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.SubRubro
{
   public interface ISubRubroServicio
    {
        Task Insertar(SubRubroDto dto);
        Task<IEnumerable<SubRubroDto>> ObtenerPorFiltro(string cadena);
        Task<IEnumerable<SubRubroDto>> ObtenerTodos();
        Task<SubRubroDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(SubRubroDto dto);
        Task<IEnumerable<SubRubroDto>> ObtenerPorRubroId(long id);
        Task<IEnumerable<SubRubroDto>> ObtenerEntradas();
        Task<IEnumerable<SubRubroDto>> ObtenerSalidas();
    }
}
