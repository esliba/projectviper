using System;
using System.Collections.Generic;

namespace ProjectViper.Models
{
    public partial class Board
    {
        public int Id { get; set; }
        public int ThemeId { get; set; }

        public Theme Theme { get; set; }
    }
}
