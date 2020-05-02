using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

[TestFixture]
public class TestsWithDecoratedHttpClient
{
    private static Lazy<HttpClient> Client = new Lazy<HttpClient>(() => {
        var client = HttpClientFactory.Create(new ConsoleDelegatingHandler());
        client.BaseAddress = new Uri("https://postman-echo.com/");
        client.DefaultRequestHeaders.Accept.Clear();
        return client;
    });

    [Test]
    public async Task test_with_decorative_call_to_http_client()
    {
        var response = await Client.Value.GetAsync("/get?name=Todd");
        var echo = await response.Content.ReadAsAsync<EchoResponse>();
        
        echo.Args.Name.Should().Be("Todd");
        echo.Url.Should().Be("https://postman-echo.com/get?name=Todd");
    }

    [Test]
    public async Task test_with_decorative_call_to_http_client_too()
    {
        var response = await Client.Value.GetAsync("/get?name=Todd");
        var echo = await response.Content.ReadAsAsync<EchoResponse>();
        
        echo.Args.Name.Should().Be("Todd");
        echo.Url.Should().Be("https://postman-echo.com/get?name=Todd");
    }

    public class EchoResponse
    {
        public EchoArgs Args { get; set;}
        public string Url { get; set; }

        public class EchoArgs
        {
            public string Name { get; set;}
        }
    }
}
