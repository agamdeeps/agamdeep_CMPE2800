using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static Dictionary<T, int> Categorize<T>(this IEnumerable<T> sourceList)
        {
            Dictionary<T, int> temp = new Dictionary<T, int>();     // We are assuming the key can be any type but the value is an int

            foreach (T item in sourceList)
            {
                if (!temp.ContainsKey(item))
                {
                    temp.Add(item, 1);
                }
                else
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

            return temp.OrderBy(dict => dict.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        public static T Penultimate<T>(this IEnumerable<T> collect)
        {
            return collect.ElementAtOrDefault(collect.Count() - 2);
        }

        public static Tuple<T,int> Rando<T>(Dictionary<T,int> sourceDict)
        {
            if(sourceDict.Count() != 0)
            {
                int randPos = sourceDict.Count() - 1;
                return Tuple.Create(sourceDict.ElementAt(randPos).Key, sourceDict.ElementAt(randPos).Value);
            }
            else
            {
                throw new ArgumentException("No elements in the dictionary");
            }
        }

        public static Tuple<string, int> StringDisplay<T>(this IEnumerable<T> collect)
        {
            return Tuple.Create(string.Join(",", collect), collect.Count());
        }
    }

    public class stackMaker<T>
    {
        private Stack<T> srcStack = new Stack<T>();

        public T this[int iIndex]
        {
            get
            {
                if (iIndex < categ.Categorize(srcStack).Count - 1)
                    return categ.Categorize(srcStack).ElementAt(iIndex).Key;

                else
                    throw new ArgumentException("Index out of range");
            }
        }

        public T this[string key]
        {
            get
            {
                for(int i = 0;i < categ.Categorize(srcStack).Count; i++)
                {
                    if (categ.Categorize(srcStack)[i].ToString() == key)
                    {
                        return categ.Categorize(srcStack).ElementAt(iIndex).Key;
                    }
                }
            }
        }
    }
}
