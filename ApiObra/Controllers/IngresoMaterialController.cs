using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.IngresoMaterial;
using GestionObra.Interfaces.IngresoMaterial.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class IngresoMaterialController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IIngresoMaterialRepositorio _ingresoMaterialRepositorio;

        public IngresoMaterialController(IIngresoMaterialRepositorio ingresoMaterialRepositorio)
        {
            _ingresoMaterialRepositorio = ingresoMaterialRepositorio;
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
            var ingresosMaterial = await _ingresoMaterialRepositorio.ObtenerTodos();
            if (ingresosMaterial == null)
            {
                return NotFound();
            }

            return Ok(ingresosMaterial);
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
            var ingresosMaterial = await _ingresoMaterialRepositorio.ObtenerPorFiltro(cadena);

            if (ingresosMaterial == null)
            {
                return NotFound();
            }
            return Ok(ingresosMaterial);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ingresosMaterial = await _ingresoMaterialRepositorio.ObtenerPorId(id);
            if (ingresosMaterial == null)
            {
                return NotFound();
            }

            return Ok(ingresosMaterial);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _ingresoMaterialRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, IngresoMaterialModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ingresoMaterial = _mapper.Map<IngresoMaterialDto>(model);
            ingresoMaterial.Id = id;
            await _ingresoMaterialRepositorio.Modificar(ingresoMaterial);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(IngresoMaterialModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ingresoMaterial = _mapper.Map<IngresoMaterialDto>(model);
            await _ingresoMaterialRepositorio.Insertar(ingresoMaterial);
            return Ok(model);
        }
    }
}