using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.AsistenciaContratista;
using GestionObra.Interfaces.AsistenciaContratista.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.AsistenciaContratista
{
   public class AsistenciaContratistaServicio : IAsistenciaContratistaServicio
    {
        private IRepositorio<Dominio.Entidades.AsistenciaContratista> _asistenciaContratistaRepositorio;
        private IMapper _mapper;
        public AsistenciaContratistaServicio(IRepositorio<Dominio.Entidades.AsistenciaContratista> asistenciaContratistaRepositorio)
        {
            _asistenciaContratistaRepositorio = asistenciaContratistaRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(AsistenciaContratistaDto dto)
        {
            using (var context = new DataContext())
            {
                var asistenciaContratista = _mapper.Map<Dominio.Entidades.AsistenciaContratista>(dto);
                await _asistenciaContratistaRepositorio.Create(asistenciaContratista);
            }
        }
        public async Task<IEnumerable<AsistenciaContratistaDto>> ObtenerPorJornal(long id)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.AsistenciaContratista, bool>> exp = x => true;
                exp = exp.And(x => x.JornalId == id);
                var asistenciaDiarias = await _asistenciaContratistaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.JornalId), x => x.Include(y => y.Jornal).Include(y => y.Contratista), true);
                return _mapper.Map<IEnumerable<AsistenciaContratistaDto>>(asistenciaDiarias);
            }
        }

        public async Task<IEnumerable<AsistenciaContratistaDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.AsistenciaContratista, bool>> exp = x => true;
                exp = exp.And(x => x.Contratista.RazonSocial.Contains(cadena));
                var asistenciaContratistas = await _asistenciaContratistaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Contratista.RazonSocial), x => x.Include(y => y.Contratista).Include(y => y.Jornal), true);
                return _mapper.Map<IEnumerable<AsistenciaContratistaDto>>(asistenciaContratistas);
            }
        }

        public async Task<AsistenciaContratistaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var asistenciaContratista = await _asistenciaContratistaRepositorio.GetById(id, x => x.Include(y => y.Contratista).Include(y => y.Jornal), true);
                if (asistenciaContratista == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<AsistenciaContratistaDto>(asistenciaContratista);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var asistenciaContratista = context.AsistenciaContratistas.FirstOrDefault(x => x.Id == id);
                await _asistenciaContratistaRepositorio.Delete(asistenciaContratista);
            }
        }

        public async Task Modificar(AsistenciaContratistaDto dto)
        {
            using (var context = new DataContext())
            {
                var asistenciaContratista = context.AsistenciaContratistas.FirstOrDefault(x => x.Id == dto.Id);
                asistenciaContratista.ContratistaId = dto.ContratistaId;
                asistenciaContratista.Entrada = dto.Entrada;
                asistenciaContratista.JornalId = dto.JornalId;
                asistenciaContratista.Salida = dto.Salida;
                asistenciaContratista.Observacion = dto.Observacion;
                await _asistenciaContratistaRepositorio.Update(asistenciaContratista);
            }
        }

        public async Task<IEnumerable<AsistenciaContratistaDto>> ObtenerTodos()
        {
            var asistenciaContratista = await _asistenciaContratistaRepositorio.GetAll(x => x.OrderBy(y => y.Contratista.RazonSocial), x=>x.Include(y=>y.Contratista).Include(y=>y.Jornal), true);
            return _mapper.Map<IEnumerable<AsistenciaContratistaDto>>(asistenciaContratista);
        }

        public async Task<IEnumerable<AsistenciaContratistaDto>> ObtenerPorDesde(DateTime desde, DateTime hasta, long id)
        {
            Expression<Func<Dominio.Entidades.AsistenciaContratista, bool>> exp = x => true;
            exp = exp.And(x => x.Jornal.DiaJornal.Date>=desde && x.Jornal.DiaJornal.Date<=hasta && x.ContratistaId == id);
            var asistenciaContratistas = await _asistenciaContratistaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Jornal.DiaJornal), x => x.Include(y => y.Contratista).Include(y => y.Jornal), true);
            return _mapper.Map<IEnumerable<AsistenciaContratistaDto>>(asistenciaContratistas);
        }
    }
}
