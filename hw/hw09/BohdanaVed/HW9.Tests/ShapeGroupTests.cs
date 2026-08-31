using System;
using System.Collections.Generic;
using HW9;
using Xunit;

namespace HW9.Tests
{
    public class ShapeGroupTests
    {
        [Fact]
        public void AddTriangle_OneTriangle_IncreasesCount()
        {
            ShapeGroup group = new ShapeGroup();
            Triangle triangle = CreateTriangleShiftedBy(1);

            group.AddTriangle(triangle);

            Assert.Equal(1, group.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        public void AddTriangle_ManyTriangles_CountAndGetAllMatch(int howMany)
        {
            ShapeGroup group = new ShapeGroup();

            for (int i = 0; i < howMany; i++)
            {
                group.AddTriangle(CreateTriangleShiftedBy(i + 1));
            }

            Assert.Equal(howMany, group.Count);
            Assert.Equal(howMany, group.GetAll().Count);
        }

        [Fact]
        public void AddTriangle_Null_ThrowsArgumentNullException()
        {
            ShapeGroup group = new ShapeGroup();

            Assert.Throws<ArgumentNullException>(() => group.AddTriangle(null));
        }

        [Fact]
        public void AddTriangle_Null_DoesNotChangeGroup()
        {
            ShapeGroup group = new ShapeGroup();
            Triangle triangle = CreateTriangleShiftedBy(2);
            group.AddTriangle(triangle);

            Assert.Throws<ArgumentNullException>(() => group.AddTriangle(null));

            Assert.Equal(1, group.Count);
            Assert.Same(triangle, group.GetAll()[0]);
        }

        [Fact]
        public void AddTriangle_StoresTheSameInstance()
        {
            ShapeGroup group = new ShapeGroup();
            Triangle triangle = CreateTriangleShiftedBy(3);

            group.AddTriangle(triangle);

            Assert.Same(triangle, group.GetAll()[0]);
        }

        [Fact]
        public void RemoveTriangle_AddedTriangle_ReturnsTrueAndRemovesIt()
        {
            ShapeGroup group = new ShapeGroup();
            Triangle first = CreateTriangleShiftedBy(1);
            Triangle second = CreateTriangleShiftedBy(2);
            group.AddTriangle(first);
            group.AddTriangle(second);

            bool removed = group.RemoveTriangle(first);

            Assert.True(removed);
            Assert.Equal(1, group.Count);
            Assert.Same(second, group.GetAll()[0]);
        }

        [Fact]
        public void RemoveTriangle_NeverAddedTriangle_ReturnsFalse()
        {
            ShapeGroup group = new ShapeGroup();
            Triangle added = CreateTriangleShiftedBy(1);
            Triangle stranger = CreateTriangleShiftedBy(9);
            group.AddTriangle(added);

            bool removed = group.RemoveTriangle(stranger);

            Assert.False(removed);
            Assert.Equal(1, group.Count);
            Assert.Same(added, group.GetAll()[0]);
        }

        [Fact]
        public void RemoveTriangle_EqualByCoordinatesButOtherInstance_ReturnsFalse()
        {
            ShapeGroup group = new ShapeGroup();
            Triangle added = CreateTriangleShiftedBy(4);
            Triangle copy = CreateTriangleShiftedBy(4);
            group.AddTriangle(added);

            bool removed = group.RemoveTriangle(copy);

            Assert.False(removed);
            Assert.Equal(1, group.Count);
            Assert.Same(added, group.GetAll()[0]);
        }

        [Fact]
        public void RemoveTriangle_FromEmptyGroup_ReturnsFalse()
        {
            ShapeGroup group = new ShapeGroup();

            bool removed = group.RemoveTriangle(CreateTriangleShiftedBy(1));

            Assert.False(removed);
            Assert.Equal(0, group.Count);
        }

        [Fact]
        public void RemoveTriangle_Null_ReturnsFalse()
        {
            ShapeGroup group = new ShapeGroup();
            group.AddTriangle(CreateTriangleShiftedBy(1));

            bool removed = group.RemoveTriangle(null);

            Assert.False(removed);
            Assert.Equal(1, group.Count);
        }

        [Fact]
        public void GetAll_NewGroup_IsEmpty()
        {
            ShapeGroup group = new ShapeGroup();

            IReadOnlyList<Triangle> all = group.GetAll();

            Assert.Empty(all);
            Assert.Equal(0, group.Count);
        }

        [Fact]
        public void GetAll_ReflectsAddsAndRemoves()
        {
            ShapeGroup group = new ShapeGroup();
            Triangle first = CreateTriangleShiftedBy(1);
            Triangle second = CreateTriangleShiftedBy(2);
            Triangle third = CreateTriangleShiftedBy(3);

            group.AddTriangle(first);
            group.AddTriangle(second);
            group.AddTriangle(third);

            IReadOnlyList<Triangle> afterAdds = group.GetAll();

            Assert.Equal(3, afterAdds.Count);
            Assert.Same(first, afterAdds[0]);
            Assert.Same(second, afterAdds[1]);
            Assert.Same(third, afterAdds[2]);

            group.RemoveTriangle(second);

            IReadOnlyList<Triangle> afterRemove = group.GetAll();

            Assert.Equal(2, afterRemove.Count);
            Assert.Same(first, afterRemove[0]);
            Assert.Same(third, afterRemove[1]);
            Assert.DoesNotContain(second, afterRemove);
        }

        [Fact]
        public void GetAll_AllTrianglesRemoved_IsEmpty()
        {
            ShapeGroup group = new ShapeGroup();
            Triangle first = CreateTriangleShiftedBy(1);
            Triangle second = CreateTriangleShiftedBy(2);
            group.AddTriangle(first);
            group.AddTriangle(second);

            group.RemoveTriangle(first);
            group.RemoveTriangle(second);

            Assert.Empty(group.GetAll());
            Assert.Equal(0, group.Count);
        }

        [Fact]
        public void FindTriangleClosestToOrigin_EmptyGroup_ReturnsNull()
        {
            ShapeGroup group = new ShapeGroup();

            Triangle closest = group.FindTriangleClosestToOrigin();

            Assert.Null(closest);
        }

        [Fact]
        public void FindTriangleClosestToOrigin_SingleTriangle_ReturnsThatInstance()
        {
            ShapeGroup group = new ShapeGroup();
            Triangle only = CreateTriangleShiftedBy(7);
            group.AddTriangle(only);

            Triangle closest = group.FindTriangleClosestToOrigin();

            Assert.Same(only, closest);
        }

        [Theory]
        [InlineData(1, 5, 9, 1)]
        [InlineData(7, 3, 8, 3)]
        [InlineData(4, 6, 2, 2)]
        [InlineData(6, 6, 6, 6)]
        public void FindTriangleClosestToOrigin_ReturnsTriangleWithSmallestDistance(double firstShift, double secondShift, double thirdShift, double expectedShift)
        {
            ShapeGroup group = new ShapeGroup();
            group.AddTriangle(CreateTriangleShiftedBy(firstShift));
            group.AddTriangle(CreateTriangleShiftedBy(secondShift));
            group.AddTriangle(CreateTriangleShiftedBy(thirdShift));

            Triangle closest = group.FindTriangleClosestToOrigin();

            Assert.NotNull(closest);
            Assert.Equal(expectedShift, closest.DistanceToOrigin(), 10);
            Assert.Equal(expectedShift, closest.Vertex1.X, 10);
        }

        [Fact]
        public void FindTriangleClosestToOrigin_TriangleTouchingOrigin_ReturnsIt()
        {
            ShapeGroup group = new ShapeGroup();
            Triangle far = CreateTriangleShiftedBy(10);
            Triangle atOrigin = new Triangle();
            group.AddTriangle(far);
            group.AddTriangle(atOrigin);

            Triangle closest = group.FindTriangleClosestToOrigin();

            Assert.Same(atOrigin, closest);
            Assert.Equal(0, closest.DistanceToOrigin(), 10);
        }

        [Fact]
        public void FindTriangleClosestToOrigin_AfterRemovingClosest_ReturnsNextOne()
        {
            ShapeGroup group = new ShapeGroup();
            Triangle near = CreateTriangleShiftedBy(1);
            Triangle middle = CreateTriangleShiftedBy(4);
            Triangle far = CreateTriangleShiftedBy(8);
            group.AddTriangle(near);
            group.AddTriangle(middle);
            group.AddTriangle(far);

            Assert.Same(near, group.FindTriangleClosestToOrigin());

            group.RemoveTriangle(near);

            Assert.Same(middle, group.FindTriangleClosestToOrigin());
        }

        [Fact]
        public void FindTriangleClosestToOrigin_AfterRemovingEverything_ReturnsNull()
        {
            ShapeGroup group = new ShapeGroup();
            Triangle only = CreateTriangleShiftedBy(2);
            group.AddTriangle(only);

            group.RemoveTriangle(only);

            Assert.Null(group.FindTriangleClosestToOrigin());
        }

        [Fact]
        public void RemovedTriangle_StillWorksOnItsOwn()
        {
            ShapeGroup group = new ShapeGroup();
            Triangle triangle = CreateTriangleShiftedBy(3);
            group.AddTriangle(triangle);

            group.RemoveTriangle(triangle);

            Assert.Equal(0, group.Count);
            Assert.Equal(3.4142135624, triangle.Perimeter(), 8);
            Assert.Equal(0.5, triangle.Area(), 10);
            Assert.Equal(3, triangle.DistanceToOrigin(), 10);
            Assert.Equal(3, triangle.Vertex1.X, 10);
            Assert.Equal(0, triangle.Vertex1.Y, 10);
            Assert.Equal("Triangle (3,0) (4,0) (3,1), perimeter = 3.41, area = 0.5", triangle.ToString());
        }

        [Fact]
        public void RemovedTriangle_CanBeAddedToAnotherGroup()
        {
            ShapeGroup first = new ShapeGroup();
            ShapeGroup second = new ShapeGroup();
            Triangle triangle = CreateTriangleShiftedBy(2);
            first.AddTriangle(triangle);

            first.RemoveTriangle(triangle);
            second.AddTriangle(triangle);

            Assert.Equal(0, first.Count);
            Assert.Equal(1, second.Count);
            Assert.Same(triangle, second.GetAll()[0]);
            Assert.Same(triangle, second.FindTriangleClosestToOrigin());
        }

        [Fact]
        public void TriangleInTwoGroups_IsSharedNotCopied()
        {
            ShapeGroup first = new ShapeGroup();
            ShapeGroup second = new ShapeGroup();
            Triangle shared = CreateTriangleShiftedBy(5);

            first.AddTriangle(shared);
            second.AddTriangle(shared);

            Assert.Same(shared, first.GetAll()[0]);
            Assert.Same(shared, second.GetAll()[0]);
            Assert.Same(first.GetAll()[0], second.GetAll()[0]);
            Assert.Same(first.FindTriangleClosestToOrigin(), second.FindTriangleClosestToOrigin());
        }

        [Fact]
        public void TriangleRemovedFromOneGroup_StaysInTheOther()
        {
            ShapeGroup first = new ShapeGroup();
            ShapeGroup second = new ShapeGroup();
            Triangle shared = CreateTriangleShiftedBy(5);
            first.AddTriangle(shared);
            second.AddTriangle(shared);

            bool removed = first.RemoveTriangle(shared);

            Assert.True(removed);
            Assert.Equal(0, first.Count);
            Assert.Equal(1, second.Count);
            Assert.Same(shared, second.GetAll()[0]);
            Assert.Equal(5, second.GetAll()[0].DistanceToOrigin(), 10);
        }

        private static Triangle CreateTriangleShiftedBy(double shift)
        {
            Point a = new Point(shift, 0);
            Point b = new Point(shift + 1, 0);
            Point c = new Point(shift, 1);

            return new Triangle(a, b, c);
        }
    }
}
