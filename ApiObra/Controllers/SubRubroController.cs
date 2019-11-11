using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.SubRubro;
using GestionObra.Interfaces.SubRubro.DTOs;
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
    public class SubRubroController : ControllerBase
    {
        private IMapper _mapper;
        private readonly ISubRubroServicio _subRubroServicio;

        public SubRubroController(ISubRubroServicio subRubroServicio)
        {
            _subRubroServicio = subRubroServicio;
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
            var subRubros = await _subRubroServicio.ObtenerTodos();
            if (subRubros == null)
            {
                return NotFound();
            }

            return Ok(subRubros);
        }
        [HttpGet("ObtenerEntradas")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetIn()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var subRubros = await _subRubroServicio.ObtenerEntradas();
            if (subRubros == null)
            {
                return NotFound();
            }

            return Ok(subRubros);
        }
        [HttpGet("ObtenerSalidas")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetOut()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var subRubros = await _subRubroServicio.ObtenerSalidas();
            if (subRubros == null)
            {
                return NotFound();
            }

            return Ok(subRubros);
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
            var subRubros = await _subRubroServicio.ObtenerPorFiltro(cadena);

            if (subRubros == null)
            {
                return NotFound();
            }
            return Ok(subRubros);

        }

         [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var subRubros = await _subRubroServicio.ObtenerPorId(id);
            if (subRubros == null)
            {
                return NotFound();
            }

            return Ok(subRubros);
        }
        [HttpGet("GetByRubro/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByRubro(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var subRubros = await _subRubroServicio.ObtenerPorRubroId(id);
            if (subRubros == null)
            {
                return NotFound();
            }

            return Ok(subRubros);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _subRubroServicio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, SubRubroModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subRubro = _mapper.Map<SubRubroDto>(model);
            subRubro.Id = id;
            await _subRubroServicio.Modificar(subRubro);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(SubRubroModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var subRubro = _mapper.Map<SubRubroDto>(model);
            await _subRubroServicio.Insertar(subRubro);
            return Ok(model);
        }
    }
}