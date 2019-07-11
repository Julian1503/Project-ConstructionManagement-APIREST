using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.IngresoMaterial.DTOs;

namespace GestionObra.Interfaces.IngresoMaterial
{
    public interface IIngresoMaterialRepositorio
    {
        Task Insertar(IngresoMaterialDto dto);
        Task<IEnumerable<IngresoMaterialDto>> ObtenerTodos();
        Task<IngresoMaterialDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(IngresoMaterialDto dto);
    }
}
