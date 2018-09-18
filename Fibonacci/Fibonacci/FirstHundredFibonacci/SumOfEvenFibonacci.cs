using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class SumOfEvenFibonacci
    {
        public BigInteger getSumOfEvenFibNumWhichDoesNotExceed(BigInteger bound)
        {
            BigInteger sum = 0;

            BigInteger next = 3;
            BigInteger prev = 1;

            for (BigInteger curr = 2; curr <= bound; next = curr + prev)
            {
                if (curr % 2 == 0)
                    sum += curr;

                prev = curr;
                curr = next;
            }

            return sum;
        }
    }
}
