#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotaSpeseRESTService;
using NotaSpeseRESTService.Models;

namespace NotaSpeseRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaSpeseController : ControllerBase
    {
        private readonly NotaSpeseDbContext _context;

        public NotaSpeseController(NotaSpeseDbContext context)
        {
            _context = context;
        }

        // GET: api/NotaSpese
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotaSpese>>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/NotaSpese/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotaSpese>> GetNotaSpese(long id)
        {
            var notaSpese = await _context.TodoItems.FindAsync(id);

            if (notaSpese == null)
            {
                return NotFound();
            }

            return notaSpese;
        }

        // PUT: api/NotaSpese/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotaSpese(long id, NotaSpese notaSpese)
        {
            if (id != notaSpese.Id)
            {
                return BadRequest();
            }

            _context.Entry(notaSpese).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaSpeseExists(id))
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

        // POST: api/NotaSpese
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NotaSpese>> PostNotaSpese(NotaSpese notaSpese)
        {
            _context.TodoItems.Add(notaSpese);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotaSpese", new { id = notaSpese.Id }, notaSpese);
        }

        // DELETE: api/NotaSpese/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotaSpese(long id)
        {
            var notaSpese = await _context.TodoItems.FindAsync(id);
            if (notaSpese == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(notaSpese);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotaSpeseExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
