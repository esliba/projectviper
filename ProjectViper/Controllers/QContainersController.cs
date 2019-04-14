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
    public class QContainersController : ControllerBase
    {
        private readonly ProyectoViperContext _context;

        public QContainersController(ProyectoViperContext context)
        {
            _context = context;
        }

        // GET: api/QContainers
        [HttpGet]
        public IEnumerable<QContainer> GetQContainer()
        {
            return _context.QContainer;
        }

        // GET: api/QContainers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQContainer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var qContainer = await _context.QContainer.FindAsync(id);

            if (qContainer == null)
            {
                return NotFound();
            }

            return Ok(qContainer);
        }

        // PUT: api/QContainers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQContainer([FromRoute] int id, [FromBody] QContainer qContainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qContainer.Id)
            {
                return BadRequest();
            }

            _context.Entry(qContainer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QContainerExists(id))
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

        // POST: api/QContainers
        [HttpPost]
        public async Task<IActionResult> PostQContainer([FromBody] QContainer qContainer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.QContainer.Add(qContainer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQContainer", new { id = qContainer.Id }, qContainer);
        }

        // DELETE: api/QContainers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQContainer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var qContainer = await _context.QContainer.FindAsync(id);
            if (qContainer == null)
            {
                return NotFound();
            }

            _context.QContainer.Remove(qContainer);
            await _context.SaveChangesAsync();

            return Ok(qContainer);
        }

        private bool QContainerExists(int id)
        {
            return _context.QContainer.Any(e => e.Id == id);
        }
    }
}