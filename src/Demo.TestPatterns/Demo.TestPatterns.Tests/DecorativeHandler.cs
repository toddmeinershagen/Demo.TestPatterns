using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

public class DecorativeHandler : DelegatingHandler
{
    protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
    {
        var methodName = TestContext.CurrentContext.Test.Name;
        var httpMethod = requestMessage.Method;
        var requestUriString = requestMessage.RequestUri.ToString();

        await Console.Out.WriteLineAsync($"{methodName}:  Before the {httpMethod} call to {requestUriString}.");
        var response = await base.SendAsync(requestMessage, cancellationToken);
        await Console.Out.WriteLineAsync($"{methodName}:  After the {httpMethod} call to {requestUriString}.");
        
        return response;
    }
}