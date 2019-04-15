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
    public class QContainersController : ControllerBase
    {
        private readonly ProyectoViperContext _context;
        private readonly IConfiguration _config;
        private QContainersService _qContainersService;

        public QContainersController(IConfiguration config, ProyectoViperContext context)
        {
            _context = context;
            _config = config;
            _qContainersService = new QContainersService(context);
        }

        // GET: api/QContainers
        [HttpGet]
        public ActionResult<IEnumerable<QContainerDTO>> GetQContainer()
        {
            IEnumerable<QContainerDTO> qContainers = new List<QContainerDTO>();
            try
            {
                qContainers = _qContainersService.GetQContainers();
            }
            catch (CustomErrorException e)
            {
                return BadRequest(new CustomMessage
                {
                    Message = e.CustomMessage,
                    DebugError = e.Message
                });
            }
            return Ok(qContainers);
        }

        // GET: api/QContainers?id=1
        [HttpGet]
        public async Task<IActionResult> GetQContainer([FromQuery] int id)
        {
            QContainerDTO qContainer = new QContainerDTO();
            try
            {
                qContainer = await _qContainersService.GetQContainerById(id);
            }
            catch (CustomErrorException e)
            {
                return BadRequest(new CustomMessage
                {
                    Message = e.CustomMessage,
                    DebugError = e.Message
                });
            }
            if (qContainer == null)
            {
                return NotFound();
            }
            return Ok(qContainer);
        }
    }
}