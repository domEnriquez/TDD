using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateArray
{
    public class RotateArr
    {
        public List<int> rotate(List<int> input, int count)
        {
            if (input == null)
                return null;
            else if (input.Count() == 0)
                return input;
            else
            {
                for (int i = 0; i < count; i++)
                {
                    int temp = input[0];
                    var lastIndex = input.Count() - 1;
                    shiftLeft(input, lastIndex);
                    input[lastIndex] = temp;
                }

                return input;
            }

        }

        private static void shiftLeft(List<int> input, int lastIndex)
        {
            for (int j = 0; j < lastIndex; j++)
            {
                input[j] = input[j + 1];
            }
        }
    }
}
