using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Material.DTOs;

namespace GestionObra.Interfaces.Material
{
    public interface IMaterialRepositorio
    {
        Task Insertar(MaterialDto dto);
        Task<IEnumerable<MaterialDto>> Obtener(string cadena);
        Task<MaterialDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(MaterialDto dto);
    }
}
