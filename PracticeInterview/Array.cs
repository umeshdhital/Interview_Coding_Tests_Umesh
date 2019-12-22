using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/***************************** This is from https://www.udemy.com/course/data-structures-and-algorithms-bootcamp/ *****************************************************************/
namespace PracticeInterview
{
    public class DynamicArray<T>
    {

        private object[] data;

        // Counter for the number of elements in our array        
        private int currentSize = 0;

        // The capacity of our array - or how many elements it can hold, what we double when the number of elements exceeds the capacity of the array.
        private int initialCapacity;

        public DynamicArray(int initialCapacity)
        {
            this.initialCapacity = initialCapacity;
            data = new object[initialCapacity];

        }

        public virtual T Get(int index)
        {
            return (T)data[index];
        }

        public virtual void Add(T value)
        {
            data[currentSize] = value;
            currentSize++;

        }

        /************* Insert and Delete are Very Very Important *******************************/
        public virtual void Insert(int index, T value)
        {
            //Insert consists of 3 steps
            //1. Move all the elements to the right (up) to make room for new value
            //2. Insert the value at given indes
            //3. Increase the currentSize of array

            for (int i = currentSize; i > index; i--)
            {
                data[i] = data[i-1];
            }
            data[index] = value;
            currentSize++;

        }
        public virtual void Delete(int index)
        {

        }

        /************************ End Insert and Delete *************************************/

        public virtual bool Contains(T value)
        {
            bool returnValue = false;
            for (int i = 0; i < currentSize; i++)
            {
                if (data[i] == (object)value)
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }



        public virtual void Set(int index, T value)
        {
            data[index] = value;
        }






        private void Resize()
        {
            object[] newData = new object[initialCapacity * 2];
            for (int i = 0; i < initialCapacity; i++)
            {
                newData[i] = data[i];
            }
            data = newData;
            initialCapacity = initialCapacity * 2;
        }

        public virtual int Size()
        {
            return currentSize;
        }

        public virtual void Print()
        {
            for (int i = 0; i < currentSize; i++)
            {
                Console.WriteLine("data[i] = " + data[i]);
            }
        }
    }
}

