namespace CSharp12;

internal class PrimaryConstructor(string name, int value)
{
    public string Name { get; } = name;

    public int Value { get; } = value;
}

internal class DependencyInjection(IService service)
{
    public void Test()
    {
        service.Test();
    }
}

interface IService
{
    void Test();
}
