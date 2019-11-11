using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Identificacion;
using GestionObra.Interfaces.Identificacion.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IdentificacionController : ControllerBase
    {
        private readonly IIdentificacion _identificacionServicio;
        private IMapper _mapper;

        public IdentificacionController(IIdentificacion identificacionServicio)
        {
            _identificacionServicio = identificacionServicio;
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
            var identificacions = await _identificacionServicio.ObtenerTodos();
            if (identificacions == null)
            {
                return NotFound();
            }

            return Ok(identificacions);
        }

        
        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identificacions = await _identificacionServicio.ObtenerPorId(id);
            if (identificacions == null)
            {
                return NotFound();
            }

            return Ok(identificacions);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _identificacionServicio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, IdentificacionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identificacion = _mapper.Map<IdentificacionDto>(model);
            identificacion.Id = id;
            await _identificacionServicio.Modificar(identificacion);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(IdentificacionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identificacion = _mapper.Map<IdentificacionDto>(model);
            var id = await _identificacionServicio.Insertar(identificacion);
            return Ok(id);
        }
    }
}