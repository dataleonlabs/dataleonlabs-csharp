using System.Net.Http;

namespace Dataleonlabs.Exceptions;

public class DataleonlabsNotFoundException : Dataleonlabs4xxException
{
    public DataleonlabsNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
