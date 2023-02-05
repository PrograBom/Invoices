using System.Runtime.Serialization;

namespace Invoices.Exceptions;

public class TextsException : Exception
{
    
    public const string NoItemExceptionText = "There is no item in the database. Create one.";

    public TextsException()
    {
    }

    public TextsException(string message) : base(message)
    {
    }

    public TextsException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected TextsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
