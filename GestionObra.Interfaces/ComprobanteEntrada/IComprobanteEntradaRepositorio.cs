using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.ComprobanteEntrada.DTOs;

namespace GestionObra.Interfaces.ComprobanteEntrada
{
    public interface IComprobanteEntradaRepositorio
    {
        Task<long> Insertar(ComprobanteEntradaDto dto);
        Task<IEnumerable<ComprobanteEntradaDto>> Obtener(string cadena);
        Task<ComprobanteEntradaDto> ObtenerPorId(long id);
        Task<decimal[]> ObtenerPorcentajes();
        Task Borrar(long id);
        Task<IEnumerable<ComprobanteEntradaDto>> ObtenerPorDesde(DateTime desde, DateTime hasta);
        Task<IEnumerable<ComprobanteEntradaDto>> ObtenerPorRubro(DateTime desde, DateTime hasta,long rubroId);
        Task<IEnumerable<ComprobanteEntradaDto>> ObtenerPorSubRubro(DateTime desde, DateTime hasta, long subRubroId);
        Task Modificar(ComprobanteEntradaDto dto);
        Task<IEnumerable<ComprobanteEntradaDto>> ObtenerTodos();
        Task<long> ObtenerSiguienteId();
    }
}
