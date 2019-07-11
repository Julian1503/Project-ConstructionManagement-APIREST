using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Comprobante.DTOs;

namespace GestionObra.Interfaces.Comprobante
{
    public interface IComprobanteServicio
    {
        Task Insertar(ComprobanteDto dto);
        Task<IEnumerable<ComprobanteDto>> Obtener(string cadena);
        Task<ComprobanteDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(ComprobanteDto dto);
    }
}
