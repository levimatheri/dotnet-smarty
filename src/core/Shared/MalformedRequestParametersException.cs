using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarty.Net.Core.Shared;
public class MalformedRequestParametersException : Exception
{
    public MalformedRequestParametersException()
    {
    }

    public MalformedRequestParametersException(string message)
        : base(message)
    {
    }

    public MalformedRequestParametersException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
