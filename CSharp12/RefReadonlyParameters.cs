namespace CSharp12;

internal class RefReadonlyParameters
{
    public static void Test(ref readonly int age) // same as 'in int age'
    {
        Console.WriteLine($"The age is: {age}");
    }
}
