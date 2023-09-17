namespace Smarty.Net.Core.Apis.Shared.Exceptions;

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