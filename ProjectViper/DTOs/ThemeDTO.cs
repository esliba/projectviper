using ProjectViper.Models;
using System.Collections.Generic;

namespace ProjectViper.DTOs
{
    public class ThemeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Board> Board { get; set; }
        public ICollection<QContainer> QContainer { get; set; }
    }
}
