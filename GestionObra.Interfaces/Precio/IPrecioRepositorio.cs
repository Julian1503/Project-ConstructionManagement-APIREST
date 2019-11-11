using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Precio.DTOs;

namespace GestionObra.Interfaces.Precio
{
    public interface IPrecioRepositorio
    {
        Task Insertar(PrecioDto dto);
        Task<IEnumerable<PrecioDto>> ObtenerTodos();
        Task<IEnumerable<PrecioDto>> ObtenerPoFiltro(string cadena);
        Task<PrecioDto> ObtenerUltimo(int materialId);
        Task<PrecioDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(PrecioDto dto);
    }
}
