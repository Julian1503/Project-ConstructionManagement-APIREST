using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Operacion;
using GestionObra.Interfaces.Operacion.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.Operacion
{
    public class OperacionServicio : IOperacionServicio
    {
        private IRepositorio<Dominio.Entidades.Operacion> _operacionRepositorio;
        private IMapper _mapper;
        public OperacionServicio(IRepositorio<Dominio.Entidades.Operacion> operacionRepositorio)
        {
            _operacionRepositorio = operacionRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(OperacionDto dto)
        {
            using (var context = new DataContext())
            {
                var operacion = _mapper.Map<Dominio.Entidades.Operacion>(dto);
                await _operacionRepositorio.Create(operacion);
            }
        }
        public async Task<IEnumerable<OperacionDto>> ObtenerPorTiempo(DateTime desde, DateTime hasta, long idCuentaCorriente)
        {
            Expression<Func<Dominio.Entidades.Operacion, bool>> exp = x => true;
            exp = exp.And(x => x.FechaEmision.Value.Date >= desde && x.FechaEmision.Value.Date <= hasta && x.CuentaCorrienteId ==idCuentaCorriente);
            var operaciones = await _operacionRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.FechaEmision), x => x.Include(y => y.CuentaCorriente), true);
            return _mapper.Map<IEnumerable<OperacionDto>>(operaciones);
        }
        public async Task<IEnumerable<OperacionDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Operacion, bool>> exp = x => true;
                exp = exp.And(x => x.Referencia.ToString().Contains(cadena));
                var operacions = await _operacionRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.FechaEmision), x=>x.Include(y=>y.CuentaCorriente), true);
                return _mapper.Map<IEnumerable<OperacionDto>>(operacions);
            }
        }
        public async Task<IEnumerable<OperacionDto>> ObtenerPorBanco(long id)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Operacion, bool>> exp = x => true;
                exp = exp.And(x => x.CuentaCorriente.BancoId==id);
                var operacions = await _operacionRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.FechaEmision), x => x.Include(y => y.CuentaCorriente), true);
                return _mapper.Map<IEnumerable<OperacionDto>>(operacions);
            }
        }

        public async Task<OperacionDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var operacion = await _operacionRepositorio.GetById(id, x => x.Include(y => y.CuentaCorriente), true);
                if (operacion == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<OperacionDto>(operacion);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var operacion = context.Operaciones.FirstOrDefault(x => x.Id == id);
                await _operacionRepositorio.Delete(operacion);
            }
        }

        public async Task Modificar(OperacionDto dto)
        {
            using (var context = new DataContext())
            {
                var operacion = context.Operaciones.FirstOrDefault(x => x.Id == dto.Id);
                operacion.CodigoCausal = dto.CodigoCausal;
                operacion.CuentaCorrienteId= dto.CuentaCorrienteId;
                operacion.Debe = dto.Debe;
                operacion.Haber= dto.Haber;
                operacion.Referencia= dto.Referencia;
                operacion.ReferenciaPlus= dto.ReferenciaPlus;
                operacion.FechaEmision = dto.FechaEmision;
                operacion.FechaVencimiento = dto.FechaVencimiento;
                operacion.EstaEnResumen= dto.EstaEnResumen;
                await _operacionRepositorio.Update(operacion);
            }
        }

        public async Task<IEnumerable<OperacionDto>> ObtenerTodos()
        {
            var operacion = await _operacionRepositorio.GetAll(x => x.OrderByDescending(y => y.FechaEmision), x => x.Include(y => y.CuentaCorriente), true);
            return _mapper.Map<IEnumerable<OperacionDto>>(operacion);
        }
    }
}
