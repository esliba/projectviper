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
    public class QuestionsController : ControllerBase
    {
        private readonly ProyectoViperContext _context;
        private readonly IConfiguration _config;
        private QuestionsService _questionsService;

        public QuestionsController(IConfiguration config, ProyectoViperContext context)
        {
            _context = context;
            _config = config;
            _questionsService = new QuestionsService(context);
        }

        // GET: api/Questions
        [HttpGet]
        public ActionResult<IEnumerable<QuestionDTO>> GetQuestion()
        {
            IEnumerable<QuestionDTO> questions = new List<QuestionDTO>();
            try
            {
                questions = _questionsService.GetQuestions();
            }
            catch (CustomErrorException e)
            {
                return BadRequest(new CustomMessage
                {
                    Message = e.CustomMessage,
                    DebugError = e.Message
                });
            }
            return Ok(questions);
        }

        // GET: api/Questions?id=1
        [HttpGet]
        public async Task<IActionResult> GetQuestion([FromQuery] int id)
        {
            QuestionDTO question = new QuestionDTO();
            try
            {
                question = await _questionsService.GetQuestionById(id);
            }
            catch (CustomErrorException e)
            {
                return BadRequest(new CustomMessage
                {
                    Message = e.CustomMessage,
                    DebugError = e.Message
                });
            }
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }
    }
}