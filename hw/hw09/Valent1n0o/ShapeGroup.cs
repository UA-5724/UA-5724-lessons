using System;
using System.Collections.Generic;

namespace hw09
{
    public class ShapeGroup
    {
        private List<Triangle> triangles;

        public ShapeGroup()
        {
            triangles = new List<Triangle>();
        }

        public void AddTriangle(Triangle triangle)
        {
            triangles.Add(triangle);
        }

        public void RemoveTriangle(Triangle triangle)
        {
            triangles.Remove(triangle);
        }

        public List<Triangle> GetAll()
        {
            return triangles;
        }

        public Triangle? FindTriangleClosestToOrigin()
        {
            if (triangles.Count == 0)
            {
                return null;
            }

            Point origin = new Point(0, 0);

            Triangle closestTriangle = triangles[0];
            double minimumDistance =
                closestTriangle.DistanceToClosestVertex(origin);

            foreach (Triangle triangle in triangles)
            {
                double distance =
                    triangle.DistanceToClosestVertex(origin);

                if (distance < minimumDistance)
                {
                    minimumDistance = distance;
                    closestTriangle = triangle;
                }
            }

            return closestTriangle;
        }
    }
}