using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    public class FirstPlayer : Player
    {
        private const string FIRST_PLAYER_DEFAULT_NAME = "Player 1";

        public FirstPlayer(string name) : base(name)
        {
        }

        protected override string GetDefaultName()
        {
            return FIRST_PLAYER_DEFAULT_NAME;
        }
    }
}
