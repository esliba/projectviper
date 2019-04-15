using ProjectViper.DTOs;
using ProjectViper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectViper.Services
{
    public class QOptionsService
    {
        private readonly ProyectoViperContext _context;

        public QOptionsService(ProyectoViperContext context)
        {
            _context = context;
        }

        public IEnumerable<QOptionDTO> GetQOptions()
        {
            return null;
        }

        public async Task<QOptionDTO> GetQOptionById(int id)
        {
            return null;
        }

        public IEnumerable<QOptionDTO> GetQOptionsByQuestionId(int id)
        {
            return null;
        }
    }
}
