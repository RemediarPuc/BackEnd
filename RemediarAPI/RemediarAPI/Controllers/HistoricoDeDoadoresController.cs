using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemediarAPI.Context;
using RemediarAPI.Models;

namespace RemediarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoDeDoadoresController : ControllerBase
    {
        private readonly ContextDb _context;

        public HistoricoDeDoadoresController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/HistoricoDeDoadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoDeDoadores>>> GetHistoricoDeDoadores()
        {
            if (_context.historicoDeDoadores== null)
            {
                return NotFound();
            }
            return await _context.historicoDeDoadores.ToListAsync();
        }

        // GET: api/HistoricoDeDoadores/1
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoDeDoadores>> GetHistoricoDeDoador(int id)
        {
            if (_context.historicoDeDoadores== null)
            {
                return NotFound();
            }
            var historico = await _context.historicoDeDoadores.FindAsync(id);

            if (historico == null)
            {
                return NotFound();
            }

            return historico;
        }

        // PUT: api/HistoricoDeDoadores/1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelatorio(int id, HistoricoDeDoadores historicoDeDoadores)
        {
            if (id != historicoDeDoadores.Id)
            {
                return BadRequest();
            }

            _context.Entry(historicoDeDoadores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoadorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Historico
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistoricoDeDoadores>> PostMedicamento(HistoricoDeDoadores historicoDeDoadores)
        {
            if (_context.historicoDeDoadores== null)
            {
                return Problem("Entity set 'Nao existe historico de doador'  is null.");
            }
            _context.historicoDeDoadores.Add(historicoDeDoadores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicamento", new { id = historicoDeDoadores.Id }, historicoDeDoadores);
        }

        // DELETE: api/Relatorio/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoricoDeDoador(int id)
        {
            if (_context.historicoDeDoadores == null)
            {
                return NotFound();
            }
            var historico = await _context.historicoDeDoadores.FindAsync(id);
            if (historico == null)
            {
                return NotFound();
            }

            _context.historicoDeDoadores.Remove(historico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoadorExists(int id)
        {
            return (_context.historicoDeDoadores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
