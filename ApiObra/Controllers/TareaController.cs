using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Tarea;
using GestionObra.Interfaces.Tarea.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [Route("GetByFilter/{cadena}")]
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

        [HttpGet("GetByObra/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByObra(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tareas = await _tareaRepositorio.ObtenerPorObra(id);
            if (tareas == null)
            {
                return NotFound();
            }

            return Ok(tareas);
        }
        [HttpGet("DuracionObra/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> DuracionObra(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tareas = await _tareaRepositorio.ObtenerPorObra(id);
            var result = tareas.Sum(x => x.Duracion.TotalMinutes);
            var ho = tareas.Where(x => x.Estado == GestionObra.Constantes.EstadoTarea.Finalizada).Sum(x => x.Duracion.TotalMinutes);
            if (tareas == null)
            {
                return NotFound();
            }

            if (ho == 0)
            {
                return Ok(0);
            }
            else
            {
                return Ok((ho/ result)*100);
            }
        }
        [HttpGet("CantidadCompletadas/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Completadas(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tareas = await _tareaRepositorio.ObtenerPorObra(id);
            var ho = tareas.Where(x => x.Estado == GestionObra.Constantes.EstadoTarea.Finalizada).Count();
            if (tareas == null)
            {
                return NotFound();
            }
             return Ok(ho);
        }

        [HttpGet("CantidadFaltantes/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Faltantes(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tareas = await _tareaRepositorio.ObtenerPorObra(id);
            var ho = tareas.Where(x => x.Estado != GestionObra.Constantes.EstadoTarea.Finalizada).Count();
            if (tareas == null)
            {
                return NotFound();
            }
            return Ok(ho);
        }

        [HttpGet("TiempoEmpleado/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> TiempoEmpleado(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tareas = await _tareaRepositorio.ObtenerPorObra(id);
            var ho = tareas.Where(x => x.Estado == GestionObra.Constantes.EstadoTarea.Finalizada).Sum(x=>x.TiempoEmpleado.TotalHours);
            if (tareas == null)
            {
                return NotFound();
            }
            return Ok(ho);
        }

        [HttpGet("TiempoEstimado/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> TiempoEstimado(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tareas = await _tareaRepositorio.ObtenerPorObra(id);
            var ho = tareas.Sum(x => x.Duracion.TotalHours);
            if (tareas == null)
            {
                return NotFound();
            }
            return Ok(ho);
        }
         [HttpGet("GetById/{id:int}")]
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