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
    public class QOptionsController : ControllerBase
    {
        private readonly ProyectoViperContext _context;
        private readonly IConfiguration _config;
        private QOptionsService _qOptionsService;

        public QOptionsController(IConfiguration config, ProyectoViperContext context)
        {
            _context = context;
            _config = config;
            _qOptionsService = new QOptionsService(context);
        }

        // GET: api/QOptions
        [HttpGet]
        public ActionResult<IEnumerable<QOptionDTO>> GetQOption()
        {
            IEnumerable<QOptionDTO> qOptions = new List<QOptionDTO>();
            try
            {
                qOptions = _qOptionsService.GetQOptions();
            }
            catch (CustomErrorException e)
            {
                return BadRequest(new CustomMessage
                {
                    Message = e.CustomMessage,
                    DebugError = e.Message
                });
            }
            return Ok(qOptions);
        }

        // GET: api/QOptions?id=1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQOption([FromQuery] int id)
        {
            QOptionDTO qOption = new QOptionDTO();
            try
            {
                qOption = await _qOptionsService.GetQOptionById(id);
            }
            catch (CustomErrorException e)
            {
                return BadRequest(new CustomMessage
                {
                    Message = e.CustomMessage,
                    DebugError = e.Message
                });
            }
            if (qOption == null)
            {
                return NotFound();
            }
            return Ok(qOption);
        }
    }
}