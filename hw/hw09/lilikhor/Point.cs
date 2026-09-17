using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_9._1
{
    public class Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public double DistanceTo(Point other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            double dx = X - other.X;
            double dy = Y - other.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Point other)
                return false;

            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
