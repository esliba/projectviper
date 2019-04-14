using System;
using System.Collections.Generic;

namespace ProjectViper.Models
{
    public partial class QOption
    {
        public QOption()
        {
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }

        public ICollection<Question> Question { get; set; }
    }
}
