using System;

namespace PersonShower.Exceptions;

public class FutureBirthException: Exception
{
    public FutureBirthException()
    {
    }

    public FutureBirthException(string message)
        : base(message)
    {
    }

    public FutureBirthException(string message, Exception inner)
        : base(message, inner)
    {
    }
}