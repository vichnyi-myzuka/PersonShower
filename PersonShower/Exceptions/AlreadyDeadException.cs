using System;

namespace PersonShower.Exceptions;

public class AlreadyDeadException: Exception
{
    public AlreadyDeadException()
    {
    }

    public AlreadyDeadException(string message)
        : base(message)
    {
    }

    public AlreadyDeadException(string message, Exception inner)
        : base(message, inner)
    {
    }
}