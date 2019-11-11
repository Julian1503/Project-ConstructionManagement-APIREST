using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Jornal;
using GestionObra.Interfaces.Jornal.DTOs;
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
    public class JornalMaterialController : ControllerBase
    {
        private readonly IJornalMaterialServicio _jornalMaterialRepositorio;
        private IMapper _mapper;
        public JornalMaterialController(IJornalMaterialServicio jornalMaterialRepositorio)
        {
            _jornalMaterialRepositorio = jornalMaterialRepositorio;
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
            var jornalMaterials = await _jornalMaterialRepositorio.ObtenerTodos();
            if (jornalMaterials == null)
            {
                return NotFound();
            }

            return Ok(jornalMaterials);
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
            var jornalMaterials = await _jornalMaterialRepositorio.ObtenerPorFiltro(cadena);

            if (jornalMaterials == null)
            {
                return NotFound();
            }
            return Ok(jornalMaterials);

        }

        [HttpGet]
        [Route("GetByObra/{id:long}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByObra (long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jornalMaterials = await _jornalMaterialRepositorio.ObtenerPorObra(id);

            if (jornalMaterials == null)
            {
                return NotFound();
            }
            return Ok(jornalMaterials);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jornalMaterials = await _jornalMaterialRepositorio.ObtenerPorId(id);
            if (jornalMaterials == null)
            {
                return NotFound();
            }

            return Ok(jornalMaterials);
        }
        [HttpGet("GetByJornal/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByJornal(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jornalMaterials = await _jornalMaterialRepositorio.ObtenerPorJornal(id);
            if (jornalMaterials == null)
            {
                return NotFound();
            }

            return Ok(jornalMaterials);
        }
        [HttpGet("GetByFecha/{desde:datetime}/{hasta:datetime}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByFecha(DateTime desde,DateTime hasta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jornalMaterials = await _jornalMaterialRepositorio.ObtenerPorDesde(desde,hasta);
            if (jornalMaterials == null)
            {
                return NotFound();
            }

            return Ok(jornalMaterials);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _jornalMaterialRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, JornalMaterialModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jornalMaterial = _mapper.Map<JornalMaterialDto>(model);
            jornalMaterial.Id = id;
            await _jornalMaterialRepositorio.Modificar(jornalMaterial);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(JornalMaterialModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jornalMaterial = _mapper.Map<JornalMaterialDto>(model);
            await _jornalMaterialRepositorio.Insertar(jornalMaterial);
            return Ok(model);
        }
    }
}