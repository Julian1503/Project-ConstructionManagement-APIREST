using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Causa;
using GestionObra.Interfaces.Causa.DTOs;
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
    public class CausaFaltaController : ControllerBase
    {
        private readonly ICausaFaltaServicio _causaFaltaRepositorio;
        private IMapper _mapper;
        public CausaFaltaController(ICausaFaltaServicio causaFaltaRepositorio)
        {
            _causaFaltaRepositorio = causaFaltaRepositorio;
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
            var causaFaltas = await _causaFaltaRepositorio.ObtenerTodos();
            if (causaFaltas == null)
            {
                return NotFound();
            }

            return Ok(causaFaltas);
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
            var causaFaltas = await _causaFaltaRepositorio.ObtenerPorFiltro(cadena);

            if (causaFaltas == null)
            {
                return NotFound();
            }
            return Ok(causaFaltas);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var causaFaltas = await _causaFaltaRepositorio.ObtenerPorId(id);
            if (causaFaltas == null)
            {
                return NotFound();
            }

            return Ok(causaFaltas);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _causaFaltaRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, CausaFaltaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var causaFalta = _mapper.Map<CausaFaltaDto>(model);
            causaFalta.Id = id;
            await _causaFaltaRepositorio.Modificar(causaFalta);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(CausaFaltaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var causaFalta = _mapper.Map<CausaFaltaDto>(model);
            await _causaFaltaRepositorio.Insertar(causaFalta);
            return Ok(model);
        }
    }
}