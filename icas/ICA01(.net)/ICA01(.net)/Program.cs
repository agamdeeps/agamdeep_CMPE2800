// Project : Extension methods, generics and Indexers
// Sept 14 2025
// By Agamdeep Singh
//
// MyLibrary type - class definition - support class
// Print Format : Landscape
// ///////////////////////////////////////////////////////////////////////////
using ICA01_.net_;
using System;
using System.Collections;
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

            Console.WriteLine();
            Console.WriteLine(iNums.Categorize().Rando());

            List<int> itemp = new List<int>(new int[] { 4, 12, 12, 3, 5, 6, 7, 6, 12 });
            
            Console.WriteLine($"{itemp.AdjacentDuplicate()}");

            Console.WriteLine();
            Console.WriteLine($"{itemp.StringDisplay()}");

            CategorizedStack<string> tempStack = new CategorizedStack<string>();
            tempStack.Push("max");
            tempStack.Push("sally");
            tempStack.Push("twenty");
            //tempStack.Push(3);
            //tempStack.Push(5);

            Console.WriteLine("Testing indexer by int index:");
            for (int i = 0; i < tempStack.Categorize().Count; i++)
            {
                Console.WriteLine($"Index {i} -> Key {tempStack[i]}");
            }

            Console.WriteLine();

            // Test the key indexer
            Console.WriteLine("Testing indexer by key:");
            Console.WriteLine($"Count for key 4: {tempStack["max"]}");
            //Console.WriteLine($"Count for key 12: {tempStack[12]}");
            Console.WriteLine($"Count for key 5: {tempStack["twenty"]}");

            Console.WriteLine($"{tempStack}");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
