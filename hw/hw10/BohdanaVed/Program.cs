using System.Text.Json;
using System.Text.RegularExpressions;

namespace HW10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }

        static void Task1()
        {
            Console.WriteLine("Task 1: Shapes, LINQ and files");

            List<Shape> shapes = new List<Shape>
            {
                new Circle("Small circle", 0.5),
                new Circle("Alpha circle", 2),
                new Circle("Big circle", 5),
                new Square("Tiny square", 1),
                new Square("Beta square", 4),
                new Square("Large square", 9)
            };

            List<Shape> byArea = shapes
                .Where(shape => shape.Area() >= 10 && shape.Area() <= 100)
                .ToList();

            File.WriteAllLines("shapes-by-area.txt", byArea.Select(shape => shape.ToString()));
            Console.WriteLine(byArea.Count + " shapes with the area in [10, 100] were saved to " + Path.GetFullPath("shapes-by-area.txt"));

            List<Shape> withLetterA = shapes
                .Where(shape => shape.Name.ToLower().Contains("a"))
                .ToList();

            File.WriteAllLines("shapes-with-a.txt", withLetterA.Select(shape => shape.ToString()));
            Console.WriteLine(withLetterA.Count + " shapes with the letter 'a' in the name were saved to " + Path.GetFullPath("shapes-with-a.txt"));

            shapes.RemoveAll(shape => shape.Perimeter() < 5);

            Console.WriteLine("The shapes with the perimeter not less than 5:");
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape);
            }

            Console.WriteLine();
        }

        static void Task2()
        {
            Console.WriteLine("Task 2: Text processing with LINQ");

            string fileName = "text.txt";

            if (!File.Exists(fileName))
            {
                Console.WriteLine("The file " + fileName + " was not found");
                Console.WriteLine();
                return;
            }

            string[] lines = File.ReadAllLines(fileName);

            if (lines.Length == 0)
            {
                Console.WriteLine("The file " + fileName + " is empty");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("The number of characters in every line:");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine("line " + (i + 1) + ": " + lines[i].Length + " characters");
            }

            string longest = lines.OrderByDescending(line => line.Length).First();
            string shortest = lines.OrderBy(line => line.Length).First();

            Console.WriteLine("The longest line has " + longest.Length + " characters: " + longest);
            Console.WriteLine("The shortest line has " + shortest.Length + " characters: " + shortest);

            List<string> withVar = lines
                .Where(line => Regex.IsMatch(line, @"\bvar\b"))
                .ToList();

            Console.WriteLine("The lines that contain the word var (" + withVar.Count + "):");
            foreach (string line in withVar)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine();
        }

        static void Task3()
        {
            Console.WriteLine("Task 3: Delegates and events");

            Student student = new Student("Anna");
            Parent parent = new Parent();
            Accountancy accountancy = new Accountancy();

            student.MarkChange += parent.OnMarkChange;
            student.MarkChange += accountancy.PayingFellowship;

            student.AddMark(5);
            student.AddMark(3);
            student.AddMark(4);

            Console.WriteLine(student);
            Console.WriteLine();
        }

        static void Task4()
        {
            Console.WriteLine("Task 4: JSON serialization");

            Student student = new Student("Anna");
            student.AddMark(5);
            student.AddMark(4);
            student.AddMark(3);

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;

            string json = JsonSerializer.Serialize(student, options);
            File.WriteAllText("student.json", json);

            Console.WriteLine("The student was serialized to " + Path.GetFullPath("student.json"));
            Console.WriteLine(json);

            Student restored = JsonSerializer.Deserialize<Student>(File.ReadAllText("student.json"));

            Console.WriteLine("The student was restored from the file:");
            Console.WriteLine(restored);
        }
    }
}
