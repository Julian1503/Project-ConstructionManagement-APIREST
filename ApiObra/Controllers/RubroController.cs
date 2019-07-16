using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Rubro;
using GestionObra.Interfaces.Rubro.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RubroController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IRubroRepositorio _rubroRepositorio;

        public RubroController(IRubroRepositorio rubroRepositorio)
        {
            _rubroRepositorio = rubroRepositorio;
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
            var rubros = await _rubroRepositorio.ObtenerTodos();
            if (rubros == null)
            {
                return NotFound();
            }

            return Ok(rubros);
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
            var rubros = await _rubroRepositorio.ObtenerPorFiltro(cadena);

            if (rubros == null)
            {
                return NotFound();
            }
            return Ok(rubros);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var rubros = await _rubroRepositorio.ObtenerPorId(id);
            if (rubros == null)
            {
                return NotFound();
            }

            return Ok(rubros);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _rubroRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, RubroModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rubro = _mapper.Map<RubroDto>(model);
            rubro.Id = id;
            await _rubroRepositorio.Modificar(rubro);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(RubroModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var rubro = _mapper.Map<RubroDto>(model);
            await _rubroRepositorio.Insertar(rubro);
            return Ok(model);
        }
    }
}