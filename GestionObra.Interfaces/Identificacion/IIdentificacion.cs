using GestionObra.Interfaces.Identificacion.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.Identificacion
{
    public interface IIdentificacion
    {
        Task<long> Insertar(IdentificacionDto dto);
        Task<IdentificacionDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(IdentificacionDto dto);
        Task<IEnumerable<IdentificacionDto>> ObtenerTodos();
    }
}
