using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.ChequeEntrada;
using GestionObra.Interfaces.ChequeEntrada.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.ChequeEntrada
{
    public class ChequeEntradaServicio : IChequeEntradaServicio
    {
        private IRepositorio<Dominio.Entidades.ChequeEntrada> _chequeEntradaRepositorio;
        private IMapper _mapper;
        public ChequeEntradaServicio(IRepositorio<Dominio.Entidades.ChequeEntrada> chequeEntradaRepositorio)
        {
            _chequeEntradaRepositorio = chequeEntradaRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(ChequeEntradaDto dto)
        {
            using (var context = new DataContext())
            {
                var chequeEntrada = _mapper.Map<Dominio.Entidades.ChequeEntrada>(dto);
                await _chequeEntradaRepositorio.Create(chequeEntrada);
            }
        }

        public async Task<IEnumerable<ChequeEntradaDto>> ObtenerPorDesde(DateTime desde, DateTime hasta)
        {
            Expression<Func<Dominio.Entidades.ChequeEntrada, bool>> exp = x => true;
            exp = exp.And(x => x.FechaDesde.Date >= desde && x.FechaDesde.Date <= hasta);
            var asistenciaContratistas = await _chequeEntradaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<ChequeEntradaDto>>(asistenciaContratistas);
        }

        public async Task<IEnumerable<ChequeEntradaDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.ChequeEntrada, bool>> exp = x => true;
                exp = exp.And(x => x.Numero.ToString().Contains(cadena));
                var chequeEntradas = await _chequeEntradaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), null, true);
                return _mapper.Map<IEnumerable<ChequeEntradaDto>>(chequeEntradas);
            }
        }

        public async Task<ChequeEntradaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var chequeEntrada = await _chequeEntradaRepositorio.GetById(id, null, true);
                if (chequeEntrada == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<ChequeEntradaDto>(chequeEntrada);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var chequeEntrada = context.ChequesEntrada.FirstOrDefault(x => x.Id == id);
                await _chequeEntradaRepositorio.Delete(chequeEntrada);
            }
        }

        public async Task Modificar(ChequeEntradaDto dto)
        {
            using (var context = new DataContext())
            {
                var chequeEntrada = context.ChequesEntrada.FirstOrDefault(x => x.Id == dto.Id);
                chequeEntrada.Monto=dto.Monto;
                chequeEntrada.MontoDescontado=dto.MontoDescontado;
                chequeEntrada.Numero=dto.Numero;
                chequeEntrada.Serie=dto.Serie;
                chequeEntrada.Usado = dto.Usado;
                chequeEntrada.FechaHasta=dto.FechaHasta;
                chequeEntrada.FechaDesde=dto.FechaDesde;
                chequeEntrada.Estado=dto.Estado;
                chequeEntrada.EmitidoPor = dto.EmitidoPor;
                chequeEntrada.Descontado= dto.Descontado;
                chequeEntrada.Concepto= dto.Concepto;
                chequeEntrada.BancoId= dto.BancoId;
                await _chequeEntradaRepositorio.Update(chequeEntrada);
            }
        }

        public async Task<IEnumerable<ChequeEntradaDto>> ObtenerTodos()
        {
            var chequeEntrada = await _chequeEntradaRepositorio.GetAll(x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<ChequeEntradaDto>>(chequeEntrada);
        }

        public async Task<IEnumerable<ChequeEntradaDto>> ObtenerPorConcepto(DateTime desde, DateTime hasta, string concepto)
        {
            Expression<Func<Dominio.Entidades.ChequeEntrada, bool>> exp = x => true;
            exp = exp.And(x => x.FechaDesde.Date >= desde && x.FechaDesde.Date <= hasta && x.Concepto.Contains(concepto));
            var asistenciaContratistas = await _chequeEntradaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<ChequeEntradaDto>>(asistenciaContratistas);
        }
        public async Task<IEnumerable<ChequeEntradaDto>> ObtenerPorDePara(DateTime desde, DateTime hasta, string dePara)
        {
            Expression<Func<Dominio.Entidades.ChequeEntrada, bool>> exp = x => true;
            exp = exp.And(x => x.FechaDesde.Date >= desde && x.FechaDesde.Date <= hasta && x.EmitidoPor.Contains(dePara));
            var asistenciaContratistas = await _chequeEntradaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<ChequeEntradaDto>>(asistenciaContratistas);
        }
    }
}