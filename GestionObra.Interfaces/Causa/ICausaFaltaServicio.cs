using GestionObra.Interfaces.Causa.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.Causa
{
    public interface ICausaFaltaServicio
    {
        Task Insertar(CausaFaltaDto dto);
        Task<IEnumerable<CausaFaltaDto>> ObtenerPorFiltro(string cadena);
        Task<CausaFaltaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(CausaFaltaDto dto);
        Task<IEnumerable<CausaFaltaDto>> ObtenerTodos();
    }
}
