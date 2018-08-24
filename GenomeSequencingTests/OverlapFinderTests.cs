using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenomeSequencing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomeSequencing.Tests
{
    [TestClass()]
    public class OverlapFinderTests
    {
        [TestMethod()]
        public void  ABTest()
        {
            //Arrange
            string fragmentA = "all is well";
            string fragmentB = "ell that end";
            int expectedOverlap = 3;
            string expectedMergedString = "all is well that end";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(fragmentA, fragmentB);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }


        [TestMethod()]
        public void BATest()
        {
            //Arrange
            string fragmentA = "t ends well";
            string fragmentB = "ell that en";
            int expectedOverlap = 4;
            string expectedMergedString = "ell that ends well";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(fragmentA, fragmentB);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }


        [TestMethod()]
        public void CompleteContainABTest()
        {
            //Arrange
            string fragmentA = "s well tha";
            string fragmentB = "ell";
            int expectedOverlap = 3;
            string expectedMergedString = "s well tha";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(fragmentA, fragmentB);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }

        [TestMethod()]
        public void CompleteContainBATest()
        {
            //Arrange
            string fragmentA = "ell";
            string fragmentB = "s well tha";
            int expectedOverlap = 3;
            string expectedMergedString = "s well tha";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(fragmentA, fragmentB);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }


        [TestMethod()]
        public void BothSideMatchEquallyABTest()
        {
            //Arrange
            string fragmentA = "abxy";
            string fragmentB = "xyab";
            int expectedOverlap = 2;
            string expectedMergedString = "abxyab";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(fragmentA, fragmentB);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }

        [TestMethod()]
        public void BothSideMatchEquallyBATest()
        {
            //Arrange
            string fragmentA = "xyab";
            string fragmentB = "abxy";
            int expectedOverlap = 2;
            string expectedMergedString = "xyabxy";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(fragmentA, fragmentB);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }


        [TestMethod()]
        public void NoMatchTest()
        {
            //Arrange
            string fragmentA = "abc";
            string fragmentB = "xyz";
            int expectedOverlap = 0;
            string expectedMergedString = "abcxyz";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(fragmentA, fragmentB);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }


    }
}