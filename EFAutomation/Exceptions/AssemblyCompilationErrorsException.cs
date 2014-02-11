using System;
using System.CodeDom.Compiler;

namespace EFConventions.Exceptions
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
