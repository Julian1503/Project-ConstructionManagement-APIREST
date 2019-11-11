using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Jornal;
using GestionObra.Interfaces.Jornal.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.JornalMaterial.JornalMaterialMaterial
{
   public class JornalMaterialServicio : IJornalMaterialServicio
    {
        private IRepositorio<Dominio.Entidades.JornalMaterial> _jornalMaterialRepositorio;
        private readonly IMapper _mapper;
        public JornalMaterialServicio(IRepositorio<Dominio.Entidades.JornalMaterial> jornalMaterialRepositorio)
        {
            _jornalMaterialRepositorio = jornalMaterialRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(JornalMaterialDto dto)
        {
            using (var context = new DataContext())
            {
                var jornalMaterial = _mapper.Map<Dominio.Entidades.JornalMaterial>(dto);
                await _jornalMaterialRepositorio.Create(jornalMaterial);
            }
        }
        public async Task<IEnumerable<JornalMaterialDto>> ObtenerPorDesde(DateTime desde, DateTime hasta)
        {
            Expression<Func<Dominio.Entidades.JornalMaterial, bool>> exp = x => true;
            exp = exp.And(x => x.Jornal.DiaJornal.Date >= desde && x.Jornal.DiaJornal.Date <= hasta);
            var asistenciaContratistas = await _jornalMaterialRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Jornal.DiaJornal), x => x.Include(y=>y.Material).Include(y => y.Jornal).Include(y => y.Jornal.Obra), true);
            return _mapper.Map<IEnumerable<JornalMaterialDto>>(asistenciaContratistas);
        }

        public async Task<IEnumerable<JornalMaterialDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.JornalMaterial, bool>> exp = x => true;
                exp = exp.And(x => x.Material.Descripcion.Contains(cadena));
                var jornalMaterials = await _jornalMaterialRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.JornalId), x => x.Include(y => y.Material).Include(y=>y.Jornal), true);
                return _mapper.Map<IEnumerable<JornalMaterialDto>>(jornalMaterials);
            }
        }

        public async Task<IEnumerable<JornalMaterialDto>> ObtenerPorJornal(long id)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.JornalMaterial, bool>> exp = x => true;
                exp = exp.And(x => x.JornalId == id);
                var jornalMaterials = await _jornalMaterialRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.JornalId), x => x.Include(y => y.Material).Include(y => y.Jornal), true);
                return _mapper.Map<IEnumerable<JornalMaterialDto>>(jornalMaterials);
            }
        }

        public async Task<IEnumerable<JornalMaterialDto>> ObtenerPorObra(long id)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.JornalMaterial, bool>> exp = x => true;
                exp = exp.And(x => x.Jornal.ObraId == id);
                var jornalMaterials = await _jornalMaterialRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Jornal.DiaJornal), x => x.Include(y => y.Material).Include(y => y.Jornal), true);
                return _mapper.Map<IEnumerable<JornalMaterialDto>>(jornalMaterials);
            }
        }

        public async Task<JornalMaterialDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var jornalMaterial = await _jornalMaterialRepositorio.GetById(id, x => x.Include(y => y.Material).Include(y => y.Jornal), true);
                if (jornalMaterial == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<JornalMaterialDto>(jornalMaterial);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var jornalMaterial = context.JornalMateriales.FirstOrDefault(x => x.Id == id);
                await _jornalMaterialRepositorio.Delete(jornalMaterial);
            }
        }

        public async Task Modificar(JornalMaterialDto dto)
        {
            using (var context = new DataContext())
            {
                var jornalMaterial = context.JornalMateriales.FirstOrDefault(x => x.Id == dto.Id);
                jornalMaterial.JornalId = dto.JornalId;
                jornalMaterial.MaterialId= dto.MaterialId;
                jornalMaterial.CantidadUsado= dto.CantidadUsado;
                await _jornalMaterialRepositorio.Update(jornalMaterial);
            }
        }

        public async Task<IEnumerable<JornalMaterialDto>> ObtenerTodos()
        {
            var jornalMaterial = await _jornalMaterialRepositorio.GetAll(x => x.OrderBy(y => y.Jornal.Obra.FechaEstimadaInicio), x => x.Include(y => y.Material).Include(y => y.Jornal).Include(y => y.Jornal.Obra), true);
            return _mapper.Map<IEnumerable<JornalMaterialDto>>(jornalMaterial);
        }
    }
}
