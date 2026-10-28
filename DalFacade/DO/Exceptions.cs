
namespace DO;

public class ExistsIdExceptions:Exception
{
    public ExistsIdExceptions(string message) : base(message) { }
    public ExistsIdExceptions(string message,Exception innerException) : base(message, innerException) { }
}

public class NotExistsExceptions : Exception
{
    public NotExistsExceptions(string message) : base(message) { }
    public NotExistsExceptions(string message, Exception innerException) : base(message, innerException) { }
}
