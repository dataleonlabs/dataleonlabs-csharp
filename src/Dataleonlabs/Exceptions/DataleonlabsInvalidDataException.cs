using System;

namespace Dataleonlabs.Exceptions;

public class DataleonlabsInvalidDataException : DataleonlabsException
{
    public DataleonlabsInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
