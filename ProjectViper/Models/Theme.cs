using System;
using System.Collections.Generic;

namespace ProjectViper.Models
{
    public partial class Theme
    {
        public Theme()
        {
            Board = new HashSet<Board>();
            QContainer = new HashSet<QContainer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Board> Board { get; set; }
        public ICollection<QContainer> QContainer { get; set; }
    }
}
