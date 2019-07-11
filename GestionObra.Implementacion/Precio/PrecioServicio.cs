using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Precio;
using GestionObra.Interfaces.Precio.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Precio
{
    public class PrecioServicio : IPrecioRepositorio
    {
        private IRepositorio<Dominio.Entidades.Precio> _precioRepositorio;
        private IMapper _mapper;

        public PrecioServicio(IRepositorio<Dominio.Entidades.Precio>  precioRepositorio)
        {
            _precioRepositorio = precioRepositorio;
            var config = new MapperConfiguration(x=>x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(PrecioDto dto)
        {
            using (var context = new DataContext())
            {
                var persona = _mapper.Map<Dominio.Entidades.Precio>(dto);
                await _precioRepositorio.Create(persona);
            }
        }

        public async Task<IEnumerable<PrecioDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var precios = await _precioRepositorio.GetAll(x => x.OrderByDescending(y => y.FechaActualizacion),
                    x => x.Include(y => y.Material).Include(y => y.Material).Include(y => y.Usuario), true);
                return _mapper.Map<IEnumerable<PrecioDto>>(precios);
            }
        }

        public async Task<PrecioDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var precio = await _precioRepositorio.GetById(id,
                    x => x.Include(y => y.Material).Include(y => y.Material).Include(y => y.Usuario), true);
                return _mapper.Map<PrecioDto>(precio);
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var precio = context.Precios.FirstOrDefault(x => x.Id == id);
                await _precioRepositorio.Delete(precio);
            }
        }

        public async Task Modificar(PrecioDto dto)
        {
            using (var context = new DataContext())
            {
                var precio = context.Precios.FirstOrDefault(x => x.Id == dto.Id);
                precio = _mapper.Map<Dominio.Entidades.Precio>(dto);
                await _precioRepositorio.Update(precio);
            }
        }
    }
}
