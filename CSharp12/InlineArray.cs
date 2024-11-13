namespace CSharp12;

[System.Runtime.CompilerServices.InlineArray(8)]
internal struct Buffer
{
    private byte _element0;
}

internal class InlineArray
{
    public static void Test()
    {
        var buffer = new Buffer();
        for (int i = 0; i < 8; i++)
        {
            buffer[i] = Convert.ToByte(i);
        }

        foreach (var i in buffer)
        {
            Console.WriteLine(i);
        }
    }
}