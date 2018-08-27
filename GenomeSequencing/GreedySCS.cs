using System;
using System.Collections.Generic;


namespace GenomeSequencing
{
    /// <summary>
    /// Class that works out the Shortest Common Superstring of a set of strings using the greedy match and merge method.
    /// </summary>
    public class GreedySCS
    {

        private List<string> fragmentCollection;

        public GreedySCS(List<string> fragmentCollection)
        {
            this.fragmentCollection = fragmentCollection;
        }


        /// <summary>
        /// Works out the SCS of the string collection passed into the object
        /// </summary>
        /// <returns>The string that represents the Shortest Common Superstring</returns>
        public string GetGreedySCS()
        {
            //while there is more than 1 string in the collection we match and merge.
            //when there is 1 string left in the collection, that is Shortest Common Superstring
            while (fragmentCollection.Count > 1)
            {
                MaxOverlapFinder maxFinder = new MaxOverlapFinder(fragmentCollection);
                var result = maxFinder.FindMaxOverlap();
                //delete item2 first because it will always be higher index that item1
                //else get bug where item1 deleted then the indexes of the list change and deleting index item2
                //is not the right index anymore because the indexes have changed after the first item removal
                fragmentCollection.RemoveAt(result.Item2);
                fragmentCollection.RemoveAt(result.Item1);

                fragmentCollection.Add(result.Item3);
            }

            //FIXME better way of doing this?
            return string.Join(" ", fragmentCollection.ToArray());
        }
    }
}
