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
    public class MaxOverlapFinderTests
    {

        [TestMethod()]
        public void FindMaxOverlapTest()
        {
            //Arrange
            string[] input = { "all is well", "ell that en", "hat end", "t ends well" };
            List<string> collection = new List<string>(input);
            int expectedIndex1 = 1;
            int expectedIndex2 = 2;
            string expectedMergedString = "ell that end";

            //Act
            GenomeSequencing.MaxOverlapFinder maxFinder = new GenomeSequencing.MaxOverlapFinder(collection);
            var result = maxFinder.FindMaxOverlap();

            //Assert
            Assert.AreEqual(expectedIndex1, result.Item1);
            Assert.AreEqual(expectedIndex2, result.Item2);
            Assert.AreEqual(expectedMergedString, result.Item3);
        }
    }
}