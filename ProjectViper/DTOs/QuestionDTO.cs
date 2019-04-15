using ProjectViper.Models;

namespace ProjectViper.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Question1 { get; set; }
        public string Level { get; set; }
        public string Answer { get; set; }
        public int QContainerId { get; set; }
        public int? QOptionId { get; set; }

        public QContainer QContainer { get; set; }
        public QOption QOption { get; set; }
    }
}
