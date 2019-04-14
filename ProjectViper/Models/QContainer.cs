using System;
using System.Collections.Generic;

namespace ProjectViper.Models
{
    public partial class QContainer
    {
        public QContainer()
        {
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ThemeId { get; set; }

        public Theme Theme { get; set; }
        public ICollection<Question> Question { get; set; }
    }
}
