using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Categoria;
using GestionObra.Interfaces.Categoria.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.Categoria
{
    public class CategoriaServicio : ICategoriaServicio
    {
        private IRepositorio<Dominio.Entidades.Categoria> _categoriaRepositorio;
        private IMapper _mapper;
        public CategoriaServicio(IRepositorio<Dominio.Entidades.Categoria> categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(CategoriaDto dto)
        {
            using (var context = new DataContext())
            {
                var categoria = _mapper.Map<Dominio.Entidades.Categoria>(dto);
                await _categoriaRepositorio.Create(categoria);
            }
        }

        public async Task<IEnumerable<CategoriaDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Categoria, bool>> exp = x => true;
                exp = exp.And(x => x.Descripcion.Contains(cadena));
                var categorias = await _categoriaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Descripcion),null, true);
                return _mapper.Map<IEnumerable<CategoriaDto>>(categorias);
            }
        }

        public async Task<CategoriaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var categoria = await _categoriaRepositorio.GetById(id, null, true);
                if (categoria == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<CategoriaDto>(categoria);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var categoria = context.Categorias.FirstOrDefault(x => x.Id == id);
                await _categoriaRepositorio.Delete(categoria);
            }
        }

        public async Task Modificar(CategoriaDto dto)
        {
            using (var context = new DataContext())
            {
                var categoria = context.Categorias.FirstOrDefault(x => x.Id == dto.Id);
                categoria.Descripcion = dto.Descripcion;
                await _categoriaRepositorio.Update(categoria);
            }
        }

        public async Task<IEnumerable<CategoriaDto>> ObtenerTodos()
        {
            var categoria = await _categoriaRepositorio.GetAll(x => x.OrderBy(y => y.Descripcion), null, true);
            return _mapper.Map<IEnumerable<CategoriaDto>>(categoria);
        }
    }
}
