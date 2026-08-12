namespace HW5
{
    internal class Car
    {
        public const string CompanyName = "AutoHouse";

        private string name;
        private string color;
        private double price;

        public Car()
        {
            name = "unknown";
            color = "unknown";
            price = 0;
        }

        public Car(string name, string color, double price)
        {
            this.name = name;
            this.color = color;
            this.price = price;
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public void Input()
        {
            Console.Write("Enter the name of the car: ");
            name = Console.ReadLine();

            Console.Write("Enter the color of the car: ");
            color = Console.ReadLine();

            Console.Write("Enter the price of the car: ");
            while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.Write("Wrong price, enter it again: ");
            }
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public void ChangePrice(double x)
        {
            price = price + price * x / 100;
        }

        public override string ToString()
        {
            return "Company: " + CompanyName + ", name: " + name + ", color: " + color + ", price: " + price;
        }

        public static bool operator ==(Car a, Car b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.name == b.name && a.price == b.price;
        }

        public static bool operator !=(Car a, Car b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return this == obj as Car;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, price);
        }
    }
}
