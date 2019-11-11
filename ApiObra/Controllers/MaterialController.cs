using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Material;
using GestionObra.Interfaces.Material.DTOs;
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
        [Route("GetByFilter/{cadena}")]
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
        [HttpGet]
        [Route("GetMateriales")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Materiales(string cadena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var materiales = await _materialRepositorio.ObtenerMateriales();

            if (materiales == null)
            {
                return NotFound();
            }
            return Ok(materiales);

        }
        [HttpGet]
        [Route("GetInsumos")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Insumos( )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var materiales = await _materialRepositorio.ObtenerTodosMenosMaterial();

            if (materiales == null)
            {
                return NotFound();
            }
            return Ok(materiales);

        }
        [HttpGet]
        [Route("GetMaquinarias")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Maquinaria(string cadena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var materiales = await _materialRepositorio.ObtenerMaquinarias();

            if (materiales == null)
            {
                return NotFound();
            }
            return Ok(materiales);

        }

        [HttpGet]
        [Route("GetHerramientas")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Herramientas(string cadena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var materiales = await _materialRepositorio.ObtenerHerramientas();

            if (materiales == null)
            {
                return NotFound();
            }
            return Ok(materiales);

        }

        [HttpGet]
        [Route("GetVehiculos")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Vehiculos(string cadena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var materiales = await _materialRepositorio.ObtenerVehiculos();

            if (materiales == null)
            {
                return NotFound();
            }
            return Ok(materiales);
        }

        [HttpGet("GetById/{id:int}")]
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