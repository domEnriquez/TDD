using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class FibonacciRange
    {
        public List<BigInteger> getFibonacciRange(int range)
        {
            List<BigInteger> num = new List<BigInteger>();

            if (range > 0)
            {
                num.Add(0);
                for (int i = 1; i < range; i++)
                {
                    if (i == 1)
                        num.Add(1);
                    else
                    {
                        num.Add(num[i - 1] + num[i - 2]);
                    }
                }
            }

            return num;
        }
    }
}
