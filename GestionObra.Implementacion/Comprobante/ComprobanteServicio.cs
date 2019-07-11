using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Comprobante;
using GestionObra.Interfaces.Comprobante.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Comprobante
{
    public class ComprobanteServicio : IComprobanteServicio
    {
        private readonly IRepositorio<Dominio.Entidades.Comprobante> _comprobanteRepositorio;
        private IMapper _mapper;
        public ComprobanteServicio(IRepositorio<Dominio.Entidades.Comprobante> comprobanteRepositorio)
        {
            _comprobanteRepositorio = comprobanteRepositorio;
            var config = new MapperConfiguration(x=>x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(ComprobanteDto dto)
        {
            using (var context = new DataContext())
            {
                var comprobanteNuevo = _mapper.Map<Dominio.Entidades.Comprobante>(dto);
                await _comprobanteRepositorio.Create(comprobanteNuevo);
            }
        }

        public async Task<IEnumerable<ComprobanteDto>> Obtener(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Comprobante, bool>> exp = x => true;
                exp = exp.And(x => x.Detalle.Contains(cadena));
                var comprobantes = await 
                    _comprobanteRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.NumeroComprobante),x=>x.Include(y=>y.Usuario).Include(y=>y.Empresa).Include(y=>y.Rubro) ,true);
                return _mapper.Map<IEnumerable<ComprobanteDto>>(comprobantes);
            }
        }

        public async Task<ComprobanteDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var comprobanteById = await _comprobanteRepositorio.GetById(id,enableTracking: true);
                if (comprobanteById == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<ComprobanteDto>(comprobanteById);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var comprobanteBorrar = context.Comprobantes.FirstOrDefault(x => x.Id == id);
                if(comprobanteBorrar!=null)
                await _comprobanteRepositorio.Delete(comprobanteBorrar);
            }
        }

        public async Task Modificar(ComprobanteDto dto)
        {
            using (var context = new DataContext())
            {
                var comprobanteModificar = context.Comprobantes.FirstOrDefault(x => x.Id == dto.Id);
                comprobanteModificar = _mapper.Map<Dominio.Entidades.Comprobante>(dto);
                await _comprobanteRepositorio.Update(comprobanteModificar);
            }
        }
    }
}
