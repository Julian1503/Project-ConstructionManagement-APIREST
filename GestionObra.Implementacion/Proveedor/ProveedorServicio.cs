using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Proveedor;
using GestionObra.Interfaces.Proveedor.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.Proveedor
{
    public class ProveedorServicio : IProveedorServicio
    {
        private readonly IRepositorio<Dominio.Entidades.Proveedor> _proveedorRepositorio;
        private IMapper _mapper;
        public ProveedorServicio(IRepositorio<Dominio.Entidades.Proveedor> proveedorRepositorio)
        {
            _proveedorRepositorio = proveedorRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Borrar(long id)
        {
           using(var context = new DataContext())
            {
                var proveedorBorrar = context.Proveedores.FirstOrDefault(x => x.Id == id);
                if (proveedorBorrar != null)
                    await _proveedorRepositorio.Delete(proveedorBorrar);
            }
        }

        public async Task Insertar(ProveedorDto dto)
        {
            var proveedorNuevo = _mapper.Map<Dominio.Entidades.Proveedor>(dto);
            await _proveedorRepositorio.Create(proveedorNuevo);
        }

        public async Task Modificar(ProveedorDto dto)
        {
            using (var context = new DataContext())
            {
                var proveedorModificar = context.Proveedores.FirstOrDefault(x => x.Id == dto.Id);
                proveedorModificar.CondicionIvaId = dto.CondicionIvaId;
                proveedorModificar.NombreFantasia = dto.NombreFantasia;
                proveedorModificar.Cuit = dto.Cuit;
                proveedorModificar.RazonSocial = dto.RazonSocial;
                proveedorModificar.Telefono = dto.Telefono;
                proveedorModificar.Contacto = dto.Contacto;

                await _proveedorRepositorio.Update(proveedorModificar);
            }
        }

        public async Task<IEnumerable<ProveedorDto>> Obtener(string cadena)
        {
            Expression<Func<Dominio.Entidades.Proveedor, bool>> exp = x => true;
            exp = exp.And(x => x.RazonSocial.Contains(cadena));
            var proveedors = await
                _proveedorRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.RazonSocial), x=>x.Include(y=>y.CondicionIva), true);
            return _mapper.Map<IEnumerable<ProveedorDto>>(proveedors);
        }

        public async Task<ProveedorDto> ObtenerPorId(long id)
        {
            var proveedorById = await _proveedorRepositorio.GetById(id, x => x.Include(y => y.CondicionIva),enableTracking: true);
            if (proveedorById == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<ProveedorDto>(proveedorById);
            }
        }

        public async Task<IEnumerable<ProveedorDto>> ObtenerTodos()
        {
            var proveedor = await _proveedorRepositorio.GetAll(x => x.OrderBy(y => y.RazonSocial), x => x.Include(y => y.CondicionIva), true);
            return _mapper.Map<IEnumerable<ProveedorDto>>(proveedor);
        }
    }
}
