using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Obra.DTOs;

namespace GestionObra.Interfaces.Obra
{
    public interface IObraRepositorio
    {
        Task Insertar(ObraDto dto);
        Task<IEnumerable<ObraDto>> Obtener(string cadena);
        Task<ObraDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(ObraDto dto);
    }
}
