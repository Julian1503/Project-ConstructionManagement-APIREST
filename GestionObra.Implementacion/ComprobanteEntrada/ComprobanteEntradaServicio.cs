using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.ComprobanteEntrada;
using GestionObra.Interfaces.ComprobanteEntrada.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.ComprobanteEntrada
{
    public class ComprobanteEntradaServicio : IComprobanteEntradaRepositorio
    {
        private readonly IRepositorio<Dominio.Entidades.ComprobanteEntrada> _comprobanteRepositorio;
        private IMapper _mapper;
        public ComprobanteEntradaServicio(IRepositorio<Dominio.Entidades.ComprobanteEntrada> comprobanteRepositorio)
        {
            _comprobanteRepositorio = comprobanteRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task<long> Insertar(ComprobanteEntradaDto dto)
        {
            using (var context = new DataContext())
            {
                var comprobanteNuevo = _mapper.Map<Dominio.Entidades.ComprobanteEntrada>(dto);
                await _comprobanteRepositorio.Create(comprobanteNuevo);
                return comprobanteNuevo.Id;
            }
        }
        public async Task<IEnumerable<ComprobanteEntradaDto>> ObtenerTodos()
        {
            var comprobante = await _comprobanteRepositorio.GetAll(x => x.OrderBy(y => y.NumeroComprobante), x => x.Include(y => y.Usuario).Include(y => y.SubRubro).Include(y => y.SubRubro.Rubro), true);
            return _mapper.Map<IEnumerable<ComprobanteEntradaDto>>(comprobante).Where(x => x.Fecha.Year == DateTime.Now.Year);
        }

        public async Task<IEnumerable<ComprobanteEntradaDto>> ObtenerPorDesde(DateTime desde, DateTime hasta)
        {
            Expression<Func<Dominio.Entidades.ComprobanteEntrada, bool>> exp = x => true;
            exp = exp.And(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta);
            var asistenciaContratistas = await _comprobanteRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.NumeroComprobante), x => x.Include(y => y.SubRubro).Include(y => y.SubRubro.Rubro), true);
            return _mapper.Map<IEnumerable<ComprobanteEntradaDto>>(asistenciaContratistas);
        }
        public async Task<IEnumerable<ComprobanteEntradaDto>> ObtenerPorRubro(DateTime desde, DateTime hasta, long rubroId)
        {
            Expression<Func<Dominio.Entidades.ComprobanteEntrada, bool>> exp = x => true;
            exp = exp.And(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta && rubroId == x.SubRubro.RubroId);
            var asistenciaContratistas = await _comprobanteRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.NumeroComprobante), x => x.Include(y => y.SubRubro), true);
            return _mapper.Map<IEnumerable<ComprobanteEntradaDto>>(asistenciaContratistas);
        }

        public async Task<IEnumerable<ComprobanteEntradaDto>> ObtenerPorSubRubro(DateTime desde, DateTime hasta, long subRubroId)
        {
            Expression<Func<Dominio.Entidades.ComprobanteEntrada, bool>> exp = x => true;
            exp = exp.And(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta && subRubroId == x.SubRubroId);
            var asistenciaContratistas = await _comprobanteRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.NumeroComprobante), x => x.Include(y => y.SubRubro), true);
            return _mapper.Map<IEnumerable<ComprobanteEntradaDto>>(asistenciaContratistas);
        }

        public async Task<IEnumerable<ComprobanteEntradaDto>> Obtener(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.ComprobanteEntrada, bool>> exp = x => true;
                exp = exp.And(x => x.Detalle.Contains(cadena));
                var comprobantes = await
                    _comprobanteRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.NumeroComprobante), x => x.Include(y => y.Usuario).Include(y => y.SubRubro), true);
                return _mapper.Map<IEnumerable<ComprobanteEntradaDto>>(comprobantes);
            }
        }

        public async Task<ComprobanteEntradaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var comprobanteById = await _comprobanteRepositorio.GetById(id, enableTracking: true);
                if (comprobanteById == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<ComprobanteEntradaDto>(comprobanteById);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var comprobanteBorrar = context.ComprobantesEntrada.FirstOrDefault(x => x.Id == id);
                if (comprobanteBorrar != null)
                    await _comprobanteRepositorio.Delete(comprobanteBorrar);
            }
        }
        public async Task<decimal[]> ObtenerPorcentajes()
        {
            Expression<Func<Dominio.Entidades.ComprobanteEntrada, bool>> exp = x => true;
            exp = exp.And(x => x.TipoComprobanteEntrada== Constantes.TipoComprobanteEntrada.Ninguno);
            var negro = await _comprobanteRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.NumeroComprobante), x => x.Include(y => y.SubRubro), true);
            var montoNegro = _mapper.Map<IEnumerable<ComprobanteEntradaDto>>(negro).Sum(x => x.Total);

            Expression<Func<Dominio.Entidades.ComprobanteEntrada, bool>> ex = x => true;
            ex = ex.And(x => x.TipoComprobanteEntrada != Constantes.TipoComprobanteEntrada.Ninguno);
            var blanco = await _comprobanteRepositorio.GetByFilter(ex, x => x.OrderBy(y => y.NumeroComprobante), x => x.Include(y => y.SubRubro), true);
            var montoBlanco = _mapper.Map<IEnumerable<ComprobanteEntradaDto>>(blanco).Sum(x => x.Total);
            return new decimal[] { montoBlanco, montoNegro };
        }

        public async Task<long> ObtenerSiguienteId()
        {
            using (var context = new DataContext())
            {
                var comprobantes = await _comprobanteRepositorio.GetAll(x => x.OrderBy(y => y.Id), null, true);
                if (comprobantes.Count() == 0)
                {
                    return 1;
                }
                return comprobantes.Max(x => x.Id) + 1;
            }
        }
        public async Task Modificar(ComprobanteEntradaDto dto)
        {
            using (var context = new DataContext())
            {
                var comprobanteModificar = context.ComprobantesEntrada.FirstOrDefault(x => x.Id == dto.Id);
                comprobanteModificar = _mapper.Map<Dominio.Entidades.ComprobanteEntrada>(dto);
                await _comprobanteRepositorio.Update(comprobanteModificar);
            }
        }
    }
}

