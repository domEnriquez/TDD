using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LychrelNumbers
{
    public class Lychrel
    {
        public static int ConvergestAtIteration(int num, int linmit)
        {
            return converge(num, 0);
        }

        private static int converge(int num, int iteration)
        {
            if (!IsPalindrome(num))
            {
                iteration++;
                return converge(num + Reverse(num), iteration);
            } else
            {
                return iteration;
            }
        }

        public static bool IsPalindrome(int num)
        {
            string numString = num.ToString();
            int lastIndex = numString.Length - 1;

            for (int i = 0; i < numString.Length; i++)
                if (numString[i] != numString[lastIndex - i])
                    return false;

            return true;
        }

        public static int Reverse(int num)
        {
            string numString = num.ToString();
            char[] numCharArray = numString.ToCharArray();
            int lastIndex = numString.Length - 1;

            for(int i = 0; i < numString.Length / 2; i++)
            {
                char temp = numCharArray[i];
                numCharArray[i] = numCharArray[lastIndex - i];
                numCharArray[lastIndex - i] = temp;
            }

            return Convert.ToInt32(new string(numCharArray));
        }
    }
}
