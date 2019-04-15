using ProjectViper.DTOs;
using ProjectViper.Exceptions;
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
            IEnumerable<QContainerDTO> qContainers = new List<QContainerDTO>();
            try
            {
                qContainers = _context.QContainer.Select(qc => new QContainerDTO
                {
                    Id = qc.Id,
                    Name = qc.Name,
                    ThemeId = qc.ThemeId,
                    Question = qc.Question
                });
            }
            catch (Exception e)
            {
                throw new CustomErrorException(e.Message, "There was an error while getting the Question Containers");
            }
            return qContainers;
        }

        public QContainerDTO GetQContainerById(int id)
        {
            QContainerDTO qContainer = new QContainerDTO();
            try
            {
                qContainer = _context.QContainer.Where(qc => qc.Id == id).Select(qc => new QContainerDTO
                {
                    Id = qc.Id,
                    Name = qc.Name,
                    ThemeId = qc.ThemeId,
                    Question = qc.Question
                }).SingleOrDefault();
            }
            catch (Exception e)
            {
                throw new CustomErrorException(e.Message, "There was an error while getting the Question Container");
            }
            return qContainer;
        }

        public IEnumerable<QContainerDTO> GetQContainersByThemeId(int id)
        {
            IEnumerable<QContainerDTO> qContainers = new List<QContainerDTO>();
            try
            {
                qContainers = _context.QContainer.Where(qc => qc.ThemeId == id).Select(qc => new QContainerDTO
                {
                    Id = qc.Id,
                    Name = qc.Name,
                    ThemeId = qc.ThemeId,
                    Question = qc.Question
                });
            }
            catch (Exception e)
            {
                throw new CustomErrorException(e.Message, "There was an error while getting the Question Containers by theme id");
            }
            return qContainers;
        }
    }
}
