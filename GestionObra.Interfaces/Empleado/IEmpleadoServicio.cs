using GestionObra.Interfaces.Empleado.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.Empleado
{
    public interface IEmpleadoServicio
    {
        Task Insertar(EmpleadoDto dto);
        Task<IEnumerable<EmpleadoDto>> ObtenerConFiltro(string cadena);
        Task<IEnumerable<EmpleadoDto>> ObtenerTodos();
        Task<EmpleadoDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(EmpleadoDto dto);
    }
}
