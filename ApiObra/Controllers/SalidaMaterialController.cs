using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.SalidaMaterial;
using GestionObra.Interfaces.SalidaMaterial.DTOs;
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
    public class SalidaMaterialController : ControllerBase
    {
        private IMapper _mapper;
        private readonly ISalidaMaterialRepositorio _salidaMaterialRepositorio;

        public SalidaMaterialController(ISalidaMaterialRepositorio salidaMaterialRepositorio)
        {
            _salidaMaterialRepositorio = salidaMaterialRepositorio;
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
            var salidaMateriales = await _salidaMaterialRepositorio.ObtenerTodos();
            if (salidaMateriales == null)
            {
                return NotFound();
            }

            return Ok(salidaMateriales);
        }
        [HttpGet("GetByObra/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByObra(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ingresosMaterial = await _salidaMaterialRepositorio.ObtenerPorObra(id);
            if (ingresosMaterial == null)
            {
                return NotFound();
            }

            return Ok(ingresosMaterial);
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
            var salidaMateriales = await _salidaMaterialRepositorio.ObtenerPorFiltro(cadena);

            if (salidaMateriales == null)
            {
                return NotFound();
            }
            return Ok(salidaMateriales);

        }

         [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var salidaMateriales = await _salidaMaterialRepositorio.ObtenerPorId(id);
            if (salidaMateriales == null)
            {
                return NotFound();
            }

            return Ok(salidaMateriales);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _salidaMaterialRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, SalidaMaterialModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salidaMaterial = _mapper.Map<SalidaMaterialDto>(model);
            salidaMaterial.Id = id;
            await _salidaMaterialRepositorio.Modificar(salidaMaterial);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(SalidaMaterialModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var salidaMaterial = _mapper.Map<SalidaMaterialDto>(model);
            await _salidaMaterialRepositorio.Insertar(salidaMaterial);
            return Ok(model);
        }
    }
}