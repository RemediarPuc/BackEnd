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
    public class PedidoController : ControllerBase
    {
        private readonly ContextDb _context;

        public PedidoController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
			var pedidos = await _context.Pedidos.Include(r => r.Usuario).ToListAsync();

			if (pedidos == null || pedidos.Count == 0) {
				return NotFound("Nenhuma pedido encontrado");
			}

			return Ok(new { Message = "Pedidos encontrados:", Data = pedidos });
		}

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
          if (_context.Pedidos == null)
          {
              return NotFound();
          }
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }


		// PUT: api/Pedido/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.id)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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

        [HttpPut("atualizaStatus/{id}")]
        public async Task<ActionResult<IEnumerable<Pedido>>> atualizaStatusPedido(int id) {

            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null) {
                return NotFound();
            }

            pedido.statusPedido = Status.Concluido;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!PedidoExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
            return await this.GetPedidos(); //vai retornar os pedidos já atualizados
		}

			// POST: api/Pedido
			// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
			[HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
          if (_context.Pedidos == null)
          {
              return Problem("Entity set 'ContextDb.Pedidos'  is null.");
          }
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = pedido.id }, pedido);
        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            if (_context.Pedidos == null)
            {
                return NotFound();
            }
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoExists(int id)
        {
            return (_context.Pedidos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
