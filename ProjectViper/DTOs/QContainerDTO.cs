using ProjectViper.Models;
using System.Collections.Generic;

namespace ProjectViper.DTOs
{
    public class QContainerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ThemeId { get; set; }

        public Theme Theme { get; set; }
        public ICollection<Question> Question { get; set; }
    }
}
