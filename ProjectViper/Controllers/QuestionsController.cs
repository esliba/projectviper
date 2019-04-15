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
        public ActionResult<QuestionDTO> GetQuestion([FromQuery] int id)
        {
            QuestionDTO question = new QuestionDTO();
            try
            {
                question = _questionsService.GetQuestionById(id);
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

        // GET: api/Questions/qcontainer?qContainerId=1
        [HttpGet]
        [Route("qcontainer")]
        public ActionResult<IEnumerable<QuestionDTO>> GetQuestionByQContainerId([FromQuery] int qContainerId)
        {
            IEnumerable<QuestionDTO> questions = new List<QuestionDTO>();
            try
            {
                questions = _questionsService.GetQuestionsByQContainerId(qContainerId);
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

        // GET: api/Questions/options?questionId=1
        [HttpGet]
        [Route("options")]
        public ActionResult<IEnumerable<QOptionDTO>> GetOptionsForQuestion(int questionId)
        {
            IEnumerable<QOptionDTO> options = new List<QOptionDTO>();
            try
            {
                options = _questionsService.GetOptionsForQuestion(questionId);
            }
            catch (CustomErrorException e)
            {
                return BadRequest(new CustomMessage
                {
                    Message = e.CustomMessage,
                    DebugError = e.Message
                });
            }
            return Ok(options);
        }
    }
}