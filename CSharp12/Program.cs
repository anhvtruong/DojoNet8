using CSharp12;

Console.WriteLine("Hello .NET 8!");

InlineArray.Test();

#pragma warning disable PoC // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
var x = new ExperimentalAttributeClass();
#pragma warning restore PoC // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

#region Interceptors

ExampleClass.Test(); // Print from ExampleClass.
ExampleClass.Test(); // Replaced by Interceptor.
ExampleClass.Test(); // Replaced by Interceptor.

#endregion

var age = 18;
RefReadonlyParameters.Test(ref age);

DefaultLambdaParameters.Test();