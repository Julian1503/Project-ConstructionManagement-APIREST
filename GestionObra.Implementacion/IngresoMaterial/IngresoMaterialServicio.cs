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
using GestionObra.Interfaces.IngresoMaterial;
using GestionObra.Interfaces.IngresoMaterial.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.IngresoMaterial
{
    public class IngresoMaterialServicio : IIngresoMaterialRepositorio
    {
        private IRepositorio<Dominio.Entidades.IngresoMaterial> _ingresoMaterialRepositorio;
        private IMapper _mapper;
        public IngresoMaterialServicio(IRepositorio<Dominio.Entidades.IngresoMaterial> ingresoMaterialRepositorio)
        {
            _ingresoMaterialRepositorio = ingresoMaterialRepositorio;
            var config = new MapperConfiguration(x=>x.AddProfile<MapperProfile.MapperProfile>());
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

        public async Task<IEnumerable<IngresoMaterialDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.IngresoMaterial, bool>> exp = x => true;
                exp = exp.And(x=>x.ObraId.ToString().Equals(cadena)).Or(x=>x.Propietario.NombreFantasia.Contains(cadena));
                var ingresoMaterial = await _ingresoMaterialRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.ObraId),
                    x => x.Include(y => y.Propietario),  true);
                return _mapper.Map<IEnumerable<IngresoMaterialDto>>(ingresoMaterial);

            }
        }
        public async Task<IEnumerable<IngresoMaterialDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var ingresoMateriales = await _ingresoMaterialRepositorio.GetAll(x => x.OrderBy(y => y.ObraId),
                    x => x.Include(y => y.Obra).Include(y => y.Material).Include(y => y.Propietario), true);
                return _mapper.Map<IEnumerable<IngresoMaterialDto>>(ingresoMateriales);
            }
        }

        public async Task<IngresoMaterialDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var ingresoMaterial =  await _ingresoMaterialRepositorio.GetById(id,
                    x => x.Include(y => y.Obra).Include(y => y.Material).Include(y => y.Propietario), true);
                return _mapper.Map<IngresoMaterialDto>(ingresoMaterial);
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
                ingresoMaterial.CantidadUsado = dto.CantidadUsado;
                ingresoMaterial.FechaIngreso = dto.FechaIngreso;
                ingresoMaterial.MaterialId = dto.MaterialId;
                ingresoMaterial.ObraId = dto.ObraId;
                ingresoMaterial.PropietarioId = dto.PropietarioId;
                await _ingresoMaterialRepositorio.Update(ingresoMaterial);
            }
        }
    }
}
