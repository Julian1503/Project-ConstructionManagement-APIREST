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
using GestionObra.Interfaces.Persona;
using GestionObra.Interfaces.Persona.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Persona
{
    public class PersonaServicio :IPersonaRepositorio
    {
        private IRepositorio<Dominio.Entidades.Persona> _personaRepositorio;
        private IMapper _mapper;

        public PersonaServicio(IRepositorio<Dominio.Entidades.Persona> personaRepositorio)
        {
            _personaRepositorio = personaRepositorio;
            var config = new MapperConfiguration(x=>x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(PersonaDto dto)
        {
            using (var context = new DataContext())
            {
                var persona = _mapper.Map<Dominio.Entidades.Persona>(dto);
                await _personaRepositorio.Create(persona);
            }
        }

        public async Task<IEnumerable<PersonaDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var personas = await 
                    _personaRepositorio.GetAll(x => x.OrderBy(y => y.Apellido).OrderBy(y => y.Nombre), null, true);
                return _mapper.Map<IEnumerable<PersonaDto>>(personas);
            }
        }

        public async Task<IEnumerable<PersonaDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Persona, bool>> exp = x => true;
                exp = exp.Or(x => x.Apellido.Contains(cadena)).Or(x => x.Nombre.Contains(cadena));
                var personas = await _personaRepositorio.GetByFilter(exp,x=>x.OrderBy(y=>y.Apellido).OrderBy(y=>y.Nombre),null,true);
                return _mapper.Map<IEnumerable<PersonaDto>>(personas);
            }
        }

        public async Task<PersonaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var persona = await _personaRepositorio.GetById(id, null, true);
                if (persona== null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<PersonaDto>(persona);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var persona = context.Personas.FirstOrDefault(x => x.Id == id);
                await _personaRepositorio.Delete(persona);
            }
        }

        public async Task Modificar(PersonaDto dto)
        {
            using (var context = new DataContext())
            {
                var persona = context.Personas.FirstOrDefault(x => x.Id == dto.Id);
                persona.Apellido = dto.Apellido;
                persona.Nombre = dto.Nombre;
                persona.Celular = dto.Celular;
                persona.Email = dto.Email;
                persona.Dni = dto.Dni;
                persona.Sexo = dto.Sexo;
                persona.Telefono = dto.Telefono;
                persona.FechaNacimiento = dto.FechaNacimiento;
                await _personaRepositorio.Update(persona);
            }
        }
    }
}
