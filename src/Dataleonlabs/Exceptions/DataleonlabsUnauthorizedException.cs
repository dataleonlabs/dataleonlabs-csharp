using System.Net.Http;

namespace Dataleonlabs.Exceptions;

public class DataleonlabsUnauthorizedException : Dataleonlabs4xxException
{
    public DataleonlabsUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
