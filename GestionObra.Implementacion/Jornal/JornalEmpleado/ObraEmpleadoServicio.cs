using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Categoria.DTOs;
using GestionObra.Interfaces.Empleado.DTOs;
using GestionObra.Interfaces.Jornal;
using GestionObra.Interfaces.Jornal.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.Jornal.JornalEmpleado
{
    public class ObraEmpleadoServicio : IObraEmpleadoServicio
    {
        private IRepositorio<Dominio.Entidades.ObraEmpleado> _jornalEmpleadoRepositorio;
        private readonly IMapper _mapper;
        public ObraEmpleadoServicio(IRepositorio<Dominio.Entidades.ObraEmpleado> jornalEmpleadoRepositorio)
        {
            _jornalEmpleadoRepositorio = jornalEmpleadoRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(ObraEmpleadoDto dto)
        {
            using (var context = new DataContext())
            {
                var jornalEmpleado = _mapper.Map<Dominio.Entidades.ObraEmpleado>(dto);
                await _jornalEmpleadoRepositorio.Create(jornalEmpleado);
            }
        }
        public async Task<IEnumerable<EmpleadoDto>> ObtenerPorObra(long id)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.ObraEmpleado, bool>> exp = x => true;
                exp = exp.And(x => x.ObraId == id);
                var jornalEmpleados = await _jornalEmpleadoRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.ObraId), x => x.Include(y => y.Empleado).Include(y => y.Empleado.Categoria).Include(y => y.Obra), true);
                var a = jornalEmpleados.Select(x => new EmpleadoDto
                {
                    Id = x.Empleado.Id,
                    Nombre = x.Empleado.Nombre,
                    Apellido = x.Empleado.Apellido,
                    CategoriaId = x.Empleado.CategoriaId,
                    Categoria =_mapper.Map<CategoriaDto>(x.Empleado.Categoria),
                    Celular = x.Empleado.Celular,
                    Telefono = x.Empleado.Telefono,
                    Dni = x.Empleado.Dni,
                    CUIT = x.Empleado.CUIT,
                    FechaIncio = x.Empleado.FechaIncio,
                    FechaNacimiento = x.Empleado.FechaNacimiento,
                    Legajo = x.Empleado.Legajo,
                    EstaEliminado = x.Empleado.EstaEliminado,

                }).ToList();
                return a;
            }
        }

        public async Task<IEnumerable<ObraEmpleadoDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.ObraEmpleado, bool>> exp = x => true;
                exp = exp.And(x => x.Empleado.Apellido.Contains(cadena));
                var jornalEmpleados = await _jornalEmpleadoRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.ObraId), x => x.Include(y => y.Empleado).Include(y => y.Obra), true);
                return _mapper.Map<IEnumerable<ObraEmpleadoDto>>(jornalEmpleados);
            }
        }

        public async Task<ObraEmpleadoDto> ObtenerPorObraEmpleado(long obraId,long empleadoId)
        {
            using (var context = new DataContext())
            {
                return _mapper.Map<ObraEmpleadoDto>( await context.ObraEmpleados.FirstOrDefaultAsync(x => x.ObraId ==obraId && x.EmpleadoId == empleadoId));
            }
        }
        public async Task<ObraEmpleadoDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var jornalEmpleado = await _jornalEmpleadoRepositorio.GetById(id, x => x.Include(y => y.Empleado).Include(y => y.Obra), true);
                if (jornalEmpleado == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<ObraEmpleadoDto>(jornalEmpleado);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var jornalEmpleado = context.ObraEmpleados.FirstOrDefault(x => x.Id == id);
                await _jornalEmpleadoRepositorio.Delete(jornalEmpleado);
            }
        }

        public async Task Modificar(ObraEmpleadoDto dto)
        {
            using (var context = new DataContext())
            {
                var jornalEmpleado = context.ObraEmpleados.FirstOrDefault(x => x.Id == dto.Id);
                jornalEmpleado.ObraId = dto.ObraId;
                jornalEmpleado.EmpleadoId = dto.EmpleadoId;
                await _jornalEmpleadoRepositorio.Update(jornalEmpleado);
            }
        }

        public async Task<IEnumerable<ObraEmpleadoDto>> ObtenerTodos()
        {
            var jornalEmpleado = await _jornalEmpleadoRepositorio.GetAll(x => x.OrderBy(y => y.ObraId), x => x.Include(y => y.Empleado).Include(y => y.Obra), true);
            return _mapper.Map<IEnumerable<ObraEmpleadoDto>>(jornalEmpleado);
        }
    }
}
