using ProjectViper.DTOs;
using ProjectViper.Exceptions;
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
            IEnumerable<QuestionDTO> questions = new List<QuestionDTO>();
            try
            {
                questions = _context.Question.Select(q => new QuestionDTO
                {
                    Id = q.Id,
                    Question = q._Question,
                    Level = q.Level,
                    Answer = q.Answer,
                    QContainerId = q.QContainerId,
                    QOptionId = q.QOptionId
                });
            }
            catch (Exception e)
            {
                throw new CustomErrorException(e.Message, "There was an error while getting the questions");
            }
            return questions;
        }

        public QuestionDTO GetQuestionById(int id)
        {
            QuestionDTO question = new QuestionDTO();
            try
            {
                question = _context.Question.Where(q => q.Id == id).Select(q => new QuestionDTO
                {
                    Id = q.Id,
                    Question = q._Question,
                    Level = q.Level,
                    Answer = q.Answer,
                    QContainerId = q.QContainerId,
                    QOptionId = q.QOptionId
                }).SingleOrDefault();
            }
            catch (Exception e)
            {
                throw new CustomErrorException(e.Message, "There was an error while getting the question");
            }
            return question;
        }

        public IEnumerable<QuestionDTO> GetQuestionsByQContainerId(int id)
        {
            IEnumerable<QuestionDTO> questions = new List<QuestionDTO>();
            try
            {
                questions = _context.Question.Where(q => q.QContainerId == id).Select(q => new QuestionDTO
                {
                    Id = q.Id,
                    Question = q._Question,
                    Level = q.Level,
                    Answer = q.Answer,
                    QContainerId = q.QContainerId,
                    QOptionId = q.QOptionId,
                    QOption = q.QOption
                });
            }
            catch (Exception e)
            {
                throw new CustomErrorException(e.Message, "There was an error while getting the questions for the container id");
            }
            return questions;
        }

        public IEnumerable<QOptionDTO> GetOptionsForQuestion(int questionId)
        {
            IEnumerable<QOptionDTO> options = new List<QOptionDTO>();
            try
            {
                options = _context.Question.Where(q => q.Id == questionId).Select(q => new QOptionDTO
                {
                    Id = q.QOption.Id,
                    Option1 = q.QOption.Option1,
                    Option2 = q.QOption.Option2,
                    Option3 = q.QOption.Option3
                });
            }
            catch (Exception e)
            {
                throw new CustomErrorException(e.Message, "There was an error while getting the options for the question");
            }
            return options;
        }
    }
}
