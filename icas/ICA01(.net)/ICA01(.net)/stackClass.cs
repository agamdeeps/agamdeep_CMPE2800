using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICA01;

namespace ICA01_.net_
{
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
                if (index < 0 || index > this.Categorize().Count)   // checking if index is the required bounds
                {
                    throw new IndexOutOfRangeException("Invalid Index");
                }

                return this.Categorize().ElementAt(index).Key;          // first use categorize to get the organized and sorted dict, and them return the key
            }
        }

        /*=======================================================================================
       * Function : public int this[T key]
       * Purpose : checks for a key in the dict and returns its value
       * Argument - key of any type
       * Returns - value of key which is an int
       =========================================================================================*/
        public int this[T key]
        {
            get
            {
                if (this.Contains(key))             // checking if the dictionary contains the key
                {
                    return this.Categorize()[key];                  // returning the value of that key
                }
                else
                {
                    throw new ArgumentException("Key not found in collection!!");
                }
            }
        }
    }
}
