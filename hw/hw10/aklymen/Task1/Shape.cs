namespace hw10.Task1
{
    abstract class Shape
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Shape(string name)
        {
            this.name = name;
        }

        public abstract double Area();

        public abstract double Perimeter();

        public override string ToString()
        {
            return $"Name: {Name}, Area: {Area():F2}, Perimeter: {Perimeter():F2}";
        }
    }
}
