using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Empleado;
using GestionObra.Interfaces.Empleado.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.Empleado
{
   public class EmpleadoServicio : IEmpleadoServicio
    {
        private IMapper _mapper;
        private IRepositorio<Dominio.Entidades.Empleado> _empleadoRepositorio;
        public EmpleadoServicio(IRepositorio<Dominio.Entidades.Empleado> empleadoRepositorio)
        {
            _empleadoRepositorio = empleadoRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(EmpleadoDto dto)
        {
            using (var context = new DataContext())
            {
                var empleado = _mapper.Map<Dominio.Entidades.Empleado>(dto);
                await _empleadoRepositorio.Create(empleado);
            }
        }

        public async Task<IEnumerable<EmpleadoDto>> ObtenerConFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Empleado, bool>> exp = x => true;
                exp = exp.And(x => x.Nombre.Contains(cadena) || x.Apellido.Contains(cadena) || x.Legajo.ToString().Contains(cadena));
                var empleados = await
                    _empleadoRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Apellido), x => x.Include(y => y.Categoria), true);
                return _mapper.Map<List<EmpleadoDto>>(empleados);
            }
        }

        public async Task<IEnumerable<EmpleadoDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var empleados = await _empleadoRepositorio.GetAll(x => x.OrderBy(y => y.Apellido),x=>x.Include(y=>y.Categoria) , true);
                return _mapper.Map<List<EmpleadoDto>>(empleados);
            }
        }

        public async Task<EmpleadoDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var empleado = await _empleadoRepositorio.GetById(id, x => x.Include(y => y.Categoria), true);
                if (empleado == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<EmpleadoDto>(empleado);

                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var empleado = context.Empleados.FirstOrDefault(x => x.Id == id);
                await _empleadoRepositorio.Delete(empleado);
            }
        }

        public async Task Modificar(EmpleadoDto dto)
        {
            using (var context = new DataContext())
            {
                var empleado = context.Empleados.FirstOrDefault(x => x.Id == dto.Id);
               empleado.Legajo = dto.Legajo;
               empleado.Apellido = dto.Apellido;
               empleado.CUIT = dto.CUIT;
               empleado.CategoriaId= dto.CategoriaId;
               empleado.FechaIncio= dto.FechaIncio;
                empleado.Nombre = dto.Nombre;
               empleado.Celular = dto.Celular;
               empleado.Path = dto.Path;
                empleado.Dni = dto.Dni;
               empleado.Telefono = dto.Telefono;
               empleado.FechaNacimiento = dto.FechaNacimiento;
                await _empleadoRepositorio.Update(empleado);
            }
        }
    }
}
