using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    public class PigLatinTranslator
    {
        private const string SUFFIX = "ay";

        public string translate(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";

            string[] words = s.Trim().Split(' ');

            for (int i = 0; i < words.Length; i++)
                words[i] = firstLetterToLastPos(words[i].Trim()) + SUFFIX;

            return string.Join(" ", words);
        }

        private string firstLetterToLastPos(string s)
        {
            char firstLetter = s[0];
            string reordered = s.Remove(0, 1) + firstLetter.ToString();
            return reordered;
        }
    }
}
