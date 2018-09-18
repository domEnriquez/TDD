using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class BoundedStack : IStack
    {
        private int capacity;
        private int size;
        private int[] elements;

        public static IStack Make(int capacity)
        {
            if (capacity < 0)
                throw new IllegalCapacityException();

            if (capacity == 0)
                return new ZeroCapacityStack();

            return new BoundedStack(capacity);
        }

        private BoundedStack(int capacity)
        {
            this.capacity = capacity;
            elements = new int[capacity];
        }

        public bool IsEmpty()
        {
            return size == 0;
        }
        public int getSize()
        {
            return size;
        }

        public void push(int element)
        {
            if (size >= capacity)
                throw new OverflowException();
            elements[size++] = element;
        }

        public int pop()
        {
            if (IsEmpty())
                throw new UnderflowException();
            return elements[--size];
        }

        public int top()
        {
            if (IsEmpty())
                throw new EmptyStackException();
            return elements[size - 1];
        }

        public int? find(int element)
        {
            for(int i = size - 1; i >= 0; i--)
            {
                if (element == elements[i])
                    return (size-1) - i;
            }
            return null;
        }

        public class OverflowException : ApplicationException
        {

        }

        public class UnderflowException : ApplicationException
        {
        }

        public class IllegalCapacityException : ApplicationException
        {
        }

        public class EmptyStackException : ApplicationException
        {

        }

        private class ZeroCapacityStack : IStack
        {
            public int? find(int element)
            {
                throw new NotImplementedException();
            }

            public int getSize()
            {
                return 0;
            }

            public bool IsEmpty()
            {
                return true;
            }

            public int pop()
            {
                throw new UnderflowException();
            }

            public void push(int element)
            {
                throw new OverflowException();
            }

            public int top()
            {
                throw new EmptyStackException();
            }
        }
    }
}
