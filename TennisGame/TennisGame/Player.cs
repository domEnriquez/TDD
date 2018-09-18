using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    public abstract class Player
    {
        public string Name { get; private set; }
        public int Score { get; private set; }

        public static readonly Player NULL = new NullPlayer();

        public Player()
        {

        }

        public Player(string name)
        {
            if (invalidName(name))
                Name = GetDefaultName();
            else           
                Name = name;
        }

        protected bool invalidName(string name)
        {
            if (name == string.Empty)
                return true;
            else
                return false;
        }

        protected abstract string GetDefaultName();

        public void incrementScore()
        {
            Score++;
        }

        private class NullPlayer : Player
        {
            public NullPlayer()
            {

            }

            public NullPlayer(string name) : base(name)
            {
            }

            protected override string GetDefaultName()
            {
                return string.Empty;
            }
        }
    }
}
