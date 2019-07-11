using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Entidades;
using GestionObra.Interfaces.Banco.DTOs;
using GestionObra.Interfaces.Caja.DTOs;
using GestionObra.Interfaces.Comprobante.DTOs;
using GestionObra.Interfaces.ComprobanteEntrada.DTOs;
using GestionObra.Interfaces.ComprobanteSalida.DTOs;
using GestionObra.Interfaces.CondicionIva.DTOs;
using GestionObra.Interfaces.CuentaCorriente.DTOs;
using GestionObra.Interfaces.DescripcionTarea.DTOs;
using GestionObra.Interfaces.DetalleCaja.DTOs;
using GestionObra.Interfaces.DetalleComprobante.DTOs;
using GestionObra.Interfaces.Empresa.DTOs;
using GestionObra.Interfaces.FormaPago.DTOs;
using GestionObra.Interfaces.Gasto.DTOs;
using GestionObra.Interfaces.IngresoMaterial.DTOs;
using GestionObra.Interfaces.Material.DTOs;
using GestionObra.Interfaces.Movimiento.DTOs;
using GestionObra.Interfaces.Obra.DTOs;
using GestionObra.Interfaces.Persona.DTOs;
using GestionObra.Interfaces.Precio.DTOs;
using GestionObra.Interfaces.Presupuesto.DTOs;
using GestionObra.Interfaces.Rubro.DTOs;
using GestionObra.Interfaces.SalidaMaterial.DTOs;
using GestionObra.Interfaces.Stock.DTOs;
using GestionObra.Interfaces.Tarea.DTOs;
using GestionObra.Interfaces.TipoGasto.DTOs;
using GestionObra.Interfaces.Usuario.DTOs;
using GestionObra.Interfaces.Zona.DTOs;

namespace MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BancoDto, Banco>().ReverseMap();
            CreateMap<CajaDto, Caja>().ReverseMap();
            CreateMap<ComprobanteDto, Comprobante>().ReverseMap();
            CreateMap<ComprobanteEntradaDto, ComprobanteEntrada>().ReverseMap();
            CreateMap<ComprobanteSalidaDto, ComprobanteSalida>().ReverseMap();
            CreateMap<CondicionIvaDto, CondicionIva>().ReverseMap();
            CreateMap<CuentaCorrienteDto, CuentaCorriente>().ReverseMap();
            CreateMap<DescripcionTareaDto, DescripcionTarea>().ReverseMap();
            CreateMap<DetalleCajaDto, DetalleCaja>().ReverseMap();
            CreateMap<DetalleComprobanteDto, DetalleComprobante>().ReverseMap();
            CreateMap<EmpresaDto, Empresa>().ReverseMap();
            CreateMap<FormaPagoDto, FormaPago>().ReverseMap();
            CreateMap<GastoDto, Gasto>().ReverseMap();
            CreateMap<IngresoMaterialDto, IngresoMaterial>().ReverseMap();
            CreateMap<MaterialDto, Material>().ReverseMap();
            CreateMap<MovimientoDto, Movimiento>().ReverseMap();
            CreateMap<ObraDto, Obra>().ReverseMap();
            CreateMap<PersonaDto, Persona>().ReverseMap();
            CreateMap<PrecioDto, Precio>().ReverseMap();
            CreateMap<PresupuestoDto, Presupuesto>().ReverseMap();
            CreateMap<RubroDto, Rubro>().ReverseMap();
            CreateMap<SalidaMaterialDto, SalidaMaterial>().ReverseMap();
            CreateMap<StockDto, Stock>().ReverseMap();
            CreateMap<TareaDto, Tarea>().ReverseMap();
            CreateMap<TipoGastoDto, TipoGasto>().ReverseMap();
            CreateMap<UsuarioDto, Usuario>().ReverseMap();
            CreateMap<ZonaDto, Zona>().ReverseMap();
        }
    }
}
