using ProjectViper.DTOs;
using ProjectViper.Exceptions;
using ProjectViper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectViper.Services
{
    public class BoardsService
    {
        private readonly ProyectoViperContext _context;

        public BoardsService(ProyectoViperContext context)
        {
            _context = context;
        }

        public IEnumerable<BoardDTO> GetBoards()
        {
            IEnumerable<BoardDTO> boards = new List<BoardDTO>();
            try
            {
                boards = _context.Board.Select(b => new BoardDTO
                {
                    Id = b.Id,
                    ThemeId = b.ThemeId,
                    Theme = b.Theme
                });
            }
            catch (Exception e)
            {
                throw new CustomErrorException(e.Message, "There was a problem while getting the boards");
            }
            return boards;
        }

        public BoardDTO GetBoardById(int id)
        {
            BoardDTO board = new BoardDTO();
            try
            {
                board = _context.Board.Where(b => b.Id == id).Select(b => new BoardDTO
                {
                    Id = b.Id,
                    ThemeId = b.ThemeId,
                    Theme = b.Theme
                }).SingleOrDefault();
            }
            catch (Exception e)
            {
                throw new CustomErrorException(e.Message, "There was a problem while getting the board");
            }
            return board;
        }

        public async Task<BoardDTO> CreateBoard(BoardDTO board)
        {
            return null;
        }

        public async Task<BoardDTO> DeleteBoard(int id)
        {
            return null;
        }
    }
}
