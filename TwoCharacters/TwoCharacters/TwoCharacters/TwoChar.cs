using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoCharacters
{
    public class TwoChar
    {
        public int countLongestAlternatingChar(string s)
        {
            if (invalidString(s) || s.Length == 1)
                return 0;

            if (alternatingChar(s))
                return s.Length;
            else
            {
                string converted = extractLongestAltChar(s);
                return converted.Length;
            }
        }

        public string extractLongestAltChar(string s)
        {
            List<string> altChar = new List<string>();
            altChar = extractAltCharFrom(s, altChar);

            if (altChar.Count() > 0)
                return getLongestStringFrom(altChar);
            else
                return string.Empty;
        }

        public List<string> extractAltCharFrom(string s, List<string> altChar)
        {
            if(s.Length > 1)
            {
                if (alternatingChar(s) && !altChar.Contains(s))
                    altChar.Add(s);

                for (int i = 0; i < s.Length; i++)
                {
                    string reduced = removeCharFrom(s, i);
                    extractAltCharFrom(reduced, altChar);
                }
            }

            return altChar;
        }

        public bool alternatingChar(string s)
        {
            if (s.Length == 1)
                return false;

            if (s.Length == 2)
                return alternateFirstTwoChar(s);
            else
            {
                if (alternateFirstTwoChar(s))
                    return equalWithEveryOtherChar(s, 0)
                            && equalWithEveryOtherChar(s, 1);
                else
                    return false;
            }
        }

        private string getLongestStringFrom(List<string> alternatingStrings)
        {
            return alternatingStrings.OrderByDescending(altString => altString.Length).First();
        }

        private string removeCharFrom(string s, int i)
        {
            return s.Replace(s[i].ToString(), string.Empty);
        }

        private bool invalidString(string s)
        {
            return string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);
        }

        private bool alternateFirstTwoChar(string s)
        {
            if (s[0] != s[1])
                return true;
            else
                return false;
        }

        private bool equalWithEveryOtherChar(string s, int startingIndex)
        {
            for (int i = startingIndex; i < s.Length - 2; i += 2)
                if (s[i] != s[i + 2])
                    return false;

            return true;
        }
    }
}
