using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Gasto;
using GestionObra.Interfaces.Gasto.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class GastoController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IGastoRepositorio _gastoRepositorio;

        public GastoController(IGastoRepositorio gastoRepositorio)
        {
            _gastoRepositorio = gastoRepositorio;
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
            var gastos = await _gastoRepositorio.ObtenerTodos();
            if (gastos == null)
            {
                return NotFound();
            }

            return Ok(gastos);
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
            var gastos = await _gastoRepositorio.ObtenerConFiltro(cadena);

            if (gastos == null)
            {
                return NotFound();
            }
            return Ok(gastos);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var gastos = await _gastoRepositorio.ObtenerPorId(id);
            if (gastos == null)
            {
                return NotFound();
            }

            return Ok(gastos);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _gastoRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, GastoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gasto = _mapper.Map<GastoDto>(model);
            gasto.Id = id;
            await _gastoRepositorio.Modificar(gasto);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(GastoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var gasto = _mapper.Map<GastoDto>(model);
            await _gastoRepositorio.Insertar(gasto);
            return Ok(model);
        }
    }
}