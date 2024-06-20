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
    public class DoacaoController : ControllerBase
    {
        private readonly ContextDb _context;

        public DoacaoController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/Doacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doacao>>> GetDoacoes()
        {
          if (_context.Doacoes == null)
          {
              return NotFound();
          }
            //await _context.Doacoes.AsNoTracking().Include(x => x.Usuario).ToListAsync();
            return Ok(new { Data = await _context.Doacoes.AsNoTracking().Include(x => x.Usuario).ToListAsync() });
        }

        // GET: api/Doacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doacao>> GetDoacao(int id)
        {
          if (_context.Doacoes == null)
          {
              return NotFound();
          }
            var doacao = await _context.Doacoes.FindAsync(id);

            if (doacao == null)
            {
                return NotFound();
            }

            return doacao;
        }

        // PUT: api/Doacao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoacao(int id, Doacao doacao)
        {
            if (id != doacao.id)
            {
                return BadRequest();
            }

            _context.Entry(doacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoacaoExists(id))
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
        [HttpPut("alteraStatus/{id}")]
        public async Task<IActionResult> PutStatusDoacao(int id, [FromBody]Status status)
        {
            Doacao doacao =  await _context.Doacoes.Where(x => x.id == id).FirstOrDefaultAsync();
            doacao.statusDoacao = status;

            _context.Entry(doacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(doacao);
        }
        // POST: api/Doacao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doacao>> PostDoacao(Doacao doacao)
        {
          if (_context.Doacoes == null)
          {
              return Problem("Entity set 'ContextDb.Doacoes'  is null.");
          }
            _context.Doacoes.Add(doacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoacao", new { id = doacao.id }, doacao);
        }

        // DELETE: api/Doacao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoacao(int id)
        {
            if (_context.Doacoes == null)
            {
                return NotFound();
            }
            var doacao = await _context.Doacoes.FindAsync(id);
            if (doacao == null)
            {
                return NotFound();
            }

            _context.Doacoes.Remove(doacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoacaoExists(int id)
        {
            return (_context.Doacoes?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
