using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectViper.DTOs;
using ProjectViper.Exceptions;
using ProjectViper.Models;
using ProjectViper.Services;

namespace ProjectViper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemesController : ControllerBase
    {
        private readonly ProyectoViperContext _context;
        private readonly IConfiguration _config;
        private ThemesService _themesService;

        public ThemesController(IConfiguration config, ProyectoViperContext context)
        {
            _context = context;
            _config = config;
            _themesService = new ThemesService(context);
        }

        // GET: api/Themes
        [HttpGet]
        public ActionResult<IEnumerable<ThemeDTO>> GetTheme()
        {
            IEnumerable<ThemeDTO> themes = new List<ThemeDTO>();
            try
            {
                themes = _themesService.GetThemes();
            }
            catch (CustomErrorException e)
            {
                return BadRequest(new CustomMessage
                {
                    Message = e.CustomMessage,
                    DebugError = e.Message
                });
            }
            return Ok(themes);
        }

        // GET: api/Themes?id=1
        [HttpGet]
        public async Task<IActionResult> GetTheme([FromQuery] int id)
        {
            ThemeDTO theme = new ThemeDTO();
            try
            {
                theme = await _themesService.GetThemeById(id);
            }
            catch (CustomErrorException e)
            {
                return BadRequest(new CustomMessage
                {
                    Message = e.CustomMessage,
                    DebugError = e.Message
                });
            }
            if (theme == null)
            {
                return NotFound();
            }
            return Ok(theme);
        }
    }
}