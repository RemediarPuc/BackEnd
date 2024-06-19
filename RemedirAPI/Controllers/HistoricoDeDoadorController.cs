using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemedirAPI.Context;
using RemedirAPI.Models;


namespace RemedirAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricoDeDoadorController : ControllerBase
    {
        private readonly ContextDb _context;

        public HistoricoDeDoadorController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/HistoricoDeDoador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoDeDoador>>> GetMedicamentos()
        {
            if (_context.historicoDeDoador == null)
            {
                return NotFound();
            }
            return await _context.historicoDeDoador.ToListAsync();
        }

        // GET: api/HistoricoDeDoador/ID
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoDeDoador>> GetMedicamento(int id)
        {
            if (_context.historicoDeDoador== null)
            {
                return NotFound();
            }
            var doador = await _context.historicoDeDoador.FindAsync(id);

            if (doador == null)
            {
                return NotFound();
            }

            return doador;
        }





    }
}
