using GestionObra.Interfaces.ChequeSalida.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.ChequeSalida
{
    public interface IChequeSalidaServicio
    {
        Task Insertar(ChequeSalidaDto dto);
        Task<IEnumerable<ChequeSalidaDto>> ObtenerPorFiltro(string cadena);
        Task<ChequeSalidaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task<IEnumerable<ChequeSalidaDto>> ObtenerPorConcepto(DateTime desde, DateTime hasta, string concepto);
        Task<IEnumerable<ChequeSalidaDto>> ObtenerPorDePara(DateTime desde, DateTime hasta, string dePara);
        Task<IEnumerable<ChequeSalidaDto>> ObtenerPorTodo(DateTime desde, DateTime hasta, string paguese, string concepto, string numero);
        Task<IEnumerable<ChequeSalidaDto>> ObtenerPorDesde(DateTime desde, DateTime hasta);
        Task Modificar(ChequeSalidaDto dto);
        Task<IEnumerable<ChequeSalidaDto>> ObtenerTodos();
    }
}
