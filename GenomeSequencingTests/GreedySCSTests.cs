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


        [TestMethod()]
        public void GetGreedySCS_ResultContainsAllSubstringsLargerInputSize()
        {
            //created a 50char dna string and created multiple copies then cut each randomly and set as input collection.
        
            //Arrange
            string[] input = { "actgag", "tcctagga", "gctctaaatcgctat", "cgtacgtac", "gtcttctatct", "actg", "agt", "cctaggagctc", "taaatcgct", "a", "tcgta", "cgtacgt", "cttctatct", "actgagt", "cctaggagctc", "taaatcg", "ctatcgtacgtacgtct", "tctatct", "actga", "gtcctaggagc", "tctaaatcgctat", "cgtacgtacgtc", "ttctatct", "actg", "agtcctaggagctctaaat", "cgctatcgtacgtacg", "tcttct", "atct", "actgagtcctaggagc", "tctaaatcgctatcgta", "cgtacgtcttctatct", "actgagt", "cctaggag", "ctctaaat", "cgctatcg", "tacgtacgt", "cttctatct" };
            List<string> collection = new List<string>(input);
            string expectedSCS = "actgagtcctaggagctctaaatcgctatcgtacgtacgtcttctatct";

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