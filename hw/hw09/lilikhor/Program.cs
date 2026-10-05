namespace Program_9._1
{
    class Program
    {
        static void Main()
        {
            Triangle triangle1 = new Triangle(
                new Point(1, 1),
                new Point(4, 1),
                new Point(1, 5)
            );

            Triangle triangle2 = new Triangle(
                new Point(10, 10),
                new Point(13, 10),
                new Point(10, 14)
            );

            Triangle triangle3 = new Triangle(
                new Point(-2, 1),
                new Point(-5, 1),
                new Point(-2, 4)
            );

            ShapeGroup shapeGroup = new ShapeGroup();

            shapeGroup.AddTriangle(triangle1);
            shapeGroup.AddTriangle(triangle2);
            shapeGroup.AddTriangle(triangle3);

            Console.WriteLine("All triangles:");
            Console.WriteLine();

            foreach (Triangle triangle in shapeGroup.GetAll())
            {
                triangle.Print();
                Console.WriteLine();
            }

            Triangle? closestTriangle =
                shapeGroup.FindTriangleClosestToOrigin();

            Console.WriteLine("Triangle with vertex closest to (0,0):");

            closestTriangle?.Print();
        }
    }
}
