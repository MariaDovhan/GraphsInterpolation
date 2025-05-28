using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsInterpolation
{
    public class AitkenScheme
    {
        public List<Point> points = new List<Point>();
        public int iterations;

        public AitkenScheme(List<Point> inputPoints)
        {
            points = inputPoints;
            iterations = 0;
        }

        public double ValueAtPoint(double x)
        {
            double[][] AitkenTable = new double[points.Count][];
            for (int i = 0; i < points.Count; i++)
            {
                iterations++;
                AitkenTable[i] = new double[points.Count];
                AitkenTable[i][0] = points[i].y;
            }
            for (int i = 1; i < points.Count; i++)
            {
                for (int j = 0; j < points.Count - i; j++)
                {
                    iterations++;
                    double xj = points[j].x;
                    double xji = points[j + i].x;
                    AitkenTable[j][i] = ((x - xji) * AitkenTable[j][i - 1] -
                                         (x - xj) * AitkenTable[j + 1][i - 1]) / (xj - xji);
                }
            }
            return AitkenTable[0][points.Count - 1];
        }
    }
}
