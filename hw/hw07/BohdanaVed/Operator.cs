namespace HW7
{
    internal class Operator
    {
        public static void GetInfo(List<Shape> shapes)
        {
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.Name
                    + ": area = " + Math.Round(shape.Area(), 2)
                    + ", perimeter = " + Math.Round(shape.Perimeter(), 2));
            }
        }

        public static void GetLargestPerimeter(List<Shape> shapes)
        {
            if (shapes.Count == 0)
            {
                Console.WriteLine("The list of shapes is empty");
                return;
            }

            Shape largest = shapes[0];
            foreach (Shape shape in shapes)
            {
                if (shape.Perimeter() > largest.Perimeter())
                {
                    largest = shape;
                }
            }

            Console.WriteLine("The largest perimeter belongs to " + largest.Name);
        }

        public static void Sort(List<Shape> shapes)
        {
            shapes.Sort();

            Console.WriteLine("The shapes sorted by area:");
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.Name);
            }
        }
    }
}
