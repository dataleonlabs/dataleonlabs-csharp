using System.Net.Http;

namespace Dataleonlabs.Exceptions;

public class DataleonlabsUnprocessableEntityException : Dataleonlabs4xxException
{
    public DataleonlabsUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
