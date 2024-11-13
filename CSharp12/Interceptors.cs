using System.Runtime.CompilerServices;

namespace CSharp12;

public class ExampleClass()
{
    public static void Test()
    {
        Console.WriteLine($"Print from {nameof(ExampleClass)}.");
    }
}

public static class Interceptors
{
    [InterceptsLocation(filePath: "Program.cs", line: 14, character: 14)]
    [InterceptsLocation(filePath: "Program.cs", line: 15, character: 14)]
    public static void InterceptMethodTest() // replace at compile time -> Source generators
    {
        Console.WriteLine("Replaced by Interceptor.");
    }
}