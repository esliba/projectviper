using ProjectViper.DTOs;
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
            return null;
        }

        public async Task<BoardDTO> GetBoardById(int id)
        {
            return null;
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
