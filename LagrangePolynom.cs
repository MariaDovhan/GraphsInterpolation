using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsInterpolation
{
    public class LagrangePolynom
    {
        public List<Point> points;
        public int iterations;

        public LagrangePolynom(List<Point> inputPoints)
        {
            points = inputPoints;
            iterations = 0;
        }

        public double SumOfLagrangePolynom(double x)
        {
            double sum = 0f;
            foreach (Point point1 in points)
            {
                double product = 1.0;
                foreach (Point point2 in points)
                {
                    iterations++;
                    if (point1 != point2)
                    {
                        product *= (x - point2.x) / (point1.x - point2.x);
                    }
                }
                sum += product * point1.y;
            }
            return sum;
        }

    }
}
