namespace HW6
{
    internal class Bird : IFlyable
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
                Console.WriteLine("The bird " + name + " is flying in the sky");
            }
            else
            {
                Console.WriteLine("The bird " + name + " cannot fly");
            }
        }
    }
}
