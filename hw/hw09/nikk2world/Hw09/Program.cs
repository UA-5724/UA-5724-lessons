namespace Hw09;

class Program
{
    static void Main()
    {
        // Triangles are created independently of the group (aggregation)
        Triangle triangle1 = new Triangle(new Point(1, 1), new Point(4, 1), new Point(1, 5));
        Triangle triangle2 = new Triangle(new Point(-3, -2), new Point(-1, -6), new Point(-5, -4));
        Triangle triangle3 = new Triangle(new Point(0.5, 0.5), new Point(3, 2), new Point(2, 4));

        ShapeGroup group = new ShapeGroup();
        group.AddTriangle(triangle1);
        group.AddTriangle(triangle2);
        group.AddTriangle(triangle3);

        Console.WriteLine("All triangles:");
        foreach (Triangle triangle in group.GetAll())
        {
            triangle.Print();
        }

        Triangle? closest = group.FindTriangleClosestToOrigin();

        Console.WriteLine("\nTriangle with vertex closest to (0,0):");
        if (closest != null)
            closest.Print();
        else
            Console.WriteLine("The group is empty.");

        // Bonus: collinear points are rejected
        try
        {
            new Triangle(new Point(0, 0), new Point(1, 1), new Point(2, 2));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"\nInvalid triangle: {ex.Message}");
        }
    }
}
