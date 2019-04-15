using ProjectViper.DTOs;
using ProjectViper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectViper.Services
{
    public class QuestionsService
    {
        private readonly ProyectoViperContext _context;

        public QuestionsService(ProyectoViperContext context)
        {
            _context = context;
        }

        public IEnumerable<QuestionDTO> GetQuestions()
        {
            return null;
        }

        public async Task<QuestionDTO> GetQuestionById(int id)
        {
            return null;
        }

        public IEnumerable<QuestionDTO> GetQuestionsByQContainerId(int id)
        {
            return null;
        }
    }
}
