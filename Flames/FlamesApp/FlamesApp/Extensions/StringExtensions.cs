
namespace FlamesApp.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSimilarLettersWith(this string s1, string s2)
        {
            s1 = s1.ToLower().Replace(" ", "");
            s2 = s2.ToLower().Replace(" ", "");

            for (int i = 0; i < s1.Length; i++)
            {
                char s1Char = s1[i];
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        s1 = s1.Remove(i, 1);
                        i--;
                        break;
                    }
                }
            }

            return s1;
        }
    }
}
