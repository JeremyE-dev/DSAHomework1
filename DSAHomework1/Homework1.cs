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

        //** Order of Growth Analysis **
        // The Order of growth for this algorithm is O(n) because the growth depends on the size of the input array
        // There are two loops that iterate over the array, both of which depend on the size of the array
        // The loops are not nested so the time complexity would be O(n) + O(n) = O(2n), after discarding the constant
        // the time complexity is O(n)
        public static int[] Insert(int[] array, int index, int value)
        {
            //begin edge cases

            // array is null
            if (array == null ) // O(1)
            {
                throw new ArgumentException("input array cannot be null"); // O(1)
            }

            // index is negative
            if (index < 0) // O(1)
            {
                throw new ArgumentException("index cannot be negative"); // O(1)
            }

            // if index is greater that the last index of the current array, place at end
            if (index > array.Length - 1) // O(1)
            {
                index = array.Length; // O(1)
            }

            // end edge cases
            
            // create new array one larger than original
            int[] newArray = new int[array.Length + 1]; // O(1)

            // copy elements up to insert point from original array to new array
            // This is O(n) because in the worst case the index will be the size of the array, therefore it 
            // depends on the size of the array
            for (int i = 0; i < index; i++) // O(n)
            {
                newArray[i] = array[i]; // O(1)
            }

            // insert value at index
            newArray[index] = value; 

            // copy remaining elements from original array to new array
            for (int i = index; i < array.Length; i++) // O(n)
            {
                newArray[i + 1] = array[i]; // O(1)
            }

            return newArray; // O(1)

        }
    }
}
