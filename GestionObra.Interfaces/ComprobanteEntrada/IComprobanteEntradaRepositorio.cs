using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.ComprobanteEntrada.DTOs;

namespace GestionObra.Interfaces.ComprobanteEntrada
{
    public interface IComprobanteEntradaRepositorio
    {
        Task Insertar(ComprobanteEntradaDto dto);
        Task<IEnumerable<ComprobanteEntradaDto>> Obtener(string cadena);
        Task<ComprobanteEntradaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(ComprobanteEntradaDto dto);
    }
}
