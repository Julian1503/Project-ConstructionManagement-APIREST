using GestionObra.Interfaces.Deposito.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.Deposito
{
   public  interface IDepositoServicio
    {
        Task<long> Insertar(DepositoDto dto);
        Task<IEnumerable<DepositoDto>> Obtener(string cadena);
        Task<DepositoDto> ObtenerPorId(long id);
        Task<IEnumerable<DepositoDto>> ObtenerPorConcepto(DateTime desde, DateTime hasta, string concepto);
        Task<IEnumerable<DepositoDto>> ObtenerPorDePara(DateTime desde, DateTime hasta, string dePara);
        Task Borrar(long id);
        Task Modificar(DepositoDto dto);
        Task<IEnumerable<DepositoDto>> ObtenerPorDesde(DateTime desde, DateTime hasta);
        Task<IEnumerable<DepositoDto>> ObtenerTodos();
        Task<long> ObtenerSiguienteId();
    }
}
