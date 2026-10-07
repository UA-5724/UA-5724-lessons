namespace hw09
{
    class ShapeGroup
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


        public Triangle FindTriangleClosestToOrigin()
        {
            if (triangles.Count == 0)
            {
                return null;
            }

            Triangle closestTriangle = triangles[0];

            for (int index = 1; index < triangles.Count; index++)
            {
                if (triangles[index].GetClosestVertexDistance() <
                    closestTriangle.GetClosestVertexDistance())
                {
                    closestTriangle = triangles[index];
                }
            }

            return closestTriangle;
        }
    }
}
