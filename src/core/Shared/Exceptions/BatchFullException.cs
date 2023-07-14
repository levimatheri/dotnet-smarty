namespace Smarty.Net.Core.Shared.Exceptions;

public class BatchFullException : SmartyException
{
    public BatchFullException()
    {
    }

    public BatchFullException(string message)
        : base(message)
    {
    }
}