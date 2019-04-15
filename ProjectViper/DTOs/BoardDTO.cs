using ProjectViper.Models;

namespace ProjectViper.DTOs
{
    public class BoardDTO
    {
        public int Id { get; set; }
        public int ThemeId { get; set; }

        public Theme Theme { get; set; }
    }
}
