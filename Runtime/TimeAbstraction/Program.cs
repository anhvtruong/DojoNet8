using TimeAbstraction;

Console.WriteLine("Hello .NET 8!");

var service = new ServiceA(TimeProvider.System);

await service.MethodA();