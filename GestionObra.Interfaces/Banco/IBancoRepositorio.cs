﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Banco.DTOs;

namespace GestionObra.Interfaces.Banco
{
    public interface IBancoRepositorio
    {
        Task<long> Insertar(BancoDto dto);
        Task<IEnumerable<BancoDto>> ObtenerConFiltro(string cadena);
        Task<IEnumerable<BancoDto>> ObtenerTodos();
        Task<BancoDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(BancoDto dto);
    }
}
