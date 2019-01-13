using System;
using Demo.Tradeshift.Math.Triangles.Enums;

namespace Demo.Tradeshift.Math.Triangles
{
    public static class TriangleClassificator
    {
        public static TriangleClassification ClassifyBySides(double a, double b, double c)
        {
            //A triangle is valid if sum of its two sides is greater than the third side
            bool triangleIsValid = (a + b > c) && (a + c > b) && (b + c > a);
            if (triangleIsValid == false)
            {
                return TriangleClassification.Invalid;
            }

            throw new NotImplementedException();
        }
    }
}