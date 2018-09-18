using PrimeFactorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeFactoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeFactor pf = new PrimeFactor();
            Console.WriteLine(pf.getLargestPrimeFactor(600851475143));
            Console.WriteLine();
        }
    }
}
