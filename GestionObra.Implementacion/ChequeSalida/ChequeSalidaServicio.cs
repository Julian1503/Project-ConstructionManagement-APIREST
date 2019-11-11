using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.ChequeSalida;
using GestionObra.Interfaces.ChequeSalida.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.ChequeSalida
{
   public class ChequeSalidaServicio : IChequeSalidaServicio
    {
        private IRepositorio<Dominio.Entidades.ChequeSalida> _chequeSalidaRepositorio;
        private IMapper _mapper;
        public ChequeSalidaServicio(IRepositorio<Dominio.Entidades.ChequeSalida> chequeSalidaRepositorio)
        {
            _chequeSalidaRepositorio = chequeSalidaRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(ChequeSalidaDto dto)
        {
            using (var context = new DataContext())
            {
                var chequeSalida = _mapper.Map<Dominio.Entidades.ChequeSalida>(dto);
                await _chequeSalidaRepositorio.Create(chequeSalida);
            }
        }

        public async Task<IEnumerable<ChequeSalidaDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.ChequeSalida, bool>> exp = x => true;
                exp = exp.And(x => x.Numero.ToString().Contains(cadena));
                var chequeSalidas = await _chequeSalidaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
                return _mapper.Map<IEnumerable<ChequeSalidaDto>>(chequeSalidas);
            }
        }

        public async Task<IEnumerable<ChequeSalidaDto>> ObtenerPorDesde(DateTime desde, DateTime hasta)
        {
            Expression<Func<Dominio.Entidades.ChequeSalida, bool>> exp = x => true;
            exp = exp.And(x => x.FechaDesde.Date >= desde && x.FechaDesde.Date <= hasta);
            var asistenciaContratistas = await _chequeSalidaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<ChequeSalidaDto>>(asistenciaContratistas);
        }
        public async Task<IEnumerable<ChequeSalidaDto>> ObtenerPorConcepto(DateTime desde, DateTime hasta,string concepto)
        {
            Expression<Func<Dominio.Entidades.ChequeSalida, bool>> exp = x => true;
            exp = exp.And(x => x.FechaDesde.Date >= desde && x.FechaDesde.Date <= hasta && x.Concepto.Contains(concepto));
            var asistenciaContratistas = await _chequeSalidaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<ChequeSalidaDto>>(asistenciaContratistas);
        }
        public async Task<IEnumerable<ChequeSalidaDto>> ObtenerPorDePara(DateTime desde, DateTime hasta, string dePara)
        {
            Expression<Func<Dominio.Entidades.ChequeSalida, bool>> exp = x => true;
            exp = exp.And(x => x.FechaDesde.Date >= desde && x.FechaDesde.Date <= hasta && x.PagueseA.Contains(dePara));
            var asistenciaContratistas = await _chequeSalidaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<ChequeSalidaDto>>(asistenciaContratistas);
        }
        public async Task<IEnumerable<ChequeSalidaDto>> ObtenerPorTodo(DateTime desde, DateTime hasta,string paguese,string concepto,string numero)
        {
            Expression<Func<Dominio.Entidades.ChequeSalida, bool>> exp = x => true;
            exp = exp.And(x => x.FechaDesde.Date >= desde && x.FechaDesde.Date <= hasta && x.PagueseA.Contains(paguese) && x.Concepto.Contains(concepto) && x.Numero.ToString().Contains(numero));
            var asistenciaContratistas = await _chequeSalidaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<ChequeSalidaDto>>(asistenciaContratistas);
        }

        public async Task<ChequeSalidaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var chequeSalida = await _chequeSalidaRepositorio.GetById(id, x => x.Include(y => y.Banco), true);
                if (chequeSalida == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<ChequeSalidaDto>(chequeSalida);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var chequeSalida = context.ChequesSalida.FirstOrDefault(x => x.Id == id);
                await _chequeSalidaRepositorio.Delete(chequeSalida);
            }
        }

        public async Task Modificar(ChequeSalidaDto dto)
        {
            using (var context = new DataContext())
            {
                var chequeSalida = context.ChequesSalida.FirstOrDefault(x => x.Id == dto.Id);
                chequeSalida.Monto = dto.Monto;
                chequeSalida.Numero = dto.Numero;
                chequeSalida.Usado = dto.Usado;
                chequeSalida.Serie = dto.Serie;
                chequeSalida.FechaHasta = dto.FechaHasta;
                chequeSalida.FechaDesde = dto.FechaDesde;
                chequeSalida.PagueseA = dto.PagueseA;
                chequeSalida.Concepto = dto.Concepto;
                chequeSalida.BancoId = dto.BancoId;
                await _chequeSalidaRepositorio.Update(chequeSalida);
            }
        }

        public async Task<IEnumerable<ChequeSalidaDto>> ObtenerTodos()
        {
            var chequeSalida = await _chequeSalidaRepositorio.GetAll(x => x.OrderBy(y => y.Numero), x=>x.Include(y=>y.Banco), true);
            return _mapper.Map<IEnumerable<ChequeSalidaDto>>(chequeSalida);
        }
    }
}
