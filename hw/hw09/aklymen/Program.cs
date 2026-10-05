namespace hw09
{
    class Program
    {
        static void Main()
        {
            // 1. Create Points

            Point point1 = new Point(0, 0);
            Point point2 = new Point(3, 0);
            Point point3 = new Point(0, 4);

            Point point4 = new Point(1, 1);
            Point point5 = new Point(5, 1);
            Point point6 = new Point(1, 4);

            Point point7 = new Point(-2, -2);
            Point point8 = new Point(-5, -2);
            Point point9 = new Point(-2, -6);


            // 2. Create Triangles

            Triangle triangle1 = new Triangle(point1, point2, point3);
            Triangle triangle2 = new Triangle(point4, point5, point6);
            Triangle triangle3 = new Triangle(point7, point8, point9);


            // 3. Create ShapeGroup

            ShapeGroup group = new ShapeGroup();

            group.AddTriangle(triangle1);
            group.AddTriangle(triangle2);
            group.AddTriangle(triangle3);


            // 4. Print all triangles

            Console.WriteLine("All triangles:");

            foreach (Triangle triangle in group.GetAll())
            {
                triangle.Print();
                Console.WriteLine();
            }


            // 5. Find triangle closest to origin

            Triangle closestTriangle = group.FindTriangleClosestToOrigin();

            if (closestTriangle != null)
            {
                Console.WriteLine("Triangle with vertex closest to (0,0):");
                closestTriangle.Print();

                Console.WriteLine(
                    $"Closest vertex: {closestTriangle.GetClosestVertexToOrigin()}");
            }
            else
            {
                Console.WriteLine("Triangle group is empty.");
            }
        }
    }
}