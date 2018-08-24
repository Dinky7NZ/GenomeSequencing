using System;
using System.Collections.Generic;


namespace GenomeSequencing
{
    /// <summary>
    /// Class to find overlap of 2 strings
    /// </summary>
    public class OverlapFinder
    {
        private string fragmentA;
        private string fragmentB;


        public OverlapFinder (string fragmentA, string fragmentB)
        {
            this.fragmentA = fragmentA;
            this.fragmentB = fragmentB;
        }


        /// <summary>
        /// Method that finds the overlap of 2 strings
        /// TODO break out each of the checks as separate methods for tidier code
        /// </summary>
        /// <returns>A tuple containing the max size of the overlap and the merged strings</returns>
        public Tuple<int, string> FindOverlap()
        {
            int overlap = 0;
            string mergedFragment = null;

            //originally had this inside the for loop but is inefficient because it will calculate the min length each time. this will be faster
            int minStringLen = Math.Min(fragmentA.Length, fragmentB.Length);

            //check the postfix of a with prefix of b to find overlap
            for (int i = 1; i < minStringLen; i++)
            {
                //compare the last i chars of fragmentA with the first i chars of fragmentB
                if (string.Compare(fragmentA.Substring(fragmentA.Length - i, i), fragmentB.Substring(0, i)) == 0)
                {
                    //there is a match, record the overlap and merged string.
                    overlap = i;
                    mergedFragment = fragmentA + fragmentB.Substring(i);


                }

            }

            //check the prefix of fragmentA with the postfix of fragmentB to find overlap
            for (int i = 1; i < minStringLen; i++)
            {
                //compare the last i chars of fragmentA with the first i chars of fragmentA
                if (string.Compare(fragmentB.Substring(fragmentB.Length - i, i), fragmentA.Substring(0, i)) == 0)
                {
                    //there is a match
                    //If matching fragmentB to fragmentA has a larger over lap than matching fragmentA to fragmentB, record larger overlap and merged fragment
                    if (i > overlap)
                    {
                        overlap = i;
                        mergedFragment = fragmentB + fragmentA.Substring(i);
                    }
                }

            }

            //check if fragmentA fully contain fragementB
            if (fragmentA.Contains(fragmentB))
            {
                overlap = fragmentB.Length;
                mergedFragment = fragmentA;
            }

            //check if fragmentA fully contain fragementB
            if (fragmentB.Contains(fragmentA))
            {
                overlap = fragmentA.Length;
                mergedFragment = fragmentB;
            }

            //concate the 2 full fragments if there has been no match
            if (overlap == 0)
            {
                //no overlap found, just concatenate the 2 fragments
                mergedFragment = fragmentA + fragmentB;
            }

            return Tuple.Create(overlap, mergedFragment);
        }
    }
}
