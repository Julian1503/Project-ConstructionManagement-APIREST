using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Obra;
using GestionObra.Interfaces.Obra.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ObraController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IObraRepositorio _obraRepositorio;

        public ObraController(IObraRepositorio obraRepositorio)
        {
            _obraRepositorio = obraRepositorio;
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
            var obras = await _obraRepositorio.ObtenerTodos();
            if (obras == null)
            {
                return NotFound();
            }

            return Ok(obras);
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
            var obras = await _obraRepositorio.ObtenerPorFiltro(cadena);

            if (obras == null)
            {
                return NotFound();
            }
            return Ok(obras);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var obras = await _obraRepositorio.ObtenerPorId(id);
            if (obras == null)
            {
                return NotFound();
            }

            return Ok(obras);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _obraRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, ObraModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obra = _mapper.Map<ObraDto>(model);
            obra.Id = id;
            await _obraRepositorio.Modificar(obra);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(ObraModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var obra = _mapper.Map<ObraDto>(model);
            await _obraRepositorio.Insertar(obra);
            return Ok(model);
        }
    }
}