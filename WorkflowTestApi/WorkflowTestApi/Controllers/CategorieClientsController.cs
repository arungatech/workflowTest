using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkflowTestApi.Models;

namespace WorkflowTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieClientsController : ControllerBase
    {
        private readonly WorkflowDbContext _context;

        public CategorieClientsController(WorkflowDbContext context)
        {
            _context = context;
        }

        // GET: api/CategorieClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieClient>>> GetCategorieClients()
        {
            return await _context.CategorieClients.ToListAsync();
        }

        // GET: api/CategorieClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorieClient>> GetCategorieClient(int id)
        {
            var categorieClient = await _context.CategorieClients.FindAsync(id);

            if (categorieClient == null)
            {
                return NotFound();
            }

            return categorieClient;
        }

        // PUT: api/CategorieClients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorieClient(int id, CategorieClient categorieClient)
        {
            if (id != categorieClient.Id)
            {
                return BadRequest();
            }

            _context.Entry(categorieClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieClientExists(id))
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

        // POST: api/CategorieClients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategorieClient>> PostCategorieClient(CategorieClient categorieClient)
        {
            _context.CategorieClients.Add(categorieClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorieClient", new { id = categorieClient.Id }, categorieClient);
        }

        // DELETE: api/CategorieClients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategorieClient>> DeleteCategorieClient(int id)
        {
            var categorieClient = await _context.CategorieClients.FindAsync(id);
            if (categorieClient == null)
            {
                return NotFound();
            }

            _context.CategorieClients.Remove(categorieClient);
            await _context.SaveChangesAsync();

            return categorieClient;
        }

        private bool CategorieClientExists(int id)
        {
            return _context.CategorieClients.Any(e => e.Id == id);
        }
    }
}
