namespace hw05
{
    class Car
    {
        private string name;
        private string color;
        private double price;

        public const string CompanyName = "My Car Company";

        // Property
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        // Default constructor
        public Car()
        {
            name = "";
            color = "";
            price = 0;
        }

        // Constructor with parameters
        public Car(string name, string color, double price)
        {
            this.name = name;
            this.color = color;
            this.price = price;
        }

        // Input
        public void Input()
        {
            Console.Write("Enter car name: ");
            name = Console.ReadLine() ?? "";

            Console.Write("Enter car color: ");
            color = Console.ReadLine() ?? "";

            Console.Write("Enter car price: ");
            price = double.Parse(Console.ReadLine());
        }

        // Print
        public void Print()
        {
            Console.WriteLine(
                $"Name: {name}, Color: {color}, Price: {price}");
        }

        // Change price
        public void ChangePrice(double x)
        {
            price = price + price * x / 100;
        }

        // Operator ==
        public static bool operator ==(Car a, Car b)
        {
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null || b == null)
            {
                return false;
            }

            return a.name == b.name && a.price == b.price;
        }

        // Operator !=
        public static bool operator !=(Car a, Car b)
        {
            return !(a == b);
        }

        // Equals
        public override bool Equals(object obj)
        {
            if (obj is Car)
            {
                Car other = (Car)obj;
                return this == other;
            }

            return false;
        }

        // GetHashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(name, price);
        }

        // ToString
        public override string ToString()
        {
            return $"Name: {name}, Color: {color}, Price: {price}";
        }
    }
}
