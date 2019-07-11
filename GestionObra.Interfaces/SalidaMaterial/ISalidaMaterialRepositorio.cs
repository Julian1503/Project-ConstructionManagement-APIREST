using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.SalidaMaterial.DTOs;

namespace GestionObra.Interfaces.SalidaMaterial
{
    public interface ISalidaMaterialRepositorio
    {
        Task Insertar(SalidaMaterialDto dto);
        Task<IEnumerable<SalidaMaterialDto>> ObtenerTodos();
        Task<SalidaMaterialDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(SalidaMaterialDto dto);
    }
}
