using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactorization
{
    public class PrimeFactor
    {
        public List<BigInteger> getPrimeFactors(BigInteger num)
        {
            List<BigInteger> pf = new List<BigInteger>();

            if (num > 1)
            {
                for (int divisor = 2; num > 1; divisor++)
                {
                    while (num % divisor == 0)
                    {
                        pf.Add(divisor);
                        num /= divisor;
                    }
                }
            }
            return pf;
        }

        public BigInteger getLargestPrimeFactor(BigInteger num)
        {
            if (num > 1)
            {
                List<BigInteger> factors = getPrimeFactors(num);

                BigInteger largest = 0;

                foreach (BigInteger factor in factors)
                    if (factor > largest)
                        largest = factor;

                return largest;
            }

            return -1;
        }
    }
}
