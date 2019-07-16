using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Stock;
using GestionObra.Interfaces.Stock.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StockController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IStockRepositorio _stockRepositorio;

        public StockController(IStockRepositorio stockRepositorio)
        {
            _stockRepositorio = stockRepositorio;
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
            var stocks = await _stockRepositorio.ObtenerTodos();
            if (stocks == null)
            {
                return NotFound();
            }

            return Ok(stocks);
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
            var stocks = await _stockRepositorio.ObtenerPorFiltro(cadena);

            if (stocks == null)
            {
                return NotFound();
            }
            return Ok(stocks);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stocks = await _stockRepositorio.ObtenerPorId(id);
            if (stocks == null)
            {
                return NotFound();
            }

            return Ok(stocks);
        }
        [HttpGet("{materialId}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByLastOne(int materialId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await _stockRepositorio.ObtenerUltimo(materialId);
            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }
        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _stockRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> DescontarStock(long materialId, int cantidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _stockRepositorio.DescontarStock(materialId,cantidad);
            return Ok(materialId);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(StockModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = _mapper.Map<StockDto>(model);
            await _stockRepositorio.ActualizarStock(stock);
            return Ok(model);
        }
    }
}