using GestionObra.Interfaces.Transferencia.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.Transferencia
{
    public interface ITransferenciaServicio
    {
        Task<long> Insertar(TransferenciaDto dto);
        Task<IEnumerable<TransferenciaDto>> Obtener(string cadena);
        Task<TransferenciaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(TransferenciaDto dto);
        Task<IEnumerable<TransferenciaDto>> ObtenerPorConcepto(DateTime desde, DateTime hasta, string concepto);
        Task<IEnumerable<TransferenciaDto>> ObtenerPorPaguese(DateTime desde, DateTime hasta, string pagueseA);
        Task<IEnumerable<TransferenciaDto>> ObtenerPorDesde(DateTime desde, DateTime hasta);
        Task<IEnumerable<TransferenciaDto>> ObtenerTodos();
        Task<long> ObtenerSiguienteId();
    }
}
