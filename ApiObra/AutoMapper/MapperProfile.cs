using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
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

namespace ApiObra.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BancoDto, BancoModel>().ReverseMap();
            CreateMap<CajaDto, CajaModel>().ReverseMap();
            CreateMap<ComprobanteDto, ComprobanteModel>().ReverseMap();
            CreateMap<ComprobanteEntradaDto, ComprobanteEntradaModel>().ReverseMap();
            CreateMap<ComprobanteSalidaDto, ComprobanteSalidaModel>().ReverseMap();
            CreateMap<CondicionIvaDto, CondicionIvaModel>().ReverseMap();
            CreateMap<CuentaCorrienteDto, CuentaCorrienteModel>().ReverseMap();
            CreateMap<DescripcionTareaDto, DescripcionTareaModel>().ReverseMap();
            CreateMap<DetalleCajaDto, DetalleCajaModel>().ReverseMap();
            CreateMap<DetalleComprobanteDto, DetalleComprobanteModel>().ReverseMap();
            CreateMap<EmpresaDto, EmpresaModel>().ReverseMap();
            CreateMap<FormaPagoDto, FormaPagoModel>().ReverseMap();
            CreateMap<GastoDto, GastoModel>().ReverseMap();
            CreateMap<IngresoMaterialDto, IngresoMaterialModel>().ReverseMap();
            CreateMap<MaterialDto, MaterialModel>().ReverseMap();
            CreateMap<MovimientoDto, MovimientoModel>().ReverseMap();
            CreateMap<ObraDto, ObraModel>().ReverseMap();
            CreateMap<PersonaDto, PersonaModel>().ReverseMap();
            CreateMap<PrecioDto, PrecioModel>().ReverseMap();
            CreateMap<PresupuestoDto, PresupuestoModel>().ReverseMap();
            CreateMap<RubroDto, RubroModel>().ReverseMap();
            CreateMap<SalidaMaterialDto, SalidaMaterialModel>().ReverseMap();
            CreateMap<StockDto, StockModel>().ReverseMap();
            CreateMap<TareaDto, TareaModel>().ReverseMap();
            CreateMap<TipoGastoDto, TipoGastoModel>().ReverseMap();
            CreateMap<UsuarioDto, UsuarioModel>().ReverseMap();
            CreateMap<ZonaDto, ZonaModel>().ReverseMap();
        }
    }
}
