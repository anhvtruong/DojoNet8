namespace CSharp12;

using Point3d = (int X, int Y, int Z); // alias any type
using List2d = List<List<ExtremeLongClassName>>;

public class AliasAnyType()
{
    public static void Test()
    {
        Console.WriteLine(typeof(Point3d));
        Console.WriteLine(nameof(Point3d));

        Point3d point = (42, 43, 44);
        point.Y = 0;
        Console.WriteLine(point);
    }
}

class ExtremeLongClassName()
{

}