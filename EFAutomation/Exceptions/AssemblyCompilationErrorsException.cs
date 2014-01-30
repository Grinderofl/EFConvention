using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation.Exceptions
{
    public class AssemblyCompilationErrorsException : Exception
    {
        public CompilerErrorCollection Errors { get; set; }
        public AssemblyCompilationErrorsException(CompilerErrorCollection errors)
        {
            Errors = errors;
        }
    }
}
