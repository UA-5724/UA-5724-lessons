namespace HW9
{
    public class ShapeGroup
    {
        private readonly List<Triangle> triangles = new List<Triangle>();

        public int Count
        {
            get { return triangles.Count; }
        }

        public void AddTriangle(Triangle triangle)
        {
            if (triangle == null)
            {
                throw new ArgumentNullException(nameof(triangle));
            }

            triangles.Add(triangle);
        }

        public bool RemoveTriangle(Triangle triangle)
        {
            return triangles.Remove(triangle);
        }

        public IReadOnlyList<Triangle> GetAll()
        {
            return triangles.AsReadOnly();
        }

        public Triangle FindTriangleClosestToOrigin()
        {
            if (triangles.Count == 0)
            {
                return null;
            }

            Triangle closest = triangles[0];
            foreach (Triangle triangle in triangles)
            {
                if (triangle.DistanceToOrigin() < closest.DistanceToOrigin())
                {
                    closest = triangle;
                }
            }

            return closest;
        }
    }
}
