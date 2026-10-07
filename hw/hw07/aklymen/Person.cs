namespace hw07
{
    class Person : IComparable<Person>
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Person()
        {
            name = "";
        }

        public Person(string name)
        {
            this.name = name;
        }

        public virtual void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Name: {name}";
        }

        public int CompareTo(Person other)
        {
            return name.CompareTo(other.name);
        }
    }


}
