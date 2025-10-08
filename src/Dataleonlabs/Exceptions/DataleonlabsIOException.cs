using System;
using System.Net.Http;

namespace Dataleonlabs.Exceptions;

public class DataleonlabsIOException : DataleonlabsException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public DataleonlabsIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
