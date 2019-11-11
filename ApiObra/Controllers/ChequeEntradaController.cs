using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.ChequeEntrada;
using GestionObra.Interfaces.ChequeEntrada.DTOs;
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
    public class ChequeEntradaController : ControllerBase
    {
        private readonly IChequeEntradaServicio _chequeEntradaServicio;
        private IMapper _mapper;
        public ChequeEntradaController(IChequeEntradaServicio chequeEntradaServicio)
        {
            _chequeEntradaServicio = chequeEntradaServicio;
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
            var chequeEntradas = await _chequeEntradaServicio.ObtenerTodos();
            if (chequeEntradas == null)
            {
                return NotFound();
            }

            return Ok(chequeEntradas);
        }

        [HttpGet]
        [Route("GetByFecha/{desde:datetime}/{hasta:datetime}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByFecha(DateTime desde, DateTime hasta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _chequeEntradaServicio.ObtenerPorDesde(desde, hasta);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }

        [HttpGet]
        [Route("GetByConcepto/{desde:datetime}/{hasta:datetime}/{concepto}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByConcepto(DateTime desde, DateTime hasta,string concepto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _chequeEntradaServicio.ObtenerPorConcepto(desde, hasta,concepto);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }
        [HttpGet]
        [Route("GetByDePara/{desde:datetime}/{hasta:datetime}/{dePara}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByDePara(DateTime desde, DateTime hasta, string dePara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _chequeEntradaServicio.ObtenerPorDePara(desde, hasta, dePara);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
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
            var chequeEntradas = await _chequeEntradaServicio.ObtenerPorFiltro(cadena);

            if (chequeEntradas == null)
            {
                return NotFound();
            }
            return Ok(chequeEntradas);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var chequeEntradas = await _chequeEntradaServicio.ObtenerPorId(id);
            if (chequeEntradas == null)
            {
                return NotFound();
            }

            return Ok(chequeEntradas);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _chequeEntradaServicio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, ChequeEntradaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chequeEntrada = _mapper.Map<ChequeEntradaDto>(model);
            chequeEntrada.Id = id;
            await _chequeEntradaServicio.Modificar(chequeEntrada);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(ChequeEntradaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var chequeEntrada = _mapper.Map<ChequeEntradaDto>(model);
            await _chequeEntradaServicio.Insertar(chequeEntrada);
            return Ok(model);
        }
    }
}