using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectViper.Models;

namespace ProjectViper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QOptionsController : ControllerBase
    {
        private readonly ProyectoViperContext _context;

        public QOptionsController(ProyectoViperContext context)
        {
            _context = context;
        }

        // GET: api/QOptions
        [HttpGet]
        public IEnumerable<QOption> GetQOption()
        {
            return _context.QOption;
        }

        // GET: api/QOptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQOption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var qOption = await _context.QOption.FindAsync(id);

            if (qOption == null)
            {
                return NotFound();
            }

            return Ok(qOption);
        }

        // PUT: api/QOptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQOption([FromRoute] int id, [FromBody] QOption qOption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qOption.Id)
            {
                return BadRequest();
            }

            _context.Entry(qOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QOptionExists(id))
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

        // POST: api/QOptions
        [HttpPost]
        public async Task<IActionResult> PostQOption([FromBody] QOption qOption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.QOption.Add(qOption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQOption", new { id = qOption.Id }, qOption);
        }

        // DELETE: api/QOptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQOption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var qOption = await _context.QOption.FindAsync(id);
            if (qOption == null)
            {
                return NotFound();
            }

            _context.QOption.Remove(qOption);
            await _context.SaveChangesAsync();

            return Ok(qOption);
        }

        private bool QOptionExists(int id)
        {
            return _context.QOption.Any(e => e.Id == id);
        }
    }
}