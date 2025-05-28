using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsInterpolation
{
    public class Point : IComparable<Point>
    {
        public double x;
        public double y;

        public Point(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public Point(double[] point)
        {
            x = point[0];
            y = point[1];
        }

        public override string ToString()
        {
            return $"({x}, {y}) ";
        }

        public int CompareTo(Point? other)
        {
            if (x > other.x) return 1;
            else if (x == other.x) return 0;
            else return -1;
        }
    }
}
