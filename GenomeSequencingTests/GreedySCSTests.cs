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
    public class GreedySCSTests
    {
        [TestMethod()]
        public void GetGreedySCS_FinalResult()
        {
            //Arrange
            string[] input = { "all is well", "ell that en", "hat end", "t ends well" };
            List<string> collection = new List<string>(input);
            string expectedSCS = "all is well that ends well";

            //Act
            GenomeSequencing.GreedySCS greedySCS = new GenomeSequencing.GreedySCS(collection);
            string result = greedySCS.GetGreedySCS();

            //Assert
            Assert.AreEqual(expectedSCS, result);
        }


        [TestMethod()]
        public void GetGreedySCS_ResultContainsAllSubstrings()
        {
            //Arrange
            string[] input = { "all is well", "ell that en", "hat end", "t ends well" };
            List<string> collection = new List<string>(input);
            string expectedSCS = "all is well that ends well";

            //Act
            GenomeSequencing.GreedySCS greedySCS = new GenomeSequencing.GreedySCS(collection);
            string result = greedySCS.GetGreedySCS();

            //Assert
            foreach (var fragment in collection)
            {
                Assert.IsTrue(expectedSCS.Contains(fragment));
            }
            
        }



    }
}