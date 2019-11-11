using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.IngresoMaterial;
using GestionObra.Interfaces.IngresoMaterial.DTOs;
using GestionObra.Interfaces.Material.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.IngresoMaterial
{
    public class IngresoMaterialServicio : IIngresoMaterialRepositorio
    {
        private IRepositorio<Dominio.Entidades.IngresoMaterial> _ingresoMaterialRepositorio;
        private IMapper _mapper;
        public IngresoMaterialServicio(IRepositorio<Dominio.Entidades.IngresoMaterial> ingresoMaterialRepositorio)
        {
            _ingresoMaterialRepositorio = ingresoMaterialRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(IngresoMaterialDto dto)
        {
            using (var context = new DataContext())
            {
                var ingresoMaterial = _mapper.Map<Dominio.Entidades.IngresoMaterial>(dto);
                await _ingresoMaterialRepositorio.Create(ingresoMaterial);
            }
        }
        public async Task<IEnumerable<IngresoMaterialDto>> ObtenerPorObra(long id)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.IngresoMaterial, bool>> exp = x => true;
                exp = exp.And(x => x.ObraId == id);
                var ingresoMaterial = await _ingresoMaterialRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.ObraId),
                    x => x.Include(y => y.Obra).Include(y => y.Material).Include(y => y.Encargado), true);
                return _mapper.Map<List<IngresoMaterialDto>>(ingresoMaterial);
            }
        }
        public async Task<IEnumerable<IngresoMaterialDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.IngresoMaterial, bool>> exp = x => true;
                exp = exp.And(x => x.ObraId.ToString().Equals(cadena)).Or(x => x.Encargado.Nombre.Contains(cadena));
                var ingresoMaterial = await _ingresoMaterialRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.ObraId),
                    x => x.Include(y => y.Obra).Include(y => y.Material).Include(y => y.Encargado), true);
                return _mapper.Map<List<IngresoMaterialDto>>(ingresoMaterial);
            }
        }
        public async Task<IEnumerable<IngresoMaterialDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var ingresoMateriales = await _ingresoMaterialRepositorio.GetAll(x => x.OrderBy(y => y.ObraId),
                    x => x.Include(y => y.Obra).Include(y => y.Material).Include(y => y.Encargado), true);
                return _mapper.Map<List<IngresoMaterialDto>>(ingresoMateriales);
            }
        }

        public async Task<IngresoMaterialDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var ingresoMaterial = await _ingresoMaterialRepositorio.GetById(id,
                    x => x.Include(y => y.Obra).Include(y => y.Material).Include(y => y.Encargado), true);
                return _mapper.Map<IngresoMaterialDto>(ingresoMaterial);
            }
        }

        public async Task<IEnumerable<MaterialDto>> ObtenerMaterialPorObra(long id)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.IngresoMaterial, bool>> exp = x => true;
                exp = exp.And(x => x.ObraId == id);
                var ingresoMaterial = await _ingresoMaterialRepositorio.GetByFilter(exp, null,x=>x.Include(y=>y.Material), true);
               return  ingresoMaterial.Select(x => new MaterialDto
                {
                     Descripcion = x.Material.Descripcion,
                     Codigo = x.Material.Codigo,
                     Detalle=x.Material.Detalle,
                     EstaEliminado=x.Material.EstaEliminado,
                     Id=x.Material.Id,
                     Path=x.Material.Path,
                     TipoMaterial=x.Material.TipoMaterial
                }).ToList().Distinct(new MaterialComparer());
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var ingresoMaterial = context.IngresoMateriales.FirstOrDefault(x => x.Id == id);
                await _ingresoMaterialRepositorio.Delete(ingresoMaterial);
            }
        }

        public async Task Modificar(IngresoMaterialDto dto)
        {
            using (var context = new DataContext())
            {
                var ingresoMaterial = context.IngresoMateriales.FirstOrDefault(x => x.Id == dto.Id);
                ingresoMaterial.Cantidad = dto.Cantidad;
                ingresoMaterial.CantidadDevuelta = dto.CantidadDevuelta;
                ingresoMaterial.FechaIngreso = dto.FechaIngreso;
                ingresoMaterial.MaterialId = dto.MaterialId;
                ingresoMaterial.ObraId = dto.ObraId;
                ingresoMaterial.EncargadoId = dto.EncargadoId;
                await _ingresoMaterialRepositorio.Update(ingresoMaterial);
            }
        }
    }
}
