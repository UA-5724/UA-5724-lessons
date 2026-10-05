using System;
using System.IO;
using System.Text.Json;

// Represents a point with X and Y coordinates
public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    // Initialize point coordinates
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Return the point in (x,y) format
    public override string ToString()
    {
        return $"({X},{Y})";
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create an object to serialize
            Point point = new Point(3, 5);

            // Configure JSON formatting
            JsonSerializerOptions options =
                new JsonSerializerOptions
                {
                    WriteIndented = true
                };

            // Serialize the Point object into JSON
            string json =
                JsonSerializer.Serialize(point, options);

            // Save JSON into a file
            File.WriteAllText("point.json", json);

            Console.WriteLine("Object was serialized successfully.");

            // Read JSON from the file
            string jsonFromFile =
                File.ReadAllText("point.json");

            // Deserialize JSON back into a Point object
            Point? restoredPoint =
                JsonSerializer.Deserialize<Point>(jsonFromFile);

            // Display the restored object
            if (restoredPoint != null)
            {
                Console.WriteLine("Deserialized point:");
                Console.WriteLine(restoredPoint);
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine(
                $"JSON error: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine(
                $"File error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                $"Error: {ex.Message}");
        }
    }
}
