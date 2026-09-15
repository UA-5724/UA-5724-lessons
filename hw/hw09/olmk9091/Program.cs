using System;

class Program
{
    static void Main()
    {
        // Create points for the first triangle
        Point p1 = new Point(0, 0);
        Point p2 = new Point(3, 0);
        Point p3 = new Point(0, 4);

        // Create points for the second triangle
        Point p4 = new Point(5, 5);
        Point p5 = new Point(7, 5);
        Point p6 = new Point(5, 7);

        // Create points for the third triangle
        Point p7 = new Point(2, 1);
        Point p8 = new Point(4, 1);
        Point p9 = new Point(2, 3);

        // Create three independent triangles
        Triangle triangle1 = new Triangle(p1, p2, p3);
        Triangle triangle2 = new Triangle(p4, p5, p6);
        Triangle triangle3 = new Triangle(p7, p8, p9);

        // Create a group of triangles
        ShapeGroup group = new ShapeGroup();

        // Add the triangles to the group
        group.AddTriangle(triangle1);
        group.AddTriangle(triangle2);
        group.AddTriangle(triangle3);

        Console.WriteLine("All triangles:");
        Console.WriteLine();

        // Print all triangles
        foreach (Triangle triangle in group.GetAll())
        {
            triangle.Print();
            Console.WriteLine();
        }

        // Find the triangle with the vertex closest to the origin
        Triangle? closest =
            group.FindTriangleClosestToOrigin();

        if (closest != null)
        {
            Console.WriteLine(
                "Triangle with vertex closest to (0,0):");

            closest.Print();
        }

        // Remove the third triangle from the group
        group.RemoveTriangle(triangle3);

        Console.WriteLine("\nTriangles after removing triangle3:");

        // Display triangles that remain in the group
        foreach (Triangle triangle in group.GetAll())
        {
            triangle.Print();
            Console.WriteLine();
        }

        // Demonstrate aggregation:
        // triangle3 still exists independently of ShapeGroup
        Console.WriteLine("Removed triangle still exists:");
        triangle3.Print();
    }
}