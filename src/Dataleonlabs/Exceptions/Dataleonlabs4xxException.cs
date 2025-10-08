using System.Net.Http;

namespace Dataleonlabs.Exceptions;

public class Dataleonlabs4xxException : DataleonlabsApiException
{
    public Dataleonlabs4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
