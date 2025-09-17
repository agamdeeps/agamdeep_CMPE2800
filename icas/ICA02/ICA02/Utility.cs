// Project : ICA_Generators
// Sept 17 2025
// By Agamdeep Singh
//
// MyLibrary type - class definition - Utility class
// Print Format : Landscape
// ///////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA02
{
    public static class Utility
    {
        /*=======================================================================================
        * Function : public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> srcCollect)
        * Purpose : Shuffles and returns the elements as an Ienumerable
        * Argument - a generic enumerable
        * Returns - a generic enumerable
        =========================================================================================*/
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> srcCollect)
        {
            Random rnd = new Random();
            List<T> tempList = new List<T>(srcCollect);             // storing the argument collection as a list

            /*=======================================================================================
            * Function : void swapfunc(int num2)
            * Purpose : obtains the index of element to be randomised and changes it in the list
            * Argument - index of current element
            =========================================================================================*/
            void swapfunc(int num2)
            {
                T temp = tempList[num2];
                int rndNum = rnd.Next(num2, tempList.Count);
                tempList[num2] = tempList[rndNum];
                tempList[rndNum] = temp;
            }

            // Iterating thorugh the list
            for (int j = 0; j < srcCollect.Count(); j++)
            {
                swapfunc(j);                        // performing the swap
                yield return tempList[j];           // returning the swapped element
            }
        }

        /*=======================================================================================
        * Function :  public static IEnumerable<List<T>> Peel<T>(this IEnumerable<T> srcCollect)
        * Purpose : gets the first and last item from a collection and returns it
        * Argument - a generic enumerable
        * Returns - a enumerable generic list
        =========================================================================================*/
        public static IEnumerable<List<T>> Peel<T>(this IEnumerable<T> srcCollect)
        {
            if(srcCollect.Count() == 0) yield return new List<T>();                 // returning empty list if source collection is empty

            else
            {
                // Iterating and working its way through to return the first and last elements
                for (int i = 0; i < srcCollect.Count() / 2; i++)
                {
                    yield return new List<T> { srcCollect.ElementAt(i), srcCollect.ElementAt(srcCollect.Count() - i - 1) };
                }

                // Case for an odd numbered collection
                if ( srcCollect.Count() % 2 != 0)
                {
                    yield return new List<T> { srcCollect.ElementAt(srcCollect.Count() / 2) };
                }
            }
        }

        /*=======================================================================================
        * Function : public static IEnumerable<T> Sample<T>(this IEnumerable<T> srcCollect)
        * Purpose : returns infinite number of elements from collection at random indices
        * Argument - a generic enumerable
        * Returns - a generic enumerable  
        =========================================================================================*/
        public static IEnumerable<T> Sample<T>(this IEnumerable<T> srcCollect)
        {
            Random rnd = new Random();

            while (true)
            {
                yield return srcCollect.ElementAtOrDefault(rnd.Next(0, srcCollect.Count()));
            }
        }
    }
}

