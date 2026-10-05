using NUnit.Framework;

namespace hw09.Tests
{
    [TestFixture]
    public class ShapeGroupTests
    {
        // Test adding triangle
        [Test]
        public void AddTriangle_ShouldAddTriangle()
        {
            ShapeGroup group = new ShapeGroup();

            Triangle triangle = new Triangle(
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4));

            group.AddTriangle(triangle);

            Assert.That(group.GetAll().Count, Is.EqualTo(1));
        }


        // Test removing triangle
        [Test]
        public void RemoveTriangle_ShouldRemoveTriangle()
        {
            ShapeGroup group = new ShapeGroup();

            Triangle triangle = new Triangle(
                new Point(0, 0),
                new Point(3, 0),
                new Point(0, 4));

            group.AddTriangle(triangle);
            group.RemoveTriangle(triangle);

            Assert.That(group.GetAll().Count, Is.EqualTo(0));
        }


        // Test closest triangle
        [Test]
        public void FindTriangleClosestToOrigin_ShouldReturnCorrectTriangle()
        {
            ShapeGroup group = new ShapeGroup();

            Triangle triangle1 = new Triangle(
                new Point(10, 10),
                new Point(13, 10),
                new Point(10, 14));

            Triangle triangle2 = new Triangle(
                new Point(1, 1),
                new Point(4, 1),
                new Point(1, 5));

            group.AddTriangle(triangle1);
            group.AddTriangle(triangle2);

            Triangle result = group.FindTriangleClosestToOrigin();

            Assert.That(result, Is.SameAs(triangle2));
        }


        // Test empty collection
        [Test]
        public void FindTriangleClosestToOrigin_EmptyGroup_ShouldReturnNull()
        {
            ShapeGroup group = new ShapeGroup();

            Triangle result = group.FindTriangleClosestToOrigin();

            Assert.That(result, Is.Null);
        }
    }
}