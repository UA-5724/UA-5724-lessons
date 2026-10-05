using System;
using System.Collections.Generic;

namespace hw07
{
    abstract class Shape : IComparable<Shape>
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Shape(string name)
        {
            this.name = name;
        }

        public abstract double Area();

        public abstract double Perimeter();

        public int CompareTo(Shape? other)
        {
            if (other == null)
            {
                return 1;
            }

            return Area().CompareTo(other.Area());
        }
    }

    class Circle : Shape
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public Circle(string name, double radius)
            : base(name)
        {
            this.radius = radius;
        }

        public override double Area()
        {
            return Math.PI * radius * radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * radius;
        }
    }

    class Square : Shape
    {
        private double side;

        public double Side
        {
            get { return side; }
            set { side = value; }
        }

        public Square(string name, double side)
            : base(name)
        {
            this.side = side;
        }

        public override double Area()
        {
            return side * side;
        }

        public override double Perimeter()
        {
            return 4 * side;
        }
    }

    static class Operator
    {
        public static void GetInfo(List<Shape> shapes)
        {
            Console.WriteLine("Shape information:");

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(
                    $"Name: {shape.Name}, " +
                    $"Area: {shape.Area():F2}, " +
                    $"Perimeter: {shape.Perimeter():F2}"
                );
            }
        }

        public static void GetLargestPerimeter(List<Shape> shapes)
        {
            if (shapes.Count == 0)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            Shape largestShape = shapes[0];

            foreach (Shape shape in shapes)
            {
                if (shape.Perimeter() > largestShape.Perimeter())
                {
                    largestShape = shape;
                }
            }

            Console.WriteLine(
                $"\nShape with the largest perimeter: {largestShape.Name}"
            );
        }

        public static void Sort(List<Shape> shapes)
        {
            shapes.Sort();

            Console.WriteLine("\nShapes sorted by area:");

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(
                    $"{shape.Name} - Area: {shape.Area():F2}"
                );
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>
            {
                new Circle("Circle1", 5),
                new Square("Square1", 4),
                new Circle("Circle2", 3),
                new Square("Square2", 2)
            };

            Operator.GetInfo(shapes);

            Operator.GetLargestPerimeter(shapes);

            Operator.Sort(shapes);
        }
    }
}