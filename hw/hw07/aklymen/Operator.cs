namespace hw07
{
    class Operator
    {
        public static void GetInfo(List<Shape> shapes)
        {
            Console.WriteLine("Shape information:");

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(
                    $"Name: {shape.Name}, Area: {shape.Area():F2}, Perimeter: {shape.Perimeter():F2}");
            }
        }

        public static void GetLargestPerimeter(List<Shape> shapes)
        {
            Shape largest = shapes[0];

            for (int index = 1; index < shapes.Count; index++)
            {
                if (shapes[index].Perimeter() > largest.Perimeter())
                {
                    largest = shapes[index];
                }
            }

            Console.WriteLine(
                $"Shape with largest perimeter: {largest.Name}");
        }

        public static void Sort(List<Shape> shapes)
        {
            shapes.Sort();

            Console.WriteLine("Shapes sorted by area:");

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(
                    $"{shape.Name} - Area: {shape.Area():F2}");
            }
        }
    }
}
