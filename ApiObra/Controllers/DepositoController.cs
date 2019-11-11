using System;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Deposito;
using GestionObra.Interfaces.Deposito.DTOs;
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
    public class DepositoController : ControllerBase
    {
        private readonly IDepositoServicio _depositoServicio;
        private IMapper _mapper;
        public DepositoController(IDepositoServicio depositoServicio)
        {
            _depositoServicio = depositoServicio;
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
            var bancos = await _depositoServicio.ObtenerTodos();
            if (bancos == null)
            {
                return NotFound();
            }

            return Ok(bancos);
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
            var presupuestos = await _depositoServicio.ObtenerPorDesde(desde, hasta);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }
        [HttpGet]
        [Route("GetByFecha/{desde:datetime}/{hasta:datetime}/{concepto}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByConcepto(DateTime desde, DateTime hasta,string concepto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _depositoServicio.ObtenerPorConcepto(desde, hasta,concepto);
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
            var presupuestos = await _depositoServicio.ObtenerPorDePara(desde, hasta, dePara);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }
        [HttpGet("GetLast")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetLast()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var depositos = await _depositoServicio.ObtenerSiguienteId();
            if (depositos == null)
            {
                return NotFound();
            }

            return Ok(depositos);
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
            var bancos = await _depositoServicio.Obtener(cadena);

            if (bancos == null)
            {
                return NotFound();
            }
            return Ok(bancos);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bancos = await _depositoServicio.ObtenerPorId(id);
            if (bancos == null)
            {
                return NotFound();
            }

            return Ok(bancos);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _depositoServicio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, DepositoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banco = _mapper.Map<DepositoDto>(model);
            banco.Id = id;
            await _depositoServicio.Modificar(banco);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(DepositoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var banco = _mapper.Map<DepositoDto>(model);
            var a = await _depositoServicio.Insertar(banco);
            return Ok(a);
        }
    }
}