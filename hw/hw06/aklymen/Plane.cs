namespace ConsoleApp1
{
    class Plane : IFlyable
    {
        private string mark;
        private int highFly;

        public Plane(string mark, int highFly)
        {
            this.mark = mark;
            this.highFly = highFly;
        }

        public void Fly()
        {
            Console.WriteLine($"{mark} can fly at {highFly} meters.");
        }
    }

}
