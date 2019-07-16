using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Zona;
using GestionObra.Interfaces.Zona.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ZonaController : ControllerBase
    {
        private readonly IZonaRepositorio _zonaRepositorio;
        private IMapper _mapper;

        public ZonaController(IZonaRepositorio zonaRepositorio)
        {
            _zonaRepositorio = zonaRepositorio;
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
            var zonas = await _zonaRepositorio.ObtenerTodos();
            if (zonas == null)
            {
                return NotFound();
            }

            return Ok(zonas);
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
            var zonas = await _zonaRepositorio.ObtenerPorFiltro(cadena);

            if (zonas == null)
            {
                return NotFound();
            }
            return Ok(zonas);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var zonas = await _zonaRepositorio.ObtenerPorId(id);
            if (zonas == null)
            {
                return NotFound();
            }

            return Ok(zonas);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _zonaRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, ZonaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var zona = _mapper.Map<ZonaDto>(model);
            zona.Id = id;
            await _zonaRepositorio.Modificar(zona);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(ZonaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var zona = _mapper.Map<ZonaDto>(model);
            await _zonaRepositorio.Insertar(zona);
            return Ok(model);
        }
    }
}