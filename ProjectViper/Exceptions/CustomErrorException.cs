using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectViper.Exceptions
{
    public class CustomErrorException : Exception
    {
        public string CustomMessage { get; set; }

        public CustomErrorException(string message, string customMessage)
            : base(message)
        {
            CustomMessage = customMessage;
        }

        public CustomErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
