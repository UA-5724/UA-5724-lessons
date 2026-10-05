using System;

namespace hw09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(3, 0);
            Point p3 = new Point(0, 4);

            Point p4 = new Point(5, 5);
            Point p5 = new Point(7, 5);
            Point p6 = new Point(5, 8);

            Point p7 = new Point(1, 1);
            Point p8 = new Point(2, 1);
            Point p9 = new Point(1, 3);

            Triangle triangle1 =
                new Triangle(p1, p2, p3);

            Triangle triangle2 =
                new Triangle(p4, p5, p6);

            Triangle triangle3 =
                new Triangle(p7, p8, p9);

            ShapeGroup group = new ShapeGroup();

            group.AddTriangle(triangle1);
            group.AddTriangle(triangle2);
            group.AddTriangle(triangle3);

            Console.WriteLine("All triangles:");
            Console.WriteLine();

            foreach (Triangle triangle in group.GetAll())
            {
                triangle.Print();
                Console.WriteLine();
            }

            Triangle? closestTriangle =
                group.FindTriangleClosestToOrigin();

            if (closestTriangle != null)
            {
                Console.WriteLine(
                    "Triangle with the vertex closest to origin:"
                );

                closestTriangle.Print();
            }
        }
    }
}