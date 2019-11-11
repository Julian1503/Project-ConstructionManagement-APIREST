using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.SalarioMinimo;
using GestionObra.Interfaces.SalarioMinimo.DTOs;
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
    public class SalariosMinimoController : ControllerBase
    {
        private readonly ISalarioMinimoServicio _salariosMinimoRepositorio;
        private IMapper _mapper;
        public SalariosMinimoController(ISalarioMinimoServicio salariosMinimoRepositorio)
        {
            _salariosMinimoRepositorio = salariosMinimoRepositorio;
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
            var salariosMinimos = await _salariosMinimoRepositorio.ObtenerTodos();
            if (salariosMinimos == null)
            {
                return NotFound();
            }

            return Ok(salariosMinimos);
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
            var salariosMinimos = await _salariosMinimoRepositorio.ObtenerPorFiltro(cadena);

            if (salariosMinimos == null)
            {
                return NotFound();
            }
            return Ok(salariosMinimos);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var salariosMinimos = await _salariosMinimoRepositorio.ObtenerPorId(id);
            if (salariosMinimos == null)
            {
                return NotFound();
            }

            return Ok(salariosMinimos);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _salariosMinimoRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, SalarioMinimoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salariosMinimo = _mapper.Map<SalarioMinimoDto>(model);
            salariosMinimo.Id = id;
            await _salariosMinimoRepositorio.Modificar(salariosMinimo);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(SalarioMinimoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var salariosMinimo = _mapper.Map<SalarioMinimoDto>(model);
            await _salariosMinimoRepositorio.Insertar(salariosMinimo);
            return Ok(model);
        }
    }
}