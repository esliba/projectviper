using ProjectViper.DTOs;
using ProjectViper.Exceptions;
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
            IEnumerable<QOptionDTO> qOptions = new List<QOptionDTO>();
            try
            {
                qOptions = _context.QOption.Select(qo => new QOptionDTO
                {
                    Id = qo.Id,
                    Option1 = qo.Option1,
                    Option2 = qo.Option2,
                    Option3 = qo.Option3
                });
            }
            catch (Exception e)
            {
                throw new CustomErrorException(e.Message, "There was an error while getting the options");
            }
            return qOptions;
        }

        public QOptionDTO GetQOptionById(int id)
        {
            QOptionDTO qOptions = new QOptionDTO();
            try
            {
                qOptions = _context.QOption.Where(qo => qo.Id == id).Select(qo => new QOptionDTO
                {
                    Id = qo.Id,
                    Option1 = qo.Option1,
                    Option2 = qo.Option2,
                    Option3 = qo.Option3
                }).SingleOrDefault();
            }
            catch (Exception e)
            {
                throw new CustomErrorException(e.Message, "There was an error while getting the option");
            }
            return qOptions;
        }
    }
}
