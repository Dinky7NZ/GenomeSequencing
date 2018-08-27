using System;
using System.Collections.Generic;



namespace GenomeSequencing
{
    /// <summary>
    /// Class that finds the maximum overlap given a set of strings
    /// </summary>
    public class MaxOverlapFinder
    {

        private List<string> fragmentCollection;

        //track the max overlap as we find overlap between fragment pairs
        private int maxOverlap = 0;

        //indexes of the strings in the collection that have the max overlap
        private int index1 = 0;
        private int index2 = 0;

        //the merged string of the overlaped string fragments
        private string mergedFragment = null;


        public MaxOverlapFinder(List<string> fragmentCollection)
        {
            this.fragmentCollection = fragmentCollection;
        }

        /// <summary>
        /// Method that finds the index of the 2 strings that have the maximum overlap
        /// </summary>
        /// <returns>The index of 2 strings with max overlap and the merged string of the 2 fragments</returns>
        public Tuple<int, int, string> FindMaxOverlap()
        {
            //nested loop to grab all unique fragment pairs to find overlap for
            for (int i = 0; i < fragmentCollection.Count; i++)
            {
                for (int j = i + 1; j < fragmentCollection.Count; j++)
                {
                    OverlapFinder finder = new OverlapFinder(fragmentCollection[i], fragmentCollection[j]);
                    
                    var overlapResults = finder.FindOverlap();

                    //As we interate through each permutation, check if the current overlap is more than the previous max overlap
                    //Overwrite the old overlap details if the current overlap is longer
                    if (overlapResults.Item1 > maxOverlap)
                    {
                        maxOverlap = overlapResults.Item1;
                        index1 = i;
                        index2 = j;
                        mergedFragment = overlapResults.Item2;
                    }
                }


            }

            return Tuple.Create(index1, index2, mergedFragment);

        }
    }
}
