using System;

namespace Queue
{
    public class Queue
    {
        private int size = 0;
        private int capacity = 0;
        private int[] numArray;

        public Queue(int capacity)
        {
            if(capacity < 0)
                throw new QueueIllegalCapacityException();
            
            this.capacity = capacity;
            numArray = new int[this.capacity];
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }


        public void Enqueue(int num)
        {
            if(size >= capacity)
                throw new QueueOverflowException();
            
            numArray[size++] = num;
        }

        public int Dequeue()
        {
            if (IsEmpty())
                throw new QueueUnderflowException();

            size--;
            int retVal = numArray[0];
            shiftElementsToLeft(numArray);

            return retVal;
        }

        public int peek()
        {
            if (IsEmpty())
                throw new QueueUnderflowException();

            return numArray[0];
        }

        public int? find(int target)
        {
            if (IsEmpty())
                throw new QueueUnderflowException();

            for(int i = 0; i < capacity; i++)            
                if (numArray[i] == target)
                    return i;

            return null;
            
        }

        private void shiftElementsToLeft(int[] numArray)
        {
            for(int i = 0; i < numArray.Length - 1; i++)
            {
                numArray[i] = numArray[i + 1];
            }
        }

        public class QueueIllegalCapacityException : ApplicationException
        {
        }

        public class QueueOverflowException : ApplicationException
        {
        }

        public class QueueUnderflowException : ApplicationException
        {
        }
    }
}
