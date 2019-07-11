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
using GestionObra.Interfaces.Material;
using GestionObra.Interfaces.Material.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Material
{
    public class MaterialServicio : IMaterialRepositorio
    {
        private IRepositorio<Dominio.Entidades.Material> _materialRepositorio;
        private IMapper _mapper;

        public MaterialServicio(IRepositorio<Dominio.Entidades.Material> materialRepositorio)
        {
            _materialRepositorio = materialRepositorio;
            var config = new MapperConfiguration(x=>x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(MaterialDto dto)
        {
            using (var context = new DataContext())
            {
                var material = _mapper.Map<Dominio.Entidades.Material>(dto);
                await _materialRepositorio.Create(material);
            }
        }

        public async Task<IEnumerable<MaterialDto>> Obtener(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Material, bool>> exp = x => true;
                exp = exp.And(x => x.Descripcion.Contains(cadena));
                var materiales =await _materialRepositorio.GetByFilter(exp,x=>x.OrderByDescending(y=>y.Codigo).OrderByDescending(y=>y.Descripcion),null,true);
                return _mapper.Map<IEnumerable<MaterialDto>>(materiales);
            }
        }

        public async Task<MaterialDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var material =  await _materialRepositorio.GetById(id, null, true);
                if (material == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<MaterialDto>(material);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var material = context.Materiales.FirstOrDefault(x => x.Id == id);
                await _materialRepositorio.Delete(material);
            }
        }

        public async Task Modificar(MaterialDto dto)
        {
            using (var context = new DataContext())
            {
                var material = context.Materiales.FirstOrDefault(x => x.Id == dto.Id);
                material = _mapper.Map<Dominio.Entidades.Material>(dto);
                await _materialRepositorio.Update(material);
            }
        }
    }
}
