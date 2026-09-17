using System;
using Program_9._1;
using Xunit;

namespace ProgramTest_9._1
{
    public class ShapeGroupTests
    {
        [Fact]
        public void AddTriangle_ShouldAddTriangleToCollection()
        {
            ShapeGroup group = new ShapeGroup();

            Triangle triangle = new Triangle(
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4)
            );

            group.AddTriangle(triangle);

            Assert.Single(group.GetAll());
            Assert.Contains(triangle, group.GetAll());
        }

        [Fact]
        public void RemoveTriangle_ShouldRemoveTriangleFromCollection()
        {
            ShapeGroup group = new ShapeGroup();

            Triangle triangle = new Triangle(
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4)
            );

            group.AddTriangle(triangle);
            group.RemoveTriangle(triangle);

            Assert.Empty(group.GetAll());
        }

        [Fact]
        public void FindTriangleClosestToOrigin_ShouldReturnCorrectTriangle()
        {
            ShapeGroup group = new ShapeGroup();

            Triangle farTriangle = new Triangle(
                new Point(10, 10),
                new Point(13, 10),
                new Point(10, 13)
            );

            Triangle closeTriangle = new Triangle(
                new Point(1, 1),
                new Point(3, 1),
                new Point(1, 3)
            );

            group.AddTriangle(farTriangle);
            group.AddTriangle(closeTriangle);

            Triangle? result = group.FindTriangleClosestToOrigin();

            Assert.Same(closeTriangle, result);
        }

        [Fact]
        public void FindTriangleClosestToOrigin_EmptyCollection_ShouldReturnNull()
        {
            ShapeGroup group = new ShapeGroup();

            Triangle? result = group.FindTriangleClosestToOrigin();

            Assert.Null(result);
        }
    }
}
