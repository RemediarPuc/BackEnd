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
    public class MedicamentoController : ControllerBase
    {
        private readonly ContextDb _context;

        public MedicamentoController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/Medicamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicamento>>> GetMedicamentos()
        {
          if (_context.Medicamentos == null)
          {
              return NotFound();
          }
            return await _context.Medicamentos.ToListAsync();
        }

        // GET: api/Medicamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicamento>> GetMedicamento(int id)
        {
          if (_context.Medicamentos == null)
          {
              return NotFound();
          }
            var medicamento = await _context.Medicamentos.FindAsync(id);

            if (medicamento == null)
            {
                return NotFound();
            }

            return medicamento;
        }

        // PUT: api/Medicamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicamento(int id, Medicamento medicamento)
        {
            if (id != medicamento.id)
            {
                return BadRequest();
            }

            _context.Entry(medicamento).State = EntityState.Modified;

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

        // POST: api/Medicamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medicamento>> PostMedicamento(Medicamento medicamento)
        {
          if (_context.Medicamentos == null)
          {
              return Problem("Entity set 'ContextDb.Medicamentos'  is null.");
          }
            _context.Medicamentos.Add(medicamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicamento", new { id = medicamento.id }, medicamento);
        }

        // DELETE: api/Medicamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicamento(int id)
        {
            if (_context.Medicamentos == null)
            {
                return NotFound();
            }
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }

            _context.Medicamentos.Remove(medicamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public class NewMedicamento
        {
            public string NomeMedicamento { get; set; }
            public string Unidade { get; set; }
            public int Quantidade { get; set; }
            public DateTime DtVencimento { get; set; }
            public string Descricao { get; set; }
            public double Valor { get; set; }
        }

        // POST: api/Medicamentos/Create (new)
        [HttpPost("Create")]
        public async Task<ActionResult<Medicamento>> CreateMedicamento(NewMedicamento medicamentoData)
        {
            if (_context.Medicamentos == null)
            {
                return Problem("Entity set 'ContextDb.Medicamentos' is null.");
            }

            // Create a new Medicamento instance with only the provided data
            var medicamento = new Medicamento
            {
                nomeMedicamento = medicamentoData.NomeMedicamento,
                unidade = medicamentoData.Unidade,
                quantidade = medicamentoData.Quantidade,
                dtVencimento = medicamentoData.DtVencimento,
                descricao = medicamentoData.Descricao,
                valor = medicamentoData.Valor
            };

            _context.Medicamentos.Add(medicamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicamento", new { id = medicamento.id }, medicamento);
        }

        private bool MedicamentoExists(int id)
        {
            return (_context.Medicamentos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
