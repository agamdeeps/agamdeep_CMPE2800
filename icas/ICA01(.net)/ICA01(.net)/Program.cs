// Project : Extension methods, generics and Indexers
// Sept 14 2025
// By Agamdeep Singh
//
// MyLibrary type - class definition - support class
// Print Format : Landscape
// ///////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ICA01
{

    internal class Program
    {
        static Random _rnd = new Random();
        static void Main(string[] args)
        {
            List<int> iNums = new List<int>(new int[] { 4, 12, 4, 3, 5, 6, 7, 6, 12 });
            foreach (KeyValuePair<int, int> scan in iNums.Categorize())
                Console.WriteLine($"{scan.Key:d3} x {scan.Value:d5}");

            Console.WriteLine();

            List<string> names = new List<string>(new string[] {
            "Rick", "Glenn", "Rick", "Carl", "Michonne", "Rick", "Glenn" });
            foreach (KeyValuePair<string, int> scan in names.Categorize())
                Console.WriteLine($"{scan.Key} x {scan.Value:d5}");

            Console.WriteLine();

            LinkedList<char> llfloats = new LinkedList<char>();
            while (llfloats.Count < 1000)
                llfloats.AddLast((char)_rnd.Next('A', 'Z' + 1));
            foreach (KeyValuePair<char, int> scan in llfloats.Categorize())
                Console.WriteLine($"{scan.Key} x {scan.Value:d5}");

            string TestString = "This is the test string, do not panic!";
            foreach (KeyValuePair<char, int> scan in TestString.Categorize())
                Console.WriteLine($"{scan.Key} x {scan.Value:d5}");

            Console.WriteLine();
            Console.WriteLine(names.Penultimate());

            Console.ReadKey();
        }
    }

    static class categ
    {
        static Random _rnd = new Random();

        /*=======================================================================================
        * Function :  public static Dictionary<T, int> Categorize<T>(this IEnumerable<T> sourceList)
        * Purpose : organises and orders a collection into a dictionary format
        * Argument - an enumerable collection of any type
        * Returns - a dictionary with any type as key and int as value
        =========================================================================================*/
        public static Dictionary<T, int> Categorize<T>(this IEnumerable<T> sourceList)
        {
            Dictionary<T, int> temp = new Dictionary<T, int>();     // We are assuming the key can be anything but the value is an int

            foreach (T item in sourceList)              // enumerating through collection
            {
                if (!temp.ContainsKey(item))            // if dict does not contain, create a new key 
                {
                    temp.Add(item, 1);
                }
                else                                   // add one to existing
                {
                    temp[item]++;
                }
            }
            /*sourceList.(x =>
            {
                if (!temp.ContainsKey(x))
                {
                    temp.Add(x, 1);
                }
                else
                {
                    temp[x]++;
                }
            });*/

            return temp.OrderBy(dict => dict.Key).ToDictionary(x => x.Key, x => x.Value);       // returing an ordered by key dictionary
        }

        /*=======================================================================================
        * Function :  public static T Penultimate<T>(this IEnumerable<T> collect)
        * Purpose : returns the second last element
        * Argument - an enumerable collection of any type
        * Returns - any type
        =========================================================================================*/
        public static T Penultimate<T>(this IEnumerable<T> collect)
        {
            return collect.ElementAtOrDefault(collect.Count() - 2);         // utilizes element at extension method to get element at particular position
        }

        /*=======================================================================================
        * Function :  public static Tuple<T,int> Rando<T>(Dictionary<T,int> sourceDict)
        * Purpose : returns a key and its value at a random index in an ienumerable
        * Argument - an dictionary of any key type
        * Returns - Tuple 
        =========================================================================================*/
        public static Tuple<T, int> Rando<T>(Dictionary<T, int> sourceDict)
        {
            if (sourceDict.Count() != 0)                                             // checking if the dict is empty
            {
                int randPos = sourceDict.Count() - 1;                               // getting a random location
                return Tuple.Create(sourceDict.ElementAt(randPos).Key, sourceDict.ElementAt(randPos).Value);    // returning the tuple
            }
            else
            {
                throw new ArgumentException("No elements in the dictionary");       // throwing exception if empty dict
            }
        }

        /*=======================================================================================
        * Function :  public static T AdjacentDuplicate<T>(this IEnumerable<T> source)
        * Purpose : returns the first instance of an adjacent element
        * Argument - an enumerable collection of any type
        * Returns - the element which is of any type
        =========================================================================================*/
        public static T AdjacentDuplicate<T>(this IEnumerable<T> source)
        {
            if (source.Count() == 0)                 // checking if collection is empty
            {
                return default;
            }

            if (!source.GetEnumerator().MoveNext())
            { return default; }

            T curr = source.GetEnumerator().Current;        //get the first elememt

            while (source.GetEnumerator().MoveNext())        // while there exists an element for next index
            {
                if (curr.Equals(source.GetEnumerator().Current))   // if adjacent is found
                    return curr;

                curr = source.GetEnumerator().Current;           // replace the current with next
            }

            return default;
        }

        /*=======================================================================================
        * Function :   public static Tuple<string, int> StringDisplay<T>(this IEnumerable<T> collect)
        * Purpose : joins the elements of collection using commas
        * Argument - an enumerable collection of any type
        * Returns - a tuple where the first element is the string and second is the count
        =========================================================================================*/
        public static Tuple<string, int> StringDisplay<T>(this IEnumerable<T> collect)
        {
            return Tuple.Create(string.Join(",", collect), collect.Count());        // using string join to obtain the required string
        }
    }

    public class CategorizedStack<T> : Stack<T>
    {
        /*=======================================================================================
       * Function :    public T this [int index]
       * Purpose : indexer overload which takes in an index and returns the key at that index
       * Argument - index of type int
       * Returns - key which can be any type
       =========================================================================================*/
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Categorize().Count)   // checking if index is the required bounds
                {
                    throw new ArgumentException("Invalid Index");
                }

                return this.Categorize().ElementAt(index).Key;          // first use categorize to get the organized and sorted dict, and them return the key
            }
        }

        /*=======================================================================================
       * Function :       public int this[T key]
       * Purpose : checks for a key in the dict and returns its value
       * Argument - key of any type
       * Returns - value of key which is an int
       =========================================================================================*/
        public int this[T key]
        {
            get
            {
                if (this.Categorize().ContainsKey(key))             // checking if the dictionary contains the key
                {
                    return this.Categorize()[key];                  // returning the value of that key
                }

                else
                    throw new ArgumentException("Key not found in collection!!");
            }
        }
    }
}
