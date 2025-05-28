using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsInterpolation
{
    public class PolynomView
    {
        private double[] coefficients;

        public string GetSimplifiedPolynomial(List<Point> points)
        {
            coefficients = new double[points.Count];

            for (int i = 0; i < points.Count; i++)
            {
                double factorCoefficient = points[i].y;         //коефіцієнт при (x-root) у доданку даного етапу
                List<(double a, double b)> terms = new List<(double, double)>();        //запис лінійних множників (x-root) => (a-b) даного доданка

                for (int j = 0; j < points.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    factorCoefficient /= points[i].x - points[j].x;       //коефіцієнт при множнику, що утворений зведенням коефіцієнта при (x-root) та знаменника
                    terms.Add((1, -points[j].x));       //додавання до загального множника даного етапу коефіцієнта при множнику (x-root) та кореня лінійного множника (x-root)
                }

                double[] termMultiplicationCoefficients = MultiplyLinearFactors(terms);        //коефіцієнт при змінній кожного степеня без множення на коефіцієнт при всьому множнику
                for (int j = 0; j < termMultiplicationCoefficients.Length; j++)
                {
                    coefficients[j] += factorCoefficient * termMultiplicationCoefficients[j];
                }
            }

            return PolynomialToString(coefficients);
        }

        private double[] MultiplyLinearFactors(List<(double a, double b)> terms)
        {
            double[] varCoefficients = { 1 };
            foreach ((double a, double b) in terms)         //для кожного лінійного множника (x-root)
            {
                double[] nextTerm = new double[varCoefficients.Length + 1];
                for (int i = 0; i < varCoefficients.Length; i++)
                {
                    nextTerm[i] += varCoefficients[i] * b;
                    nextTerm[i + 1] += varCoefficients[i] * a;
                }
                varCoefficients = nextTerm;
            }
            return varCoefficients;
        }

        private string PolynomialToString(double[] coefficients)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool isFirstTerm = true;
            bool areAllZeroes = true;

            stringBuilder.Append($"f(x) = ");
            for (int i = coefficients.Length - 1; i >= 0; i--)
            {
                double c = coefficients[i];

                if (Math.Abs(c) < 1e-4)
                {
                    continue;
                }
                areAllZeroes = false;

                if (isFirstTerm)
                {
                    if (c < 0)
                    {
                        stringBuilder.Append('-');
                    }
                    isFirstTerm = false;
                }
                else
                {
                    stringBuilder.Append(c > 0 ? " + " : " - ");
                }

                c = Math.Abs(c);

                if (i == 0)
                {
                    stringBuilder.Append($"{c:0.####}");
                }
                else
                    if (i == 1)
                {
                    stringBuilder.Append(Math.Abs(c - 1) < 1e-4 ? "x" : $"{c:0.####}x");
                }
                else
                {
                    stringBuilder.Append(Math.Abs(c - 1) < 1e-4 ? $"x^{i}" : $"{c:0.####}x^{i}");
                }
            }

            if (areAllZeroes)
            {
                stringBuilder.Append('0');
            }

            return stringBuilder.ToString();
        }
    }
}

