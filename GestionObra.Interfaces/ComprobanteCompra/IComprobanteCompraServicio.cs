using GestionObra.Interfaces.ComprobanteCompra.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.ComprobanteCompra
{
    public interface IComprobanteCompraServicio
    {
        Task Insertar(ComprobanteCompraDto dto);
        Task<IEnumerable<ComprobanteCompraDto>> ObtenerPorFiltro(string cadena);
        Task<IEnumerable<ComprobanteCompraDto>> ObtenerTodos();
        Task<IEnumerable<ComprobanteCompraDto>> ObtenerPorObraFecha(DateTime desde, DateTime hasta, long id);
        Task<ComprobanteCompraDto> ObtenerPorId(long id);
        Task<decimal> ObtenerOficina();
        Task<IEnumerable<ComprobanteCompraDto>> ObtenerPorObra(long id);
        Task Borrar(long id);
        Task<IEnumerable<ComprobanteCompraDto>> ObtenerPorProveedor(DateTime desde, DateTime hasta, long id);
        Task<IEnumerable<ComprobanteCompraDto>> ObtenerPorCuit(DateTime desde, DateTime hasta, string cuit);
        Task<IEnumerable<ComprobanteCompraDto>> ObtenerPorDesde(DateTime desde, DateTime hasta);
        Task<long> ObtenerSiguienteId();
        Task<int> ObtenerUltimo();
        Task Modificar(ComprobanteCompraDto dto);
    }
}
