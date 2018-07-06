using System;
using Xunit;
using Fonlow.ReadifyKnock;

namespace UnitTests
{
    /// <summary>
    /// Summary description for PuzzlesTest
    /// </summary>

    public class MiscTests
    {

        [Fact]
        public void TestTriangles()
        {
            Assert.Equal(TriangleType.Equilateral, MiscHelper.GetTriangleType(100, 100, 100));
            Assert.Equal(TriangleType.Isosceles, MiscHelper.GetTriangleType(100, 100, 90));
            Assert.Equal(TriangleType.Isosceles, MiscHelper.GetTriangleType(100, 90, 100));
            Assert.Equal(TriangleType.Isosceles, MiscHelper.GetTriangleType(90, 100, 100));
            Assert.Equal(TriangleType.Scalene, MiscHelper.GetTriangleType(80, 90, 30));

            Assert.Equal(TriangleType.Error, MiscHelper.GetTriangleType(0, 100, 100));
            Assert.Equal(TriangleType.Error, MiscHelper.GetTriangleType(100, -3, 100));
            Assert.Equal(TriangleType.Error, MiscHelper.GetTriangleType(4, 3, -5));
            Assert.Equal(TriangleType.Error, MiscHelper.GetTriangleType(100, 100, 200));
            Assert.Equal(TriangleType.Error, MiscHelper.GetTriangleType(203, 100, 100));
            Assert.Equal(TriangleType.Error, MiscHelper.GetTriangleType(100, 1000, 100));

            Assert.Equal(TriangleType.Isosceles, MiscHelper.GetTriangleType(int.MaxValue - 100, int.MaxValue - 100, int.MaxValue));
            Assert.Equal(TriangleType.Isosceles, MiscHelper.GetTriangleType(int.MaxValue, int.MaxValue, 1));
            Assert.Equal(TriangleType.Equilateral, MiscHelper.GetTriangleType(int.MaxValue - 100, int.MaxValue - 100, int.MaxValue - 100));
            Assert.Equal(TriangleType.Equilateral, MiscHelper.GetTriangleType(int.MaxValue, int.MaxValue, int.MaxValue));
            Assert.Equal(TriangleType.Scalene, MiscHelper.GetTriangleType(int.MaxValue - 100, int.MaxValue - 200, int.MaxValue / 2));
        }

        [Fact]
        public void TestReverseWords()
        {
            Assert.Equal("taC dna god", MiscHelper.ReverseWords("Cat and dog"));
            Assert.Equal(" taC dna god", MiscHelper.ReverseWords(" Cat and dog"));
            Assert.Equal(" taC dna god ", MiscHelper.ReverseWords(" Cat and dog "));
            Assert.Equal("  taC dna god ", MiscHelper.ReverseWords("  Cat and dog "));
            Assert.Equal(" taC dna  god  ", MiscHelper.ReverseWords(" Cat and  dog  "));

            Assert.Equal("taC & god", MiscHelper.ReverseWords("Cat & dog"));
            Assert.Equal("god&taC", MiscHelper.ReverseWords("Cat&dog"));
            Assert.Equal("god-taC pihsnoitaler", MiscHelper.ReverseWords("Cat-dog relationship"));


            Assert.Equal("goD", MiscHelper.ReverseWords("Dog"));
            Assert.Equal(" goD ", MiscHelper.ReverseWords(" Dog "));
            Assert.Equal(" ", MiscHelper.ReverseWords(" "));
            Assert.Equal("  ", MiscHelper.ReverseWords("  "));
            Assert.Equal("   ", MiscHelper.ReverseWords("   "));
            Assert.Equal("A b c", MiscHelper.ReverseWords("A b c"));
            Assert.Equal(" A b c ", MiscHelper.ReverseWords(" A b c "));

        }

        [Fact]
        public void TestReverseWordsWithNull()
        {
           Assert.Throws<ArgumentNullException>(()=>  MiscHelper.ReverseWords(null));
        }

        [Fact]
        public void TestPositiveFibonacciNumbers()
        {
            Assert.Equal(0, MiscHelper.CalculateFibonacciSeries(0));
            Assert.Equal(1, MiscHelper.CalculateFibonacciSeries(1));
            Assert.Equal(1, MiscHelper.CalculateFibonacciSeries(2));
            Assert.Equal(2, MiscHelper.CalculateFibonacciSeries(3));
            Assert.Equal(3, MiscHelper.CalculateFibonacciSeries(4));
            Assert.Equal(5, MiscHelper.CalculateFibonacciSeries(5));
            Assert.Equal(8, MiscHelper.CalculateFibonacciSeries(6));
            Assert.Equal(13, MiscHelper.CalculateFibonacciSeries(7));
            Assert.Equal(21, MiscHelper.CalculateFibonacciSeries(8));
            Assert.Equal(4660046610375530309, MiscHelper.CalculateFibonacciSeries(91));
            Assert.Equal(7540113804746346429, MiscHelper.CalculateFibonacciSeries(92));
        }

        [Fact]
        public void TestNegativeFibonacciNumbers()
        {
            Assert.Equal(-1, MiscHelper.CalculateFibonacciSeries(-1));
            Assert.Equal(-1, MiscHelper.CalculateFibonacciSeries(-2));
            Assert.Equal(-2, MiscHelper.CalculateFibonacciSeries(-3));
            Assert.Equal(-3, MiscHelper.CalculateFibonacciSeries(-4));
            Assert.Equal(-5, MiscHelper.CalculateFibonacciSeries(-5));
            Assert.Equal(-8, MiscHelper.CalculateFibonacciSeries(-6));
            Assert.Equal(-13, MiscHelper.CalculateFibonacciSeries(-7));
            Assert.Equal(-21, MiscHelper.CalculateFibonacciSeries(-8));
            Assert.Equal(-4660046610375530309, MiscHelper.CalculateFibonacciSeries(-91));
            Assert.Equal(-7540113804746346429, MiscHelper.CalculateFibonacciSeries(-92));
        }

        [Fact]
        public void TestFibExceedRangeThrows()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MiscHelper.CalculateFibonacciSeries(93));
        }

        [Fact]
        public void TestNegativeFibExceedRangeThrows()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => MiscHelper.CalculateFibonacciSeries(-93));
        }


    }
}
