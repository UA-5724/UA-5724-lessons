using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_9._1
{
    public class ShapeGroup
    {
        private readonly List<Triangle> triangles = new();

        public void AddTriangle(Triangle triangle)
        {
            if (triangle == null)
                throw new ArgumentNullException(nameof(triangle));

            triangles.Add(triangle);
        }

        public void RemoveTriangle(Triangle triangle)
        {
            if (triangle == null)
                throw new ArgumentNullException(nameof(triangle));

            triangles.Remove(triangle);
        }

        public List<Triangle> GetAll()
        {
            return new List<Triangle>(triangles);
        }

        public Triangle? FindTriangleClosestToOrigin()
        {
            if (triangles.Count == 0)
                return null;

            return triangles
                .OrderBy(t => t.GetClosestVertexToOrigin().DistanceTo(new Point(0, 0)))
                .First();
        }
    }
}
