﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.DetalleComprobante.DTOs;

namespace GestionObra.Interfaces.DetalleComprobante
{
    public interface IDetalleComprobanteRepositorio
    {
        Task Insertar(DetalleComprobanteDto dto);
        Task<IEnumerable<DetalleComprobanteDto>> ObtenerTodos();
        Task<DetalleComprobanteDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(DetalleComprobanteDto dto);
    }
}