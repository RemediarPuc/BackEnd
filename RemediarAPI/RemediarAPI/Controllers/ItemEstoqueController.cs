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
    public class ItemEstoqueController : ControllerBase
    {
        private readonly ContextDb _context;
        public ItemEstoqueController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/ItemEstoque
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemEstoque>>> GetItemEstoque()
        {
            if (_context.ItemEstoques == null)
            {
                return NotFound();
            }

            return await _context.ItemEstoques.ToListAsync();
        }

        // GET: api/ItemEstoque/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemEstoque>> GetItemEstoque(int id)
        {
            if (_context.ItemEstoques == null)
            {
                return NotFound();
            }

            var item_estoque = await _context.ItemEstoques.FindAsync(id);

            if (item_estoque == null)
            {
                return NotFound();
            }

            return item_estoque;
        }

        // PUT: api/ItemEstoque/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemEstoque(int id, ItemEstoque item_estoque)
        {
            if (id != item_estoque.Id)
            {
                return BadRequest();
            }

            _context.Entry(item_estoque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockItemExists(id))
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

        // POST: api/ItemEstoque
        [HttpPost]
        public async Task<ActionResult<ItemEstoque>> PostItemEstoque(ItemEstoque item_estoque)
        {
            _context.ItemEstoques.Add(item_estoque);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostItemEstoque), new { id = item_estoque.Id }, item_estoque);
        }

        // DELETE: api/ItemEstoque/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemEstoque(int id)
        {
            if (_context.ItemEstoques == null)
            {
                return NotFound();
            }

            var item_estoque = await _context.ItemEstoques.FindAsync(id);

            if (item_estoque == null)
            {
                return NotFound();
            }

            _context.ItemEstoques.Remove(item_estoque);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockItemExists(int id)
        {
            return (_context.ItemEstoques?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
