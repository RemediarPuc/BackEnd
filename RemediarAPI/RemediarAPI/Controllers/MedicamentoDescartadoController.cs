using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemediarAPI.Context;
using RemediarAPI.Models;

namespace RemediarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoDescartadoController : ControllerBase
    {
        private readonly ContextDb _context;

        public MedicamentoDescartadoController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/MedicamentoDescartado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicamentoDescartado>>> GetMedicamentosDescartados()
        {
          if (_context.MedicamentosDescartados == null)
          {
              return NotFound();
          }
            return await _context.MedicamentosDescartados.ToListAsync();
        }

        // GET: api/MedicamentoDescartado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicamentoDescartado>> GetMedicamentoDescartado(int id)
        {
          if (_context.MedicamentosDescartados == null)
          {
              return NotFound();
          }
            var medicamentoDescartado = await _context.MedicamentosDescartados.FindAsync(id);

            if (medicamentoDescartado == null)
            {
                return NotFound();
            }

            return medicamentoDescartado;
        }

        // PUT: api/MedicamentoDescartado/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicamentoDescartado(int id, MedicamentoDescartado medicamentoDescartado)
        {
            if (id != medicamentoDescartado.id)
            {
                return BadRequest();
            }

            _context.Entry(medicamentoDescartado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentoDescartadoExists(id))
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

        // POST: api/MedicamentoDescartado
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicamentoDescartado>> PostMedicamentoDescartado(MedicamentoDescartado medicamentoDescartado)
        {
          if (_context.MedicamentosDescartados == null)
          {
              return Problem("Entity set 'ContextDb.MedicamentosDescartados'  is null.");
          }
            _context.MedicamentosDescartados.Add(medicamentoDescartado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicamentoDescartado", new { id = medicamentoDescartado.id }, medicamentoDescartado);
        }

        // DELETE: api/MedicamentoDescartado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicamentoDescartado(int id)
        {
            if (_context.MedicamentosDescartados == null)
            {
                return NotFound();
            }
            var medicamentoDescartado = await _context.MedicamentosDescartados.FindAsync(id);
            if (medicamentoDescartado == null)
            {
                return NotFound();
            }

            _context.MedicamentosDescartados.Remove(medicamentoDescartado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicamentoDescartadoExists(int id)
        {
            return (_context.MedicamentosDescartados?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
