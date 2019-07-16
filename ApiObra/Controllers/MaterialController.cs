using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Material;
using GestionObra.Interfaces.Material.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialRepositorio _materialRepositorio;
        private IMapper _mapper;

        public MaterialController(IMaterialRepositorio materialRepositorio)
        {
            _materialRepositorio = materialRepositorio;
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
            var materiales = await _materialRepositorio.ObtenerTodos();
            if (materiales == null)
            {
                return NotFound();
            }

            return Ok(materiales);
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
            var materiales = await _materialRepositorio.ObtenerPorFiltro(cadena);

            if (materiales == null)
            {
                return NotFound();
            }
            return Ok(materiales);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var materiales = await _materialRepositorio.ObtenerPorId(id);
            if (materiales == null)
            {
                return NotFound();
            }

            return Ok(materiales);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _materialRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, MaterialModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var material = _mapper.Map<MaterialDto>(model);
            material.Id = id;
            await _materialRepositorio.Modificar(material);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(MaterialModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var material = _mapper.Map<MaterialDto>(model);
            await _materialRepositorio.Insertar(material);
            return Ok(model);
        }
    }
}