using System.Net.Http;

namespace Dataleonlabs.Exceptions;

public class DataleonlabsUnexpectedStatusCodeException : DataleonlabsApiException
{
    public DataleonlabsUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
