namespace ConsoleApp1
{
    class Bird : IFlyable
    {
        private string name;
        private bool canFly;

        public Bird(string name, bool canFly)
        {
            this.name = name;
            this.canFly = canFly;
        }

        public void Fly()
        {
            if (canFly)
            {
                Console.WriteLine($"{name} can fly.");
            }
            else
            {
                Console.WriteLine($"{name} cannot fly.");
            }
        }
    }
}
