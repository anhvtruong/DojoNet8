namespace CSharp12;

internal class DefaultLambdaParameters
{
    public static void Test()
    {
        var process = (string name = "default") =>
        {
            Console.WriteLine($"Running: {name} process...");
        };

        process("core"); // Running: core process...
        process(); // Running: default process...
    }
}
