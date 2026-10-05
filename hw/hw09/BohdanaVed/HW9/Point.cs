namespace HW9
{
    public class Point
    {
        private readonly double x;
        private readonly double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return x; }
        }

        public double Y
        {
            get { return y; }
        }

        public double DistanceTo(Point other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            double dx = x - other.x;
            double dy = y - other.y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }

        public override bool Equals(object obj)
        {
            Point other = obj as Point;
            if (other == null)
            {
                return false;
            }

            return x == other.x && y == other.y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}
