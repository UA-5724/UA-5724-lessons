namespace hw09
{
    struct Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get
            {
                return x;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
        }

        public double DistanceTo(Point other)
        {
            double dx = x - other.x;
            double dy = y - other.y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                Point other = (Point)obj;

                return x == other.x && y == other.y;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }

}
