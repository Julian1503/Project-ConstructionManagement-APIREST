using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Transferencia;
using GestionObra.Interfaces.Transferencia.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.Transferencia
{
   public class TransferenciaServicio : ITransferenciaServicio
    {
        private readonly IRepositorio<Dominio.Entidades.Transferencia> _TransferenciaRepositorio;
        private IMapper _mapper;
        public TransferenciaServicio(IRepositorio<Dominio.Entidades.Transferencia> TransferenciaRepositorio)
        {
            _TransferenciaRepositorio = TransferenciaRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task<long> Insertar(TransferenciaDto dto)
        {
            using (var context = new DataContext())
            {
                var TransferenciaNuevo = _mapper.Map<Dominio.Entidades.Transferencia>(dto);
                await _TransferenciaRepositorio.Create(TransferenciaNuevo);
                return TransferenciaNuevo.Id;
            }
        }


        public async Task<IEnumerable<TransferenciaDto>> ObtenerPorDesde(DateTime desde, DateTime hasta)
        {
            Expression<Func<Dominio.Entidades.Transferencia, bool>> exp = x => true;
            exp = exp.And(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta);
            var asistenciaContratistas = await _TransferenciaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<TransferenciaDto>>(asistenciaContratistas);
        }

        public async Task<IEnumerable<TransferenciaDto>> ObtenerPorPaguese(DateTime desde, DateTime hasta,string pagueseA)
        {
            Expression<Func<Dominio.Entidades.Transferencia, bool>> exp = x => true;
            exp = exp.And(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta && x.PagueseA.Contains(pagueseA));
            var asistenciaContratistas = await _TransferenciaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<TransferenciaDto>>(asistenciaContratistas);
        }

        public async Task<IEnumerable<TransferenciaDto>> ObtenerTodos()
        {
            var Transferencia = await _TransferenciaRepositorio.GetAll(x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<TransferenciaDto>>(Transferencia);
        }
        public async Task<IEnumerable<TransferenciaDto>> Obtener(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Transferencia, bool>> exp = x => true;
                exp = exp.And(x => x.Concepto.Contains(cadena));
                var Transferencias = await
                    _TransferenciaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
                return _mapper.Map<IEnumerable<TransferenciaDto>>(Transferencias);
            }
        }

        public async Task<TransferenciaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var TransferenciaById = await _TransferenciaRepositorio.GetById(id, enableTracking: true);
                if (TransferenciaById == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<TransferenciaDto>(TransferenciaById);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var TransferenciaBorrar = context.Transferencias.FirstOrDefault(x => x.Id == id);
                if (TransferenciaBorrar != null)
                    await _TransferenciaRepositorio.Delete(TransferenciaBorrar);
            }
        }

        public async Task<long> ObtenerSiguienteId()
        {
            using (var context = new DataContext())
            {
                var Transferencias = await _TransferenciaRepositorio.GetAll(x => x.OrderBy(y => y.Id), x => x.Include(y => y.Banco), true);
                if (Transferencias.Count() == 0)
                {
                    return 1;
                }
                return Transferencias.Max(x => x.Id) + 1;
            }
        }
        public async Task Modificar(TransferenciaDto dto)
        {
            using (var context = new DataContext())
            {
                var TransferenciaModificar = context.Transferencias.FirstOrDefault(x => x.Id == dto.Id);
                TransferenciaModificar = _mapper.Map<Dominio.Entidades.Transferencia>(dto);
                await _TransferenciaRepositorio.Update(TransferenciaModificar);
            }
        }

        public async Task<IEnumerable<TransferenciaDto>> ObtenerPorConcepto(DateTime desde, DateTime hasta, string concepto)
        {
            Expression<Func<Dominio.Entidades.Transferencia, bool>> exp = x => true;
            exp = exp.And(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta && x.Concepto.Contains(concepto));
            var asistenciaContratistas = await _TransferenciaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Numero), x => x.Include(y => y.Banco), true);
            return _mapper.Map<IEnumerable<TransferenciaDto>>(asistenciaContratistas);
        }
    }
}