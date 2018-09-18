using System;

namespace MultiCurrencyMoney
{
    public class Money : Expression
    {
        public Money(int amount, string currencyCode)
        {
            this.amount = amount;
            this.currencyCode = currencyCode;
        }

        public int amount;
        protected string currencyCode;

        public string currency()
        {
            return currencyCode;
        }

        public override bool Equals(Object obj)
        {
            Money money = (Money)obj;
            return amount == money.amount 
                && currency().Equals(money.currency());
        }

        public static Money dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public Money reduce(Bank bank, string to)
        {
            int rate = bank.rate(currencyCode, to);
            return new Money(amount / rate, to);
        }

        public static Money franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public override string ToString()
        {
            return amount + " " + currencyCode;
        }
        public Expression times(int multiplier)
        {
            return new Money(amount * multiplier, currencyCode);
        }

        public Expression plus(Expression addend)
        {
            return new Sum(this, addend);
        }

    }
}
