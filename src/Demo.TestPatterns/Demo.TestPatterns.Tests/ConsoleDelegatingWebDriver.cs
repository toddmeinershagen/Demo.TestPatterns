using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

public class ConsoleDelegatingWebDriver : DelegatingWebDriver
{
    protected override T HandleAction<T>(MethodBase methodInfo, Func<T> function)
    {
        var testMethod = TestContext.CurrentContext.Test.Name;
        var methodSignature = $"{methodInfo.Name}({methodInfo.GetParameters().FirstOrDefault()?.ToString()})";
        T result = default(T);

        try
        {
            Console.WriteLine($"{testMethod}:{methodSignature}:OnEnter");
            result = function();
            Console.WriteLine($"{testMethod}:{methodSignature}:OnExit");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{testMethod}:{methodSignature}:Exception  {ex.StackTrace}");
        }
            
        return result;            
    }
}