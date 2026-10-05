namespace Task1;

public abstract class Shape
{
    public string Name { get; set; }

    protected Shape(string name)
    {
        Name = name;
    }

    public abstract double GetArea();
    public abstract double GetPerimeter();

    public override string ToString()
    {
        return $"{Name}: Area = {GetArea():F2}, Perimeter = {GetPerimeter():F2}";
    }
}
