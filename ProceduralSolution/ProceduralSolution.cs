using System;
using System.Collections.Generic;


namespace Procedural
{
    class ProceduralSolution
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");

            //hardcode input for now
            string[] input = {"a l l   i s   w e l l", "e l l   t h a t   e n", "h a t   e n d", "t   e n d s   w e l l"};
            List<string> origCollection = new List<string>(input);

            Console.WriteLine(string.Join("\n", origCollection.ToArray()));

            string result = DoGreedySCS(origCollection);
            Console.WriteLine(result);

            Console.WriteLine("Finish");
        }


        /// <summary>
        /// Finds the Shortest Common Superstring that will contain all string fragments in the provide fragment collection using the geedy match and merge approach.
        /// </summary>
        /// <param name="fragmentCollection">Collection of string fragments to find SCS</param>
        /// <returns></returns>
        static string DoGreedySCS(List<string> fragmentCollection)
        {



            while (fragmentCollection.Count > 1)
            {
                var result = FindMaxOverlap(fragmentCollection);
                //delete item2 first because it will always be higher index that item1
                //else get bug where item1 deleted then the indexes of the list change and deleting index item2
                //is not the right index anymore cause the indexes have changed after the list size changed
                fragmentCollection.RemoveAt(result.Item2);
                fragmentCollection.RemoveAt(result.Item1);
                
                fragmentCollection.Add(result.Item3);
            }


            return string.Join(" ", fragmentCollection.ToArray());
        }

        /// <summary>
        /// Finds the maximum overlap in a collection of string fragments created from duplicates of an original string that have been choped into pieces
        /// </summary>
        /// <param name="fragmentCollection">A list of string fragments</param>
        /// <returns></returns>
        static Tuple<int, int, string> FindMaxOverlap(List<string> fragmentCollection)
        {
            
            int maxOverlap = 0;
            int index1 = 0;
            int index2 = 0;
            string mergedFragment = null;
            

            for (int i = 0; i < fragmentCollection.Count; i++)
            {
                for (int j = i+1; j < fragmentCollection.Count; j++)
                {
                    var overlapResults = FindOverlap(fragmentCollection[i], fragmentCollection[j]);
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

        //C#7 will give simpler tuple syntax "static (int, string) FindOverlap(string fragmentA, string fragmentB)"
        /// <summary>
        /// Given 2 string fragments, it finds the longest overlap between the 2 strings.
        /// It will try overlapping A to B and B to A
        /// </summary>
        /// <param name="fragmentA">First string fragment</param>
        /// <param name="fragmentB">Second string fragment</param>
        /// <returns></returns>
        static Tuple<int, string> FindOverlap(string fragmentA, string fragmentB)
        {
            int overlap = 0;
            string mergedFragment = null;

            //originally had this inside the for loop but is inefficient because it will calculate the min length each time. this will be faster
            int minStringLen = Math.Min(fragmentA.Length, fragmentB.Length);

            //check the postfix of a with prefix of b to find overlap
            //
            for (int i = 1; i < minStringLen; i++)
            {
                //compare the last i chars of fragmentA with the first i chars of fragmentB
                if (string.Compare(fragmentA.Substring(fragmentA.Length-i, i), fragmentB.Substring(0, i)) == 0 )
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


            return Tuple.Create(overlap, mergedFragment);
        }

    
    }
}
