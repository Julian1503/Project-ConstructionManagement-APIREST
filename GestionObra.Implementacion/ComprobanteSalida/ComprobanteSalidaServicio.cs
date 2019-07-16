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
using GestionObra.Interfaces.ComprobanteSalida;
using GestionObra.Interfaces.ComprobanteSalida.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.ComprobanteSalida
{
    public class ComprobanteSalidaServicio : IComprobanteSalidaRepositorio
    {
        private readonly IRepositorio<Dominio.Entidades.ComprobanteSalida> _comprobanteRepositorio;
        private IMapper _mapper;
        public ComprobanteSalidaServicio(IRepositorio<Dominio.Entidades.ComprobanteSalida> comprobanteRepositorio)
        {
            _comprobanteRepositorio = comprobanteRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(ComprobanteSalidaDto dto)
        {
            using (var context = new DataContext())
            {
                var comprobanteNuevo = _mapper.Map<Dominio.Entidades.ComprobanteSalida>(dto);
                await _comprobanteRepositorio.Create(comprobanteNuevo);
            }
        }

        public async Task<IEnumerable<ComprobanteSalidaDto>> Obtener(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.ComprobanteSalida, bool>> exp = x => true;
                exp = exp.And(x => x.Detalle.Contains(cadena));
                var comprobantes = await
                    _comprobanteRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.NumeroComprobante), x => x.Include(y => y.Usuario).Include(y => y.Empresa).Include(y => y.Rubro), true);
                return _mapper.Map<IEnumerable<ComprobanteSalidaDto>>(comprobantes);
            }
        }

        public async Task<ComprobanteSalidaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var comprobanteById = await _comprobanteRepositorio.GetById(id, enableTracking: true);
                if (comprobanteById == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<ComprobanteSalidaDto>(comprobanteById);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var comprobanteBorrar = context.Comprobantes.OfType<Dominio.Entidades.ComprobanteSalida>().FirstOrDefault(x => x.Id == id);
                if (comprobanteBorrar != null)
                    await _comprobanteRepositorio.Delete(comprobanteBorrar);
            }
        }

        public async Task Modificar(ComprobanteSalidaDto dto)
        {
            using (var context = new DataContext())
            {
                var comprobanteModificar = context.Comprobantes.OfType<Dominio.Entidades.ComprobanteSalida>().FirstOrDefault(x => x.Id == dto.Id);
                comprobanteModificar = _mapper.Map<Dominio.Entidades.ComprobanteSalida>(dto);
                await _comprobanteRepositorio.Update(comprobanteModificar);
            }
        }
    }
}
