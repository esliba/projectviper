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
    public class BoardsController : ControllerBase
    {
        private readonly ProyectoViperContext _context;
        private readonly IConfiguration _config;
        private BoardsService _boardsService;

        public BoardsController(IConfiguration config, ProyectoViperContext context)
        {
            _context = context;
            _config = config;
            _boardsService = new BoardsService(context);
        }

        // GET: api/Boards
        [HttpGet]
        public ActionResult<IEnumerable<BoardDTO>> GetBoard()
        {
            IEnumerable<BoardDTO> boards = new List<BoardDTO>();
            try
            {
                boards = _boardsService.GetBoards();
            }
            catch (CustomErrorException e)
            {
                return BadRequest(new CustomMessage
                {
                    Message = e.CustomMessage,
                    DebugError = e.Message
                });
            }
            return Ok(boards);
        }

        // GET: api/Boards?id=1
        [HttpGet]
        public ActionResult<BoardDTO> GetBoard([FromQuery] int id)
        {
            BoardDTO board = new BoardDTO();
            try
            {
                board = _boardsService.GetBoardById(id);
            }
            catch (CustomErrorException e)
            {
                return BadRequest(new CustomMessage
                {
                    Message = e.CustomMessage,
                    DebugError = e.Message
                });
            }
            if (board == null)
            {
                return NotFound();
            }
            return Ok(board);
        }

        // POST: api/Boards
        [HttpPost]
        public async Task<IActionResult> PostBoard([FromBody] BoardDTO b)
        {
            BoardDTO board = new BoardDTO();
            try
            {
                board = await _boardsService.CreateBoard(b);
            }
            catch (CustomErrorException e)
            {
                return BadRequest(new CustomMessage
                {
                    Message = e.CustomMessage,
                    DebugError = e.Message
                });
            }
            return CreatedAtAction("GetBoard", new { id = board.Id }, board);
        }

        // DELETE: api/Boards?id=1
        [HttpDelete]
        public async Task<IActionResult> DeleteBoard([FromQuery] int id)
        {
            BoardDTO board = new BoardDTO();
            try
            {
                board = await _boardsService.DeleteBoard(id);
            }
            catch (CustomErrorException e)
            {
                return BadRequest(new CustomMessage
                {
                    Message = e.CustomMessage,
                    DebugError = e.Message
                });
            }
            if (board == null)
            {
                return NotFound();
            }
            return Ok(board);
        }
    }
}