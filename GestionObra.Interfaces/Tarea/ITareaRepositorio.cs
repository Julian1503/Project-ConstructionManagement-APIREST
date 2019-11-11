using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Tarea.DTOs;

namespace GestionObra.Interfaces.Tarea
{
    public interface ITareaRepositorio
    {
        Task Insertar(TareaDto dto);
        Task<IEnumerable<TareaDto>> ObtenerPorFiltro(string cadena);
        Task<IEnumerable<TareaDto>> ObtenerTodos();
        Task<TareaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(TareaDto dto);
        Task<IEnumerable<TareaDto>> ObtenerPorObra(int id);
    }
}
