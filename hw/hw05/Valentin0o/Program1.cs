using System;

namespace hw05
{
    internal class Car
    {
        private string name;
        private string color;
        private double price;

        public const string CompanyName = "ZAZ";

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public Car()
        {
            name = string.Empty;
            color = string.Empty;
            price = 0;
        }

        public Car(string name, string color, double price)
        {
            this.name = name;
            this.color = color;
            this.price = price;
        }

        public void Input()
        {
            Console.Write("Enter car name: ");
            name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter car color: ");
            color = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter car price: ");
            while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.Write("Enter a valid non-negative price: ");
            }
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public void ChangePrice(double percent)
        {
            price += price * percent / 100;
        }

        public static bool operator ==(Car? first, Car? second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (first is null || second is null)
            {
                return false;
            }

            return first.name == second.name &&
                   first.price == second.price;
        }

        public static bool operator !=(Car? first, Car? second)
        {
            return !(first == second);
        }

        public override bool Equals(object? obj)
        {
            return obj is Car other && this == other;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, price);
        }

        public override string ToString()
        {
            return $"Name: {name}, Color: {color}, Price: {price:F2}, " +
                   $"Company: {CompanyName}";
        }
    }

    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("THIS IS MY PROGRAM");
            const int carCount = 3;
            const double discountPercent = -10;
            const string colorToReplace = "white";

            Car[] cars = new Car[carCount];

            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine($"\nEnter data for car {i + 1}:");

                cars[i] = new Car();
                cars[i].Input();
            }

            Console.WriteLine("\nCars before price change:");

            foreach (Car car in cars)
            {
                car.Print();
            }

            foreach (Car car in cars)
            {
                car.ChangePrice(discountPercent);
            }

            Console.WriteLine("\nCars after decreasing price by 10%:");

            foreach (Car car in cars)
            {
                car.Print();
            }

            Console.Write("\nEnter a new color for white cars: ");
            string newColor = Console.ReadLine() ?? string.Empty;

            foreach (Car car in cars)
            {
                if (car.Color.Equals(
                    colorToReplace,
                    StringComparison.OrdinalIgnoreCase))
                {
                    car.Color = newColor;
                }
            }

            Console.WriteLine("\nCars after repainting:");

            foreach (Car car in cars)
            {
                car.Print();
            }

            Console.WriteLine("\nComparison of cars:");

            for (int i = 0; i < cars.Length; i++)
            {
                for (int j = i + 1; j < cars.Length; j++)
                {
                    Console.WriteLine(
                        $"Car {i + 1} == Car {j + 1}: {cars[i] == cars[j]}"
                    );
                }
            }
        }
    }
}