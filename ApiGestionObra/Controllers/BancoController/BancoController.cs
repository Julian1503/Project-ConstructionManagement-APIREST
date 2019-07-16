using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObra.Interfaces.Banco;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionObra.Controllers.BancoController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IBancoRepositorio _bancoRepositorio;

        public BancoController(IBancoRepositorio bancoRepositorio)
        {
            _bancoRepositorio = bancoRepositorio;
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("Obtener")]
        public async Task<IActionResult> ObtenerBancos()
        {
            try
            {
                var banco = await _bancoRepositorio.Obtener(string.Empty);
                return Ok(banco);
            }
            catch (System.ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}