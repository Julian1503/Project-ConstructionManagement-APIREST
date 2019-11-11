using GestionObra.Interfaces.ChequeEntrada.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.ChequeEntrada
{
    public interface IChequeEntradaServicio
    {
        Task Insertar(ChequeEntradaDto dto);
        Task<IEnumerable<ChequeEntradaDto>> ObtenerPorFiltro(string cadena);
        Task<ChequeEntradaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task<IEnumerable<ChequeEntradaDto>> ObtenerPorDePara(DateTime desde, DateTime hasta, string dePara);
        Task<IEnumerable<ChequeEntradaDto>> ObtenerPorConcepto(DateTime desde, DateTime hasta, string concepto);
        Task Modificar(ChequeEntradaDto dto);
        Task<IEnumerable<ChequeEntradaDto>> ObtenerPorDesde(DateTime desde, DateTime hasta);
        Task<IEnumerable<ChequeEntradaDto>> ObtenerTodos();
    }
}
