using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Deposito;
using GestionObra.Interfaces.Deposito.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.Deposito
{
   public class DepositoServicio : IDepositoServicio
    {
        private readonly IRepositorio<Dominio.Entidades.Deposito> _depositoRepositorio;
        private IMapper _mapper;
        public DepositoServicio(IRepositorio<Dominio.Entidades.Deposito> depositoRepositorio)
        {
            _depositoRepositorio = depositoRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task<long> Insertar(DepositoDto dto)
        {
            using (var context = new DataContext())
            {
                var depositoNuevo = _mapper.Map<Dominio.Entidades.Deposito>(dto);
                await _depositoRepositorio.Create(depositoNuevo);
                return depositoNuevo.Id;
            }
        }


        public async Task<IEnumerable<DepositoDto>> ObtenerPorDesde(DateTime desde, DateTime hasta)
        {
            Expression<Func<Dominio.Entidades.Deposito, bool>> exp = x => true;
            exp = exp.And(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta);
            var asistenciaContratistas = await _depositoRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<DepositoDto>>(asistenciaContratistas);
        }

        public async Task<IEnumerable<DepositoDto>> ObtenerTodos()
        {
            var deposito = await _depositoRepositorio.GetAll(x => x.OrderBy(y => y.Numero),x=> x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<DepositoDto>>(deposito);
        }
        public async Task<IEnumerable<DepositoDto>> Obtener(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Deposito, bool>> exp = x => true;
                exp = exp.And(x => x.Concepto.Contains(cadena));
                var depositos = await
                    _depositoRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x=>x.Include(y => y.Banco), true);
                return _mapper.Map<IEnumerable<DepositoDto>>(depositos);
            }
        }

        public async Task<DepositoDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var depositoById = await _depositoRepositorio.GetById(id, enableTracking: true);
                if (depositoById == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<DepositoDto>(depositoById);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var depositoBorrar = context.Depositos.FirstOrDefault(x => x.Id == id);
                if (depositoBorrar != null)
                    await _depositoRepositorio.Delete(depositoBorrar);
            }
        }

        public async Task<long> ObtenerSiguienteId()
        {
            using (var context = new DataContext())
            {
                var depositos = await _depositoRepositorio.GetAll(x => x.OrderBy(y => y.Id),x=> x.Include(y => y.Banco), true);
                if (depositos.Count() == 0)
                {
                    return 1;
                }
                return depositos.Max(x => x.Id) + 1;
            }
        }
        public async Task Modificar(DepositoDto dto)
        {
            using (var context = new DataContext())
            {
                var depositoModificar = context.Depositos.FirstOrDefault(x => x.Id == dto.Id);
                depositoModificar = _mapper.Map<Dominio.Entidades.Deposito>(dto);
                await _depositoRepositorio.Update(depositoModificar);
            }
        }

        public async Task<IEnumerable<DepositoDto>> ObtenerPorConcepto(DateTime desde, DateTime hasta, string concepto)
        {
            Expression<Func<Dominio.Entidades.Deposito, bool>> exp = x => true;
            exp = exp.And(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta && x.Concepto.Contains(concepto));
            var asistenciaContratistas = await _depositoRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<DepositoDto>>(asistenciaContratistas);
        }
        public async Task<IEnumerable<DepositoDto>> ObtenerPorDePara(DateTime desde, DateTime hasta, string dePara)
        {
            Expression<Func<Dominio.Entidades.Deposito, bool>> exp = x => true;
            exp = exp.And(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta && x.DePara.Contains(dePara));
            var asistenciaContratistas = await _depositoRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<DepositoDto>>(asistenciaContratistas);
        }
    }
}