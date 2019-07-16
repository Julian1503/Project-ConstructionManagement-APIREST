using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.CondicionIva;
using GestionObra.Interfaces.CondicionIva.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CondicionIvaController : ControllerBase
    {
        private readonly ICondicionIvaRepositorio _condicionIvaRepositorio;
        private IMapper _mapper;

        public CondicionIvaController(ICondicionIvaRepositorio condicionIvaRepositorio)
        {
            _condicionIvaRepositorio = condicionIvaRepositorio;
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
            var condicionesIva = await _condicionIvaRepositorio.ObtenerTodos();
            if (condicionesIva == null)
            {
                return NotFound();
            }

            return Ok(condicionesIva);
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
            var condicionesIva = await _condicionIvaRepositorio.ObtenerPorFiltro(cadena);

            if (condicionesIva == null)
            {
                return NotFound();
            }
            return Ok(condicionesIva);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var condicionesIva = await _condicionIvaRepositorio.ObtenerPorId(id);
            if (condicionesIva == null)
            {
                return NotFound();
            }

            return Ok(condicionesIva);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _condicionIvaRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, CondicionIvaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var condicionIva = _mapper.Map<CondicionIvaDto>(model);
            condicionIva.Id = id;
            await _condicionIvaRepositorio.Modificar(condicionIva);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(CondicionIvaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var condicionIva = _mapper.Map<CondicionIvaDto>(model);
            await _condicionIvaRepositorio.Insertar(condicionIva);
            return Ok(model);
        }
    }
}