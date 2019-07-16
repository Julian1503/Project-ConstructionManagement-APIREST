using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Tarea;
using GestionObra.Interfaces.Tarea.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TareaController : ControllerBase
    {
        private IMapper _mapper;
        private readonly ITareaRepositorio _tareaRepositorio;

        public TareaController(ITareaRepositorio tareaRepositorio)
        {
            _tareaRepositorio = tareaRepositorio;
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
            var tareas = await _tareaRepositorio.ObtenerTodos();
            if (tareas == null)
            {
                return NotFound();
            }

            return Ok(tareas);
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
            var tareas = await _tareaRepositorio.ObtenerPorFiltro(cadena);

            if (tareas == null)
            {
                return NotFound();
            }
            return Ok(tareas);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tareas = await _tareaRepositorio.ObtenerPorId(id);
            if (tareas == null)
            {
                return NotFound();
            }

            return Ok(tareas);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _tareaRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, TareaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tarea = _mapper.Map<TareaDto>(model);
            tarea.Id = id;
            await _tareaRepositorio.Modificar(tarea);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(TareaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tarea = _mapper.Map<TareaDto>(model);
            await _tareaRepositorio.Insertar(tarea);
            return Ok(model);
        }
    }
}