using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomeSequencing
{
    class OOSolution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");

            //hardcode input for now
            string[] input = { "all is well", "ell that en", "hat end", "t ends well" };
            //string[] input = { "actgag", "tcctagga", "gctctaaatcgctat", "cgtacgtac", "gtcttctatct", "actg", "agt", "cctaggagctc", "taaatcgct", "a", "tcgta", "cgtacgt", "cttctatct", "actgagt", "cctaggagctc", "taaatcg", "ctatcgtacgtacgtct", "tctatct", "actga", "gtcctaggagc", "tctaaatcgctat", "cgtacgtacgtc", "ttctatct", "actg", "agtcctaggagctctaaat", "cgctatcgtacgtacg", "tcttct", "atct", "actgagtcctaggagc", "tctaaatcgctatcgta", "cgtacgtcttctatct", "actgagt", "cctaggag", "ctctaaat", "cgctatcg", "tacgtacgt", "cttctatct"};
            List<string> origCollection = new List<string>(input);

            Console.WriteLine(string.Join("\n", origCollection.ToArray()));

            GreedySCS greedySCS = new GreedySCS(origCollection);
            string result = greedySCS.GetGreedySCS();
            Console.WriteLine(result);

            Console.WriteLine("Finish");
        }





    }
}
