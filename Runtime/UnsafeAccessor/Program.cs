using System.Runtime.CompilerServices;

var example = new Example();

ref string privateField = ref Service.GetSetPrivateField(example);

var privateMethod = Service.GetPrivateMethod(example);

Console.WriteLine();

public class Service
{
    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_privateField")]
    public static extern ref string GetSetPrivateField(Example example);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "PrivateMethod")]
    public static extern string GetPrivateMethod(Example example);
}

public class Example
{
    private string _privateField = "private field";

    private string PrivateMethod()
    {
        return "private method";
    }
}