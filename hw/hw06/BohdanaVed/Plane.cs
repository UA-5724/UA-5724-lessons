namespace HW6
{
    internal class Plane : IFlyable
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
            Console.WriteLine("The plane " + mark + " is flying at the height of " + highFly + " meters");
        }
    }
}
