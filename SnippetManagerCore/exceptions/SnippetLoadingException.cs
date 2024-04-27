using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManagerCore.exceptions
{
    public class SnippetLoadingException : Exception
    {
        public SnippetLoadingException(string message) : base(message) { }
        public SnippetLoadingException(string message, Exception innerException) : base(message, innerException) { }
    }
}
