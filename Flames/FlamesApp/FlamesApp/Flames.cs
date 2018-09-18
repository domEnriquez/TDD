using FlamesApp.Extensions;

namespace FlamesApp
{
    public class Flames
    {
        private const int FLAMES_LENGTH = 6;

        public string execute(string name1, string name2)
        {
            if (name1 == name2)
                return string.Empty;

            string newName1 = name1.RemoveSimilarLettersWith(name2);
            string newName2 = name2.RemoveSimilarLettersWith(name1);

            return determineRelationship(newName1.Length + newName2.Length);
        }

        private string determineRelationship(int totalLetters)
        {
            if (totalLetters % FLAMES_LENGTH == 1)
                return "Friends";
            else if (totalLetters % FLAMES_LENGTH == 2)
                return "Lovers";
            else if (totalLetters % FLAMES_LENGTH == 3)
                return "Anger";
            else if (totalLetters % FLAMES_LENGTH == 4)
                return "Marriage";
            else if (totalLetters % FLAMES_LENGTH == 5)
                return "Enemy";
            else if (totalLetters % FLAMES_LENGTH == 6 || totalLetters % FLAMES_LENGTH == 0)
                return "Soulmates";
            else
                return string.Empty;
        }
    }
}
