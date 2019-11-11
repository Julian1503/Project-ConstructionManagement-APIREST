using GestionObra.Interfaces.Empleado.DTOs;
using GestionObra.Interfaces.Jornal.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.Jornal
{
    public interface IObraEmpleadoServicio
    {
        Task Insertar(ObraEmpleadoDto dto);
        Task<IEnumerable<ObraEmpleadoDto>> ObtenerPorFiltro(string cadena);
        Task<ObraEmpleadoDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(ObraEmpleadoDto dto);
        Task<IEnumerable<ObraEmpleadoDto>> ObtenerTodos();
        Task<IEnumerable<EmpleadoDto>> ObtenerPorObra(long id);
        Task<ObraEmpleadoDto> ObtenerPorObraEmpleado(long obraId, long empleadoId);
    }
}
