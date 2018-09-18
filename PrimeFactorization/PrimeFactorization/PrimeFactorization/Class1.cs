using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactorization
{
    public class PrimeFactorization
    {

        public static List<int> GetPrimeFactors(int num)
        {
            List<int> primeFactors = new List<int>();

            if (num == 1)
                return new List<int>();

            if(IsPrime(num))
            {
                return new List<int> { num };
            }
            else
            {
                primeFactors = noobPrimeFactorization(num);
                return primeFactors;
            }
        }

        private static List<int> noobPrimeFactorization(int num)
        {
            List<int> primeFactors = new List<int>();

            for (int i = 2; i <= num; i++)
            {
                if (IsPrime(i) && num % i == 0)
                {
                    primeFactors.Add(i);
                }
            }

            return primeFactors;
        }

        public static bool IsPrime(int num)
        {
            for(int i = 2; i <= Math.Sqrt(num); i++)
            {
                if(num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
