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
        public void OverlapFinder_PostfixMatchesPrefix()
        {
            //Arrange
            string firstString = "abij";
            string secondString = "ijxy";
            int expectedOverlap = 2;
            string expectedMergedString = "abijxy";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(firstString, secondString);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }


        [TestMethod()]
        public void OverlapFinder_PrefixMatchesPostfix()
        {
            //Arrange
            string firstString = "abij";
            string secondString = "xyab";
            int expectedOverlap = 2;
            string expectedMergedString = "xyabij";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(firstString, secondString);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }


        [TestMethod()]
        public void OverlapFinder_firstStringContainsSecondString()
        {
            //Arrange
            string firstString = "s well tha";
            string secondString = "ell";
            int expectedOverlap = 3;
            string expectedMergedString = "s well tha";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(firstString, secondString);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }

        [TestMethod()]
        public void OverlapFinder_SecondStringContainsFirstString()
        {
            //Arrange
            string firstString = "ell";
            string secondString = "s well tha";
            int expectedOverlap = 3;
            string expectedMergedString = "s well tha";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(firstString, secondString);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }


        [TestMethod()]
        public void OverlapFinder_BothWayMatchEqually()
        {
            //Arrange
            string firstString = "abxy";
            string secondString = "xyab";
            int expectedOverlap = 2;
            string expectedMergedString = "abxyab";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(firstString, secondString);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }

        [TestMethod()]
        public void OverlapFinder_BothWayMatchUnequal()
        {
            //Arrange
            string firstString = "xyzab";
            string secondString = "abxyz";
            int expectedOverlap = 3;
            string expectedMergedString = "abxyzab";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(firstString, secondString);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }


        [TestMethod()]
        public void NoMatchTest()
        {
            //Arrange
            string firstString = "abc";
            string secondString = "xyz";
            int expectedOverlap = 0;
            string expectedMergedString = "abcxyz";

            //Act
            GenomeSequencing.OverlapFinder finder = new GenomeSequencing.OverlapFinder(firstString, secondString);
            var result = finder.FindOverlap();

            //Assert
            Assert.AreEqual(expectedOverlap, result.Item1);
            Assert.AreEqual(expectedMergedString, result.Item2);

        }


    }
}