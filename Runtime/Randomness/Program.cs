using System.Drawing;

ReadOnlySpan<Color> colors = new[]
{
    Color.Red,
    Color.Green,
    Color.Blue,
    Color.Yellow,
};


var items = Random.Shared.GetItems([1, 2, 3, 4, 5, 6, 7, 8], 5);
// items: int[5] [3, 8, 1, 5, 1]

Random.Shared.Shuffle(items);
// items: int[5] [5, 1, 1, 3, 8]


Console.ReadLine();