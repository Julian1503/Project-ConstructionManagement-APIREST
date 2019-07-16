using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Precio;
using GestionObra.Interfaces.Precio.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PrecioController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IPrecioRepositorio _precioRepositorio;

        public PrecioController(IPrecioRepositorio precioRepositorio)
        {
            _precioRepositorio = precioRepositorio;
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
            var precios = await _precioRepositorio.ObtenerTodos();
            if (precios == null)
            {
                return NotFound();
            }

            return Ok(precios);
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
            var precios = await _precioRepositorio.ObtenerPoFiltro(cadena);

            if (precios == null)
            {
                return NotFound();
            }
            return Ok(precios);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var precios = await _precioRepositorio.ObtenerPorId(id);
            if (precios == null)
            {
                return NotFound();
            }

            return Ok(precios);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _precioRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, PrecioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var precio = _mapper.Map<PrecioDto>(model);
            precio.Id = id;
            await _precioRepositorio.Modificar(precio);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(PrecioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var precio = _mapper.Map<PrecioDto>(model);
            await _precioRepositorio.Insertar(precio);
            return Ok(model);
        }
    }
}