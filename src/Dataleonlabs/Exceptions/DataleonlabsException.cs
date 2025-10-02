using System;
using System.Net.Http;

namespace Dataleonlabs.Exceptions;

public class DataleonlabsException : Exception
{
    public DataleonlabsException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected DataleonlabsException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
