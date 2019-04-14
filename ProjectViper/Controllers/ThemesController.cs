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
    public class ThemesController : ControllerBase
    {
        private readonly ProyectoViperContext _context;

        public ThemesController(ProyectoViperContext context)
        {
            _context = context;
        }

        // GET: api/Themes
        [HttpGet]
        public IEnumerable<Theme> GetTheme()
        {
            return _context.Theme;
        }

        // GET: api/Themes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTheme([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var theme = await _context.Theme.FindAsync(id);

            if (theme == null)
            {
                return NotFound();
            }

            return Ok(theme);
        }

        // PUT: api/Themes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheme([FromRoute] int id, [FromBody] Theme theme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != theme.Id)
            {
                return BadRequest();
            }

            _context.Entry(theme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThemeExists(id))
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

        // POST: api/Themes
        [HttpPost]
        public async Task<IActionResult> PostTheme([FromBody] Theme theme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Theme.Add(theme);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTheme", new { id = theme.Id }, theme);
        }

        // DELETE: api/Themes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheme([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var theme = await _context.Theme.FindAsync(id);
            if (theme == null)
            {
                return NotFound();
            }

            _context.Theme.Remove(theme);
            await _context.SaveChangesAsync();

            return Ok(theme);
        }

        private bool ThemeExists(int id)
        {
            return _context.Theme.Any(e => e.Id == id);
        }
    }
}