using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.AsistenciaDiaria;
using GestionObra.Interfaces.AsistenciaDiaria.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.AsistenciaDiaria
{
    public class AsistenciaDiariaServicio : IAsistenciaDiariaServicio
    {
        private IRepositorio<Dominio.Entidades.AsistenciaDiaria> _asistenciaDiariaRepositorio;
        private IMapper _mapper;
        public AsistenciaDiariaServicio(IRepositorio<Dominio.Entidades.AsistenciaDiaria> asistenciaDiariaRepositorio)
        {
            _asistenciaDiariaRepositorio = asistenciaDiariaRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(AsistenciaDiariaDto dto)
        {
            using (var context = new DataContext())
            {
                var asistenciaDiaria = _mapper.Map<Dominio.Entidades.AsistenciaDiaria>(dto);
                await _asistenciaDiariaRepositorio.Create(asistenciaDiaria);
            }
        }

        public async Task<IEnumerable<AsistenciaDiariaDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.AsistenciaDiaria, bool>> exp = x => true;
                exp = exp.And(x => x.Empleado.Apellido.Contains(cadena));
                var asistenciaDiarias = await _asistenciaDiariaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.JornalId), x=>x.Include(y=>y.Jornal).Include(y => y.Empleado).Include(y => y.Causa), true);
                return _mapper.Map<IEnumerable<AsistenciaDiariaDto>>(asistenciaDiarias);
            }
        }

        public async Task<IEnumerable<AsistenciaDiariaDto>> ObtenerPorJornal(long id)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.AsistenciaDiaria, bool>> exp = x => true;
                exp = exp.And(x => x.JornalId==id);
                var asistenciaDiarias = await _asistenciaDiariaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.JornalId), x => x.Include(y => y.Jornal).Include(y => y.Empleado).Include(y => y.Causa), true);
                return _mapper.Map<IEnumerable<AsistenciaDiariaDto>>(asistenciaDiarias);
            }
        }
        public async Task<IEnumerable<AsistenciaDiariaDto>> ObtenerPorDesde(DateTime desde, DateTime hasta, long id)
        {
            Expression<Func<Dominio.Entidades.AsistenciaDiaria, bool>> exp = x => true;
            exp = exp.And(x => x.Jornal.DiaJornal.Date >= desde && x.Jornal.DiaJornal.Date <= hasta && x.EmpleadoId == id);
            var asistenciaContratistas = await _asistenciaDiariaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Jornal.DiaJornal), x => x.Include(y => y.Empleado).Include(y => y.Jornal).Include(y => y.Causa), true);
            return _mapper.Map<IEnumerable<AsistenciaDiariaDto>>(asistenciaContratistas);
        }
        public async Task<AsistenciaDiariaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var asistenciaDiaria = await _asistenciaDiariaRepositorio.GetById(id, x => x.Include(y => y.Jornal).Include(y => y.Empleado).Include(y => y.Causa), true);
                if (asistenciaDiaria == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<AsistenciaDiariaDto>(asistenciaDiaria);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var asistenciaDiaria = context.AsistenciaDiarias.FirstOrDefault(x => x.Id == id);
                await _asistenciaDiariaRepositorio.Delete(asistenciaDiaria);
            }
        }

        public async Task Modificar(AsistenciaDiariaDto dto)
        {
            using (var context = new DataContext())
            {
                var asistenciaDiaria = context.AsistenciaDiarias.FirstOrDefault(x => x.Id == dto.Id);
                asistenciaDiaria.JornalId = dto.JornalId;
                asistenciaDiaria.Observacion= dto.Observacion;
                asistenciaDiaria.Salida= dto.Salida;
                asistenciaDiaria.Entrada= dto.Entrada;
                asistenciaDiaria.EmpleadoId = dto.EmpleadoId;
                asistenciaDiaria.Asistio = dto.Asistio;
                asistenciaDiaria.CausaId= dto.CausaId;
                await _asistenciaDiariaRepositorio.Update(asistenciaDiaria);
            }
        }

        public async Task<IEnumerable<AsistenciaDiariaDto>> ObtenerTodos()
        {
            var asistenciaDiaria = await _asistenciaDiariaRepositorio.GetAll(x => x.OrderBy(y => y.JornalId), x => x.Include(y => y.Causa).Include(y => y.Jornal).Include(y => y.Empleado), true);
            return _mapper.Map<IEnumerable<AsistenciaDiariaDto>>(asistenciaDiaria);
        }
    }
}
