using System;
using Dataleonlabs;

namespace Dataleonlabs.Tests;

public class TestBase
{
    protected IDataleonlabsClient client;

    public TestBase()
    {
        client = new DataleonlabsClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}
