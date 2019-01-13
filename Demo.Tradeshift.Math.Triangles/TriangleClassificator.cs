using System;
using Demo.Tradeshift.Math.Triangles.Enums;

namespace Demo.Tradeshift.Math.Triangles
{
    /// <summary>
    /// Triangle classification helper
    /// </summary>
    public static class TriangleClassificator
    {
        private const double Tolerance = 1E-9;

        /// <summary>
        /// Classify triangle by its sides lengths(a, b, c).
        /// </summary>
        /// <param name="a">length of a side, should be > 0 </param>
        /// <param name="b">length of b side, should be > 0</param>
        /// <param name="c">length of c side, should be > 0</param>
        /// <returns>rectangle classification <see cref="TriangleClassification"/></returns>
        public static TriangleClassification ClassifyBySides(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("sides length (a, b, c) should be greater than 0");
            }

            //A triangle is valid if sum of its two sides is greater than the third side
            bool triangleIsValid = (a + b > c) && (a + c > b) && (b + c > a);
            if (triangleIsValid == false)
            {
                return TriangleClassification.Invalid;
            }

            //Equilateral (all three sides are equal)
            bool triangleIsEquilateral = (System.Math.Abs(a - b) < Tolerance) && (System.Math.Abs(b - c) < Tolerance);
            if (triangleIsEquilateral)
            {
                return TriangleClassification.Equilateral;
            }

            //Isosceles(two sides are equal)
            bool triangleIsIsosceles =
                (System.Math.Abs(a - b) < Tolerance)
                || (System.Math.Abs(a - c) < Tolerance)
                || (System.Math.Abs(b - c) < Tolerance);

            if (triangleIsIsosceles)
            {
                return TriangleClassification.Isosceles;
            }

            //Scalene(all sides are different)
            return TriangleClassification.Scalene;
        }
    }
}