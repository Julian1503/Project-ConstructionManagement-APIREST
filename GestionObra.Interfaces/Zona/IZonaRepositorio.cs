using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Zona.DTOs;

namespace GestionObra.Interfaces.Zona
{
    public interface IZonaRepositorio
    {
        Task Insertar(ZonaDto dto);
        Task<IEnumerable<ZonaDto>> Obtener(string cadena);
        Task<ZonaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(ZonaDto dto);
    }
}
