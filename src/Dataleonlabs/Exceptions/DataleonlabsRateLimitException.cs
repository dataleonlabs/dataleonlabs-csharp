using System.Net.Http;

namespace Dataleonlabs.Exceptions;

public class DataleonlabsRateLimitException : Dataleonlabs4xxException
{
    public DataleonlabsRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
