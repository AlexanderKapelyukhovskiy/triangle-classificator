using System;
using Demo.Tradeshift.Math.Triangles.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.Tradeshift.Math.Triangles.Tests
{
    [TestClass]
    public class TriangleClassificatorTests
    {
        [TestMethod]
        [DataRow(5, 2, 2, TriangleClassification.Invalid)]

        [DataRow(5, 10, 7, TriangleClassification.Scalene)]

        [DataRow(5, 5, 4, TriangleClassification.Isosceles)]
        [DataRow(5, 4, 5, TriangleClassification.Isosceles)]
        [DataRow(4, 5, 5, TriangleClassification.Isosceles)]

        [DataRow(5, 5, 5, TriangleClassification.Equilateral)]
        public void should_correctly_classify_triangles_by_sides(
            double a, double b, double c, TriangleClassification expectedClassification)
        {
            TriangleClassification classification = TriangleClassificator.ClassifyBySides(a, b, c);
            Assert.AreEqual(classification, expectedClassification);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]

        [DataRow(0, 0, 0)]
        [DataRow(0, 1, 1)]
        [DataRow(1, 0, 1)]
        [DataRow(1, 1, 0)]
        [DataRow(-1, -1, -1)]
        [DataRow(-1, 1, 1)]
        [DataRow(1, -1, 1)]
        [DataRow(1, 1, -1)]
        public void should_throw_exception_if_some_length_is_incorrect(double a, double b, double c)
        {
            TriangleClassificator.ClassifyBySides(a, b, c);
        }
    }
}
