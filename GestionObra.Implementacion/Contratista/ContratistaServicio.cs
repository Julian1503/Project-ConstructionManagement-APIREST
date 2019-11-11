using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Contratista;
using GestionObra.Interfaces.Contratista.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.Contratista
{
    public class ContratistaServicio : IContratistaServicio
    {
        private IRepositorio<Dominio.Entidades.Contratista> _contratistaRepositorio;
        private IMapper _mapper;
        public ContratistaServicio(IRepositorio<Dominio.Entidades.Contratista> contratistaRepositorio)
        {
            _contratistaRepositorio = contratistaRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(ContratistaDto dto)
        {
            using (var context = new DataContext())
            {
                var contratista = _mapper.Map<Dominio.Entidades.Contratista>(dto);
                await _contratistaRepositorio.Create(contratista);
            }
        }

        public async Task<IEnumerable<ContratistaDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Contratista, bool>> exp = x => true;
                exp = exp.And(x => x.RazonSocial.Contains(cadena));
                var contratistas = await _contratistaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.RazonSocial), null, true);
                return _mapper.Map<IEnumerable<ContratistaDto>>(contratistas);
            }
        }

        public async Task<ContratistaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var contratista = await _contratistaRepositorio.GetById(id, null, true);
                if (contratista == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<ContratistaDto>(contratista);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var contratista = context.Contratistas.FirstOrDefault(x => x.Id == id);
                await _contratistaRepositorio.Delete(contratista);
            }
        }

        public async Task Modificar(ContratistaDto dto)
        {
            using (var context = new DataContext())
            {
                var contratista = context.Contratistas.FirstOrDefault(x => x.Id == dto.Id);
                contratista.NombreFantasia = dto.NombreFantasia;
                contratista.Cuit = dto.Cuit;
                contratista.Mail = dto.Mail;
                contratista.Path = dto.Path;
                contratista.RazonSocial = dto.RazonSocial;
                contratista.Sucursal = dto.Sucursal;
                contratista.Telefono = dto.Telefono;
                await _contratistaRepositorio.Update(contratista);
            }
        }

        public async Task<IEnumerable<ContratistaDto>> ObtenerTodos()
        {
            var contratista = await _contratistaRepositorio.GetAll(x => x.OrderBy(y => y.RazonSocial), null, true);
            return _mapper.Map<IEnumerable<ContratistaDto>>(contratista);
        }
    }
}
