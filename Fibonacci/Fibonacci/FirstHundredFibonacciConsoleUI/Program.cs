using Fibonacci;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace FibonacciConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //runFibonacciRange();
            runSumOfEvenFibonacci();
            Console.WriteLine();
        }

        private static void runSumOfEvenFibonacci()
        {
            SumOfEvenFibonacci soef = new SumOfEvenFibonacci();

            Console.WriteLine(soef.getSumOfEvenFibNumWhichDoesNotExceed(4000000));
        }

        private static void runFibonacciRange()
        {
            FibonacciRange fr = new FibonacciRange();

            List<BigInteger> nums = fr.getFibonacciRange(4000000);

            for (int i = 0; i < nums.Count; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}
