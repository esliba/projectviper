using ProjectViper.DTOs;
using ProjectViper.Exceptions;
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
            IEnumerable<ThemeDTO> themes = new List<ThemeDTO>();
            try
            {
                themes = _context.Theme.Select(t => new ThemeDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                    QContainer = t.QContainer
                });
            }
            catch (Exception e)
            {
                throw new CustomErrorException(e.Message, "There was a problem while getting the themes");
            }
            return themes;
        }

        public ThemeDTO GetThemeById(int id)
        {
            ThemeDTO theme = new ThemeDTO();
            try
            {
                theme = _context.Theme.Where(t => t.Id == id).Select(t => new ThemeDTO
                {
                    Id = t.Id,
                    Name = t.Name,
                    QContainer = t.QContainer
                }).SingleOrDefault();
            }
            catch (Exception e)
            {
                throw new CustomErrorException(e.Message, "There was a problem while getting the theme");
            }
            return theme;
        }
    }
}
