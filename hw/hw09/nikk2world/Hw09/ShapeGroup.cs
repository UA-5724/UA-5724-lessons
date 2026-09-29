namespace Hw09;

// Aggregation: the group only keeps references to triangles
// that are created outside and can live without the group
public class ShapeGroup
{
    private readonly List<Triangle> triangles = new List<Triangle>();

    public int Count => triangles.Count;

    public void AddTriangle(Triangle triangle)
    {
        ArgumentNullException.ThrowIfNull(triangle);

        triangles.Add(triangle);
    }

    // Returns false if the triangle was not in the group
    public bool RemoveTriangle(Triangle triangle)
    {
        return triangles.Remove(triangle);
    }

    // Read-only view: the caller cannot add or remove items bypassing the group
    public IReadOnlyList<Triangle> GetAll()
    {
        return triangles.AsReadOnly();
    }

    // Returns null for an empty group
    public Triangle? FindTriangleClosestToOrigin()
    {
        Triangle? closest = null;

        foreach (Triangle triangle in triangles)
        {
            if (closest == null || triangle.MinDistanceToOrigin() < closest.MinDistanceToOrigin())
                closest = triangle;
        }

        return closest;
    }
}
