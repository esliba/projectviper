using ProjectViper.DTOs;
using ProjectViper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectViper.Services
{
    public class QContainersService
    {
        private readonly ProyectoViperContext _context;

        public QContainersService(ProyectoViperContext context)
        {
            _context = context;
        }

        public IEnumerable<QContainerDTO> GetQContainers()
        {
            return null;
        }

        public async Task<QContainerDTO> GetQContainerById(int id)
        {
            return null;
        }

        public IEnumerable<QContainerDTO> GetQContainersByThemeId(int id)
        {
            return null;
        }
    }
}
