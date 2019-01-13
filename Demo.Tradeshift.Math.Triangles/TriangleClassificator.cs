using Demo.Tradeshift.Math.Triangles.Enums;

namespace Demo.Tradeshift.Math.Triangles
{
    public static class TriangleClassificator
    {
        public const double Tolerance = 1E-9;

        public static TriangleClassification ClassifyBySides(double a, double b, double c)
        {
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