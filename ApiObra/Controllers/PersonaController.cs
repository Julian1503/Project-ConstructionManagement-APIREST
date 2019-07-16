using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Persona;
using GestionObra.Interfaces.Persona.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PersonaController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IPersonaRepositorio _personaRepositorio;

        public PersonaController(IPersonaRepositorio personaRepositorio)
        {
            _personaRepositorio = personaRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<AutoMapper.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        [HttpGet]
        [Route("GetAll")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var personas = await _personaRepositorio.ObtenerTodos();
            if (personas == null)
            {
                return NotFound();
            }

            return Ok(personas);
        }

        [HttpGet]
        [Route("GetByFilter")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByFilter(string cadena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var personas = await _personaRepositorio.ObtenerPorFiltro(cadena);

            if (personas == null)
            {
                return NotFound();
            }
            return Ok(personas);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var personas = await _personaRepositorio.ObtenerPorId(id);
            if (personas == null)
            {
                return NotFound();
            }

            return Ok(personas);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _personaRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, PersonaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var persona = _mapper.Map<PersonaDto>(model);
            persona.Id = id;
            await _personaRepositorio.Modificar(persona);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(PersonaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var persona = _mapper.Map<PersonaDto>(model);
            await _personaRepositorio.Insertar(persona);
            return Ok(model);
        }
    }
}