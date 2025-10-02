using System.Net.Http;

namespace Dataleonlabs.Exceptions;

public class DataleonlabsForbiddenException : Dataleonlabs4xxException
{
    public DataleonlabsForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
