using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManagerCore.exceptions
{
    public class SnippetSavingException : Exception
    {
        public SnippetSavingException(string message) { }
        public SnippetSavingException(string message, Exception innerException) { }
    }
}
