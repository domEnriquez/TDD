using System.Collections.Generic;

namespace NumberDissector
{
    public class IntDissector
    {
        public List<int> dissected;

        public List<int> dissect(int num)
        {
            if (num < 10)
                dissected.Add(num);
            else
            {
                dissect(num / 10);
                dissected.Add(num % 10);
            }

            return dissected;
        }
    }
}
