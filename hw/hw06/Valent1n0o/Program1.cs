using System;
using System.Collections.Generic;

namespace hw06
{
    interface IFlyable
    {
        void Fly();
    }

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
                Console.WriteLine($"Bird {name} can fly.");
            }
            else
            {
                Console.WriteLine($"Bird {name} cannot fly.");
            }
        }
    }

    class Plane : IFlyable
    {
        private string mark;
        private bool highFly;

        public Plane(string mark, bool highFly)
        {
            this.mark = mark;
            this.highFly = highFly;
        }

        public void Fly()
        {
            if (highFly)
            {
                Console.WriteLine($"Plane {mark} flies high.");
            }
            else
            {
                Console.WriteLine($"Plane {mark} flies at a low altitude.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<IFlyable> flyableObjects = new List<IFlyable>
            {
                new Bird("Crane", true),
                new Bird("Rooster", false),
                new Plane("Mriya", true),
                new Plane("Liutyy", false)
            };

            foreach (IFlyable item in flyableObjects)
            {
                item.Fly();
            }
        }
    }
}