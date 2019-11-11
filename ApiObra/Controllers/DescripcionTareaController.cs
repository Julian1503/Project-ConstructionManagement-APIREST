using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Banco.DTOs;
using GestionObra.Interfaces.DescripcionTarea;
using GestionObra.Interfaces.DescripcionTarea.DTOs;
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
    public class DescripcionTareaController : ControllerBase
    {
        private readonly IDescripcionTareaRepositorio _descripcionTareaRepositorio;
        private IMapper _mapper;

        public DescripcionTareaController(IDescripcionTareaRepositorio descripcionTareaRepositorio)
        {
            _descripcionTareaRepositorio = descripcionTareaRepositorio;
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
            var descripcionesTarea = await _descripcionTareaRepositorio.ObtenerTodos();
            if (descripcionesTarea == null)
            {
                return NotFound();
            }

            return Ok(descripcionesTarea);
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
            var descripcionesTarea = await _descripcionTareaRepositorio.ObtenerPorFiltro(cadena);

            if (descripcionesTarea == null)
            {
                return NotFound();
            }
            return Ok(descripcionesTarea);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var descripcionesTarea = await _descripcionTareaRepositorio.ObtenerPorId(id);
            if (descripcionesTarea == null)
            {
                return NotFound();
            }

            return Ok(descripcionesTarea);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _descripcionTareaRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, DescripcionTareaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var descripcionTarea = _mapper.Map<DescripcionTareaDto>(model);
            descripcionTarea.Id = id;
            await _descripcionTareaRepositorio.Modificar(descripcionTarea);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(DescripcionTareaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var descripcionTarea = _mapper.Map<DescripcionTareaDto>(model);
            await _descripcionTareaRepositorio.Insertar(descripcionTarea);
            return Ok(model);
        }
    }
}