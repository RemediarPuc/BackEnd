using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemediarAPI.Context;
using RemediarAPI.Models;

namespace RemediarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmissaoRelatoriosController : ControllerBase
    {
        private readonly ContextDb _context;

        public EmissaoRelatoriosController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/EmissãoRelatorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmissaoRelatorios>>> GetEmissaoRelatorios()
        {
            if (_context.emissaoRelatorios== null)
            {
                return NotFound();
            }
            return await _context.emissaoRelatorios.ToListAsync();
        }

        // GET: api/Relatorio/1
        [HttpGet("{id}")]
        public async Task<ActionResult<EmissaoRelatorios>> GetRelatorio(int id)
        {
            if (_context.emissaoRelatorios == null)
            {
                return NotFound();
            }
            var relatorio = await _context.emissaoRelatorios.FindAsync(id);

            if (relatorio == null)
            {
                return NotFound();
            }

            return relatorio;
        }

        // PUT: api/Relatorio/1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelatorio(int id, EmissaoRelatorios emissaoRelatorios)
        {
            if (id != emissaoRelatorios.id)
            {
                return BadRequest();
            }

            _context.Entry(emissaoRelatorios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentoExists(id))
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

        // POST: api/Relatorios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medicamento>> PostMedicamento(EmissaoRelatorios emissaoRelatorio)
        {
            if (_context.emissaoRelatorios == null)
            {
                return Problem("Entity set 'ContextDb.Medicamentos'  is null.");
            }
            _context.emissaoRelatorios.Add(emissaoRelatorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicamento", new { id = emissaoRelatorio.id }, emissaoRelatorio);
        }

        // DELETE: api/Relatorio/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelatorio(int id)
        {
            if (_context.emissaoRelatorios == null)
            {
                return NotFound();
            }
            var relatorio = await _context.emissaoRelatorios.FindAsync(id);
            if (relatorio == null)
            {
                return NotFound();
            }

            _context.emissaoRelatorios.Remove(relatorio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicamentoExists(int id)
        {
            return (_context.emissaoRelatorios?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
