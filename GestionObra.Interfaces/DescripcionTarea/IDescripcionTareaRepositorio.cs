using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.DescripcionTarea.DTOs;

namespace GestionObra.Interfaces.DescripcionTarea
{
    public interface IDescripcionTareaRepositorio
    {
        Task Insertar(DescripcionTareaDto dto);
        Task<IEnumerable<DescripcionTareaDto>> ObtenerPorFiltro(string cadena);
        Task<DescripcionTareaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(DescripcionTareaDto dto);
        Task<IEnumerable<DescripcionTareaDto>> ObtenerTodos();
    }
}
