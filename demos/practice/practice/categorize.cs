using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice
{
    public static class Categ
    {
        public static Dictionary<T,int> Categorize<T>(this IEnumerable<T> srcCollect)
        {
            Dictionary<T, int> keyValuePairs = new Dictionary<T, int>();

            foreach (T item in srcCollect)
            {
                if(!keyValuePairs.ContainsKey(item))
                {
                    keyValuePairs.Add(item, 1);
                }
                else
                {
                    keyValuePairs[item]++;
                }
            }

            return keyValuePairs.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        }

        public static T Penultimate<T>(this IEnumerable<T> srcCollect) where T : new()
        {
            if(srcCollect.Count() < 2)
            {
                return new T();
            }
            else
            {
                return srcCollect.ElementAtOrDefault(srcCollect.Count() - 2);
            }
        }

        public static T AdjacentDuplicate<T>(this IEnumerable<T> srcCollect)
        {
            foreach (T item in srcCollect)
            {
                T temp = item;
            }
        }

        public static (string, int) StringDisplay<T>(this IEnumerable<T> srcCollect)
        {
            return (string.Join(",", srcCollect), srcCollect.Count());
        }
    }

    public class stackindexing<T> : Stack<T>
    {
        public T this[int index]
        {
            get
            {
                Dictionary<T, int> tempDict = this.Categorize();
                return tempDict.ElementAt(index).Key;
            }
        }

        public int this[T index]
        {
            get
            {
                if(this.Categorize().ContainsKey(index))
                {
                    return this.Categorize()[index];
                }
                else
                {
                    throw new Exception();
                }
            }
        }

    }
}
