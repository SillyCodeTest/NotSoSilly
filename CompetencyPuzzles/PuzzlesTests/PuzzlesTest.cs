using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompetencyPuzzles;

namespace PuzzlesTests
{
    /// <summary>
    /// Summary description for PuzzlesTest
    /// </summary>
    [TestClass]
    public class PuzzlesTest
    {
        public PuzzlesTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestTriangles()
        {
            Assert.AreEqual(TriangleType.Equilateral, TriangleHelper.GetTriangleType(100, 100, 100));
            Assert.AreEqual(TriangleType.Isosceles, TriangleHelper.GetTriangleType(100, 100, 90));
            Assert.AreEqual(TriangleType.Isosceles, TriangleHelper.GetTriangleType(100, 90, 100));
            Assert.AreEqual(TriangleType.Isosceles, TriangleHelper.GetTriangleType(90, 100, 100));
            Assert.AreEqual(TriangleType.Scalene, TriangleHelper.GetTriangleType(80, 90, 30));

            Assert.AreEqual(TriangleType.Error, TriangleHelper.GetTriangleType(0, 100, 100));
            Assert.AreEqual(TriangleType.Error, TriangleHelper.GetTriangleType(100, -3, 100));
            Assert.AreEqual(TriangleType.Error, TriangleHelper.GetTriangleType(4, 3, -5));
            Assert.AreEqual(TriangleType.Error, TriangleHelper.GetTriangleType(100, 100, 200));
            Assert.AreEqual(TriangleType.Error, TriangleHelper.GetTriangleType(203, 100, 100));
            Assert.AreEqual(TriangleType.Error, TriangleHelper.GetTriangleType(100, 1000, 100));

            Assert.AreEqual(TriangleType.Isosceles, TriangleHelper.GetTriangleType(int.MaxValue - 100, int.MaxValue - 100, int.MaxValue));
            Assert.AreEqual(TriangleType.Isosceles, TriangleHelper.GetTriangleType(int.MaxValue, int.MaxValue, 1));
            Assert.AreEqual(TriangleType.Equilateral, TriangleHelper.GetTriangleType(int.MaxValue - 100, int.MaxValue - 100, int.MaxValue - 100));
            Assert.AreEqual(TriangleType.Equilateral, TriangleHelper.GetTriangleType(int.MaxValue, int.MaxValue, int.MaxValue));
            Assert.AreEqual(TriangleType.Scalene, TriangleHelper.GetTriangleType(int.MaxValue-100, int.MaxValue-200, int.MaxValue /2));

        }

        [TestMethod]
        public void TestReverseWords()
        {
            Assert.AreEqual("taC dna god", StringHelper.ReverseWords("Cat and dog"));
            Assert.AreEqual(" taC dna god", StringHelper.ReverseWords(" Cat and dog"));
            Assert.AreEqual(" taC dna god ", StringHelper.ReverseWords(" Cat and dog "));
            Assert.AreEqual("  taC dna god ", StringHelper.ReverseWords("  Cat and dog "));
            Assert.AreEqual(" taC dna  god  ", StringHelper.ReverseWords(" Cat and  dog  "));

            Assert.AreEqual("taC & god", StringHelper.ReverseWords("Cat & dog"));
            Assert.AreEqual("god&taC", StringHelper.ReverseWords("Cat&dog"));
            Assert.AreEqual("god-taC pihsnoitaler", StringHelper.ReverseWords("Cat-dog relationship"));


            Assert.AreEqual("goD", StringHelper.ReverseWords("Dog"));
            Assert.AreEqual(" goD ", StringHelper.ReverseWords(" Dog "));
            Assert.AreEqual(" ", StringHelper.ReverseWords(" "));
            Assert.AreEqual("  ", StringHelper.ReverseWords("  "));
            Assert.AreEqual("   ", StringHelper.ReverseWords("   "));
            Assert.AreEqual("A b c", StringHelper.ReverseWords("A b c"));
            Assert.AreEqual(" A b c ", StringHelper.ReverseWords(" A b c "));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestReverseWordsWithNull()
        {
            StringHelper.ReverseWords(null);
        }

        [TestMethod]
        public void TestSinglyLinkedList()
        {
            SinglyLinkedList list = new SinglyLinkedList(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
            Assert.AreEqual(10, list.Length);
            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(11, list.Tail.Value);
            Assert.AreEqual(2, list.GetNode(1).Value);
            Assert.AreEqual(3, list.GetNode(2).Value);
            Assert.AreEqual(11, list.GetNode(10).Value);

            Assert.IsNull(list.GetNode(100));
        }

        [TestMethod]
        public void TestSinglyLinkedListWithAppend()
        {
            SinglyLinkedList list = new SinglyLinkedList(2);
            list.Append(3);
            list.Append(4);
            Assert.AreEqual(3, list.Length);
            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(4, list.Tail.Value);
            Assert.AreEqual(2, list.GetNode(1).Value);
            Assert.AreEqual(3, list.GetNode(2).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSinglyLinkedListWithInvalidIndex()
        {
            SinglyLinkedList list = new SinglyLinkedList(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
            list.GetNode(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSinglyLinkedListWithInvalidIndexFromTail()
        {
            SinglyLinkedList list = new SinglyLinkedList(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
            list.GetNodeFromTail(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSinglyLinkedListWithNullInCtor()
        {
            SinglyLinkedList list = new SinglyLinkedList(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSinglyLinkedListWithEmptyInCtor()
        {
            SinglyLinkedList list = new SinglyLinkedList(new int[]{});
        }


        [TestMethod]
        public void TestThe5thElementFromTail()
        {
            SinglyLinkedList list = new SinglyLinkedList(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 });
            Assert.AreEqual(7, list.GetNodeFromTail(5).Value);
        }

    }
}
