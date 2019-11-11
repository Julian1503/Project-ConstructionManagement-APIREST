using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.SalarioMinimo;
using GestionObra.Interfaces.SalarioMinimo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.SalarioMinimo
{
   public class SalarioMinimoServicio : ISalarioMinimoServicio
    {
        private IRepositorio<Dominio.Entidades.SalarioMinimo> _salarioMinimoRepositorio;
        private IMapper _mapper;
        public SalarioMinimoServicio(IRepositorio<Dominio.Entidades.SalarioMinimo> salarioMinimoRepositorio)
        {
            _salarioMinimoRepositorio = salarioMinimoRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(SalarioMinimoDto dto)
        {
            using (var context = new DataContext())
            {
                var salarioMinimo = _mapper.Map<Dominio.Entidades.SalarioMinimo>(dto);
                await _salarioMinimoRepositorio.Create(salarioMinimo);
            }
        }

        public async Task<IEnumerable<SalarioMinimoDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.SalarioMinimo, bool>> exp = x => true;
                exp = exp.And(x => x.FechaActualizacion.ToString().Contains(cadena));
                var salarioMinimos = await _salarioMinimoRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.FechaActualizacion), null, true);
                return _mapper.Map<IEnumerable<SalarioMinimoDto>>(salarioMinimos);
            }
        }

        public async Task<SalarioMinimoDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var salarioMinimo = await _salarioMinimoRepositorio.GetById(id, null, true);
                if (salarioMinimo == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<SalarioMinimoDto>(salarioMinimo);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var salarioMinimo = context.SalarioMinimos.FirstOrDefault(x => x.Id == id);
                await _salarioMinimoRepositorio.Delete(salarioMinimo);
            }
        }

        public async Task Modificar(SalarioMinimoDto dto)
        {
            using (var context = new DataContext())
            {
                var salarioMinimo = context.SalarioMinimos.FirstOrDefault(x => x.Id == dto.Id);
                salarioMinimo.FechaActualizacion = dto.FechaActualizacion;
                salarioMinimo.Salario = dto.Salario;
                await _salarioMinimoRepositorio.Update(salarioMinimo);
            }
        }

        public async Task<IEnumerable<SalarioMinimoDto>> ObtenerTodos()
        {
            var salarioMinimo = await _salarioMinimoRepositorio.GetAll(x => x.OrderBy(y => y.FechaActualizacion), null, true);
            return _mapper.Map<IEnumerable<SalarioMinimoDto>>(salarioMinimo);
        }
    }
}
