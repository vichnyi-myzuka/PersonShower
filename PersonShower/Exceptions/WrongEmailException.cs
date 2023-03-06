using System;

namespace PersonShower.Exceptions;

public class WrongEmailException: Exception
{
    public WrongEmailException()
    {
    }

    public WrongEmailException(string message)
        : base(message)
    {
    }

    public WrongEmailException(string message, Exception inner)
        : base(message, inner)
    {
    }
}