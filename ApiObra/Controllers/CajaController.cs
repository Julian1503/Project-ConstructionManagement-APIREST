using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Caja;
using GestionObra.Interfaces.Caja.DTOs;
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
    public class CajaController : ControllerBase
    {
        private readonly ICajaRepositorio _cajaRepostiorio;
        private IMapper _mapper;
        public CajaController(ICajaRepositorio cajaRepostiorio)
        {
            _cajaRepostiorio = cajaRepostiorio;
            var config = new MapperConfiguration(x => x.AddProfile<AutoMapper.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        [HttpGet]
        [Route("CajasEstado")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> EstadoCaja()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estadoCaja = _cajaRepostiorio.EstadoCaja();

            return Ok(estadoCaja);
        }

        [HttpGet]
        [Route("CajaAbierta")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetCajaAbierta()
        {
            if (!ModelState.IsValid)
            {
                return  BadRequest(ModelState);
            }
            var caja =  _cajaRepostiorio.CajaAbierta();
            if (caja == null)
            {
                return  Ok(false);
            }
            return Ok(caja);
        }

        [HttpGet]
        [Route("GetDesde/{desde:datetime}/{hasta:datetime}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetDesde(DateTime desde, DateTime hasta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asistenciaContratistas = await _cajaRepostiorio.ObtenerPorDesde(desde, hasta);
            if (asistenciaContratistas == null)
            {
                return NotFound();
            }

            return Ok(asistenciaContratistas);
        }

        [HttpPost]
        [Route("AbrirCaja")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> PostAbrirCaja(CajaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var caja = _mapper.Map<CajaDto>(model);

            await _cajaRepostiorio.AbrirCaja(caja);
            if (caja == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        [HttpPost]
        [Route("CerrarCaja")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> PostCerrarCaja(CajaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var caja = _mapper.Map<CajaDto>(model);

            await _cajaRepostiorio.CerrarCaja(caja);
            if (caja == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}