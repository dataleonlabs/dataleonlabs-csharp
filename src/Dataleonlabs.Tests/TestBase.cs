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
            BaseUrl = new Uri(
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010"
            ),
            APIKey = "My API Key",
        };
    }
}
