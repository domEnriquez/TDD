using System;
using System.Collections;

namespace MultiCurrencyMoney
{
    public class Bank
    {
        private Hashtable rates = new Hashtable();

        public Money reduce(Expression source, string to)
        {
            return source.reduce(this, to);
        }

        public int rate(string from, string to)
        {
            if (from.Equals(to)) return 1;
            int rate = (int)rates[new Pair(from, to)];
            return rate;
        }

        public void addRate(string from, string to, int rate)
        {
            rates.Add(new Pair(from, to), rate);
        }
    }
}
