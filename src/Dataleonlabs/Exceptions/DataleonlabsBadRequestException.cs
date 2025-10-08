using System.Net.Http;

namespace Dataleonlabs.Exceptions;

public class DataleonlabsBadRequestException : Dataleonlabs4xxException
{
    public DataleonlabsBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
