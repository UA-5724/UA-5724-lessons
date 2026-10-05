using NUnit.Framework;

using hw09;

namespace hw09.Tests
{
    public class ShapeGroupTests
    {
        [Test]
        public void AddTriangle_AddsTriangleToGroup()
        {
            ShapeGroup group = new ShapeGroup();

            Triangle triangle = new Triangle(
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4)
            );

            group.AddTriangle(triangle);

            Assert.That(group.GetAll().Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveTriangle_RemovesTriangleFromGroup()
        {
            ShapeGroup group = new ShapeGroup();

            Triangle triangle = new Triangle(
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4)
            );

            group.AddTriangle(triangle);
            group.RemoveTriangle(triangle);

            Assert.That(group.GetAll().Count, Is.EqualTo(0));
        }

        [Test]
        public void FindTriangleClosestToOrigin_ReturnsCorrectTriangle()
        {
            ShapeGroup group = new ShapeGroup();

            Triangle farTriangle = new Triangle(
                new Point(10, 10),
                new Point(12, 10),
                new Point(10, 12)
            );

            Triangle closeTriangle = new Triangle(
                new Point(1, 1),
                new Point(3, 1),
                new Point(1, 3)
            );

            group.AddTriangle(farTriangle);
            group.AddTriangle(closeTriangle);

            Triangle? result =
                group.FindTriangleClosestToOrigin();

            Assert.That(result, Is.SameAs(closeTriangle));
        }
    }
}