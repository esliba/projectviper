using ProjectViper.DTOs;
using ProjectViper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectViper.Services
{
    public class ThemesService
    {
        private readonly ProyectoViperContext _context;

        public ThemesService(ProyectoViperContext context)
        {
            _context = context;
        }

        public IEnumerable<ThemeDTO> GetThemes()
        {
            return null;
        }

        public async Task<ThemeDTO> GetThemeById(int id)
        {
            return null;
        }
    }
}
