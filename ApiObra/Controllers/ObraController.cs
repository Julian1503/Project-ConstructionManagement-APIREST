using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Obra;
using GestionObra.Interfaces.Obra.DTOs;
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
    public class ObraController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IObraRepositorio _obraRepositorio;

        public ObraController(IObraRepositorio obraRepositorio)
        {
            _obraRepositorio = obraRepositorio;
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
            var obras = await _obraRepositorio.ObtenerTodos();
            if (obras == null)
            {
                return NotFound();
            }

            return Ok(obras);
        }

        [HttpGet]
        [Route("GetAllP")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetAllP()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var obras = await _obraRepositorio.ObtenerEnProceso();
            if (obras == null)
            {
                return NotFound();
            }

            return Ok(obras);
        }
        [HttpGet]
        [Route("NumeroPendientes")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> CantidadPersonas()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cantidad = await _obraRepositorio.ObtenerEnMarcha();
            if (cantidad == null)
            {
                return NotFound();
            }

            return Ok(cantidad);
        }

        [HttpGet]
        [Route("GetAllN")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetAllN()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var obras = await _obraRepositorio.ObtenePendientes();
            if (obras == null)
            {
                return NotFound();
            }

            return Ok(obras);
        }
        [HttpGet]
        [Route("GetPlanificando")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetPlanificando()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var obras = await _obraRepositorio.ObtenerPlanificando();
            if (obras == null)
            {
                return NotFound();
            }

            return Ok(obras);
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
            var obras = await _obraRepositorio.ObtenerPorFiltro(cadena);

            if (obras == null)
            {
                return NotFound();
            }
            return Ok(obras);

        }

         [HttpGet("GetById/{id:int}")]
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