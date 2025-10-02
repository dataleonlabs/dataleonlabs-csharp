using System.Net.Http;

namespace Dataleonlabs.Exceptions;

public class Dataleonlabs5xxException : DataleonlabsApiException
{
    public Dataleonlabs5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
