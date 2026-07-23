using System;
interface IFlyable
{
    void Fly();
}

class Bird : IFlyable
{
    // bird fields
    private string name = "";
    private bool canFly;
    //constructor with parameters
    public Bird(string name, bool canFly)
    {
        this.name = name;
        this.canFly = canFly;
    }
    //display bird flying info
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
class Plane : IFlyable
{
    // plane fields
    private string mark = "";
    private int highFly;
    //constructor with parameters
    public Plane(string mark, int highFly)
    {
        this.mark = mark;
        this.highFly = highFly;
    }
    //display plane flying info
    public void Fly()
    {
        Console.WriteLine($"{mark} is flying at an altitude of {highFly} meters.");
    }
}
class Program
{
    static void Main()
    {

        // сreate a list of flying objects
        List<IFlyable> items = new List<IFlyable>()
        {
            //фdd birds and planes to the list
            new Bird("Eagle", true),
            new Bird("Penguin", false),
            new Plane("Boeing", 10000)
        };
        //сall Fly() for every object
        foreach (var item in items)
        {
            item.Fly();
        }
    }
}
