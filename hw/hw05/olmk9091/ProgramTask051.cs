using System;
class Car 
{ 
    private string name = ""; 
    private string color = ""; 
    private double price; 
    //company Name for all cars
    private const string CompanyName = "BMW"; 
    //default constructor
    public Car() 
    { 
    } 
    //constructor with parameters
    public Car(string name, string color, double price) 
    { 
        //Initialize object fields
        this.name = name; 
        this.color = color; 
        this.price = price; 
    } 
    //property for the car color
    public string Color 
    { 
        get 
        { 
            //return the current color
            return color; 
        } 
        set 
        { 
            //check that the value is not null or empty
            if (!string.IsNullOrWhiteSpace(value)) 
            { 
                //set a new color
                color = value; 
            } 
        } 
    } 
    public void Input() 
    { 
        //read car data from console
        name = Console.ReadLine()!; 
        color = Console.ReadLine()!; 
        price = double.Parse(Console.ReadLine()!); 
    } 
    //display car info
    public void Print() 
    { 
        Console.WriteLine(ToString()); 
    } 
    //increase the car price by the given %
    public void ChangePrice(double x) 
    { 
        //change the car price by x %
        price = price + price * x / 100; 
    } 
    //compare two cars by name and price
    public static bool operator ==(Car a, Car b) 
    { 
        return a.name == b.name && a.price == b.price; 
    } //compare two cars for inequality
      public static bool operator !=(Car a, Car b) 
    { 
        return !(a == b); 
    } 
    //return formatted car info
    public override string ToString() 
    { 
        return $"Company: {CompanyName}, Name: {name}, Color: {color}, Price: {price}"; 
    } 
    //compare this object with another object
    public override bool Equals(object? obj) 
    { 
        if (obj is Car other) 
        { 
            return name == other.name && price == other.price; 
        } 
        return false; 
    } 
    //return a hash code based on the car info
    public override int GetHashCode() 
    { 
        return HashCode.Combine(name, price); 
    } 
} 
class Program 
{ 
    static void Main() 
    { 
        //create three car objects
        Car car1 = new Car(); 
        Car car2 = new Car();
        Car car3 = new Car(); 
        //read info for each car
        car1.Input(); 
        car2.Input(); 
        car3.Input(); 
        //decrease the price of each car by 10 %
        car1.ChangePrice(-10); 
        car2.ChangePrice(-10); 
        car3.ChangePrice(-10); 
        //show updated info
        car1.Print(); 
        car2.Print(); 
        car3.Print(); 
        //read new color
        string newColor = Console.ReadLine()!; 
        //repaint white cars
        if (car1.Color == "White") 
        { 
            car1.Color = newColor; 
        } 
        if (car2.Color == "White") 
        { 
            car2.Color = newColor; 
        } 
        if (car3.Color == "White") 
        { 
            car3.Color = newColor; 
        } 
        //show cars using ToString()
        Console.WriteLine(car1); 
        Console.WriteLine(car2); 
        Console.WriteLine(car3); 
    } 
}
