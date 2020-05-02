using System;
using System.Reflection;

public class NoOpDelegatingWebDriver : DelegatingWebDriver
{
    protected override T HandleAction<T>(MethodBase methodInfo, Func<T> function)
    {
        return function();
    }
}