using GestionObra.Interfaces.Proveedor.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.Proveedor
{
    public interface IProveedorServicio
    {
        Task Insertar(ProveedorDto dto);
        Task<IEnumerable<ProveedorDto>> Obtener(string cadena);
        Task<ProveedorDto> ObtenerPorId(long id);
        Task<IEnumerable<ProveedorDto>> ObtenerTodos();
        Task Borrar(long id);
        Task Modificar(ProveedorDto dto);
    }
}
