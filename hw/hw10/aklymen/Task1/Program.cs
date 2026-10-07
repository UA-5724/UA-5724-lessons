using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace hw10.Task1
{
    class Program
    {
        static void Main()
        {

            List<Shape> shapes = new List<Shape>()
        {
            new Circle("Circle", 2),
            new Circle("SquareLike", 4),
            new Circle("Ball", 5),
            new Square("Square", 3),
            new Square("Triangle", 4),
            new Square("Rectangle", 6)
        };


            // Find shapes with area in range [10, 100]

            var shapesByArea = shapes
                .Where(shape => shape.Area() >= 10 && shape.Area() <= 100)
                .ToList();

            File.WriteAllLines(
                "ShapesByArea.txt",
                shapesByArea.Select(shape => shape.ToString()));

            Console.WriteLine("Shapes with area from 10 to 100 saved to ShapesByArea.txt.");


            // Find shapes whose name contains letter 'a'

            var shapesByName = shapes
                .Where(shape => shape.Name.ToLower().Contains("a"))
                .ToList();

            File.WriteAllLines(
                "ShapesWithA.txt",
                shapesByName.Select(shape => shape.ToString()));

            Console.WriteLine("Shapes with letter 'a' saved to ShapesWithA.txt.");


            // Remove shapes with perimeter < 5

            for (int index = shapes.Count - 1; index >= 0; index--)
            {
                if (shapes[index].Perimeter() < 5)
                {
                    shapes.RemoveAt(index);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Shapes after removing perimeter < 5:");

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);
            }

            Console.WriteLine();
        }
    }
}