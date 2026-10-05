namespace HW9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Triangle first = new Triangle(new Point(3, 4), new Point(6, 8), new Point(3, 8));
            Triangle second = new Triangle(new Point(0, 1), new Point(2, 1), new Point(0, 3));
            Triangle third = new Triangle(new Point(10, 10), new Point(14, 10), new Point(10, 13));

            ShapeGroup group = new ShapeGroup();
            group.AddTriangle(first);
            group.AddTriangle(second);
            group.AddTriangle(third);

            Console.WriteLine("All the triangles of the group:");
            foreach (Triangle triangle in group.GetAll())
            {
                triangle.Print();
            }

            Console.WriteLine();
            Console.WriteLine("Triangle with vertex closest to (0,0):");
            Triangle closest = group.FindTriangleClosestToOrigin();
            closest.Print();

            Console.WriteLine();
            Console.WriteLine("Aggregation: the third triangle is removed from the group");
            group.RemoveTriangle(third);
            Console.WriteLine("The group has " + group.Count + " triangles now");
            Console.WriteLine("The removed triangle still exists on its own:");
            third.Print();
        }
    }
}
