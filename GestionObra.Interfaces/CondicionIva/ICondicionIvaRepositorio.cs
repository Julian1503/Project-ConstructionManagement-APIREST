using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.CondicionIva.DTOs;

namespace GestionObra.Interfaces.CondicionIva
{
   public interface ICondicionIvaRepositorio
    {
        Task Insertar(CondicionIvaDto dto);
        Task<IEnumerable<CondicionIvaDto>> Obtener(string cadena);
        Task<CondicionIvaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(CondicionIvaDto dto);
    }
}
