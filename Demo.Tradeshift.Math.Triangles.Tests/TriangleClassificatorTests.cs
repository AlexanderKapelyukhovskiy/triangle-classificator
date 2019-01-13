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
        [DataRow(5, 5, 5, TriangleClassification.Equilateral)]
        public void should_correctly_classify_triangles_by_sides(
            double a, double b, double c, TriangleClassification expectedClassification)
        {
            TriangleClassification classification = TriangleClassificator.ClassifyBySides(a, b, c);
            Assert.AreEqual(classification, expectedClassification);
        }
    }
}
