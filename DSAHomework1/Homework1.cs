using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAHomework1
{
    class Homework1
    {
        // returns a new array populated with contents of original array
        // with the given value inserted at the given index
        // edge cases: 
        // ** array is null or empty -- "error - array must have at least one value"
        // ** array has one value
        // ** index is negative -- "error - index cannot be negative"
        // ** index is zero -- insert at beginning of the array
        // ** index is greater than the length of the array -- insert at the end of the array
        public static int[] Insert(int[] array, int index, int value)
        {
            //edge cases
            // array is null
            if (array == null )
            {
                throw new ArgumentException("input array cannot be null");
            }
            
            // create new array one larger than original
            int[] newArray = new int[array.Length + 1];

            // copy elements up to insert point from original array to new array

            return null;

        }
    }
}
