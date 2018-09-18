using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame
{
    public class SecondPlayer : Player
    {
        private const string SECOND_PLAYER_DEFAULT_NAME = "Player 2";
        public SecondPlayer(string name) : base(name)
        {
        }

        protected override string GetDefaultName()
        {
            return SECOND_PLAYER_DEFAULT_NAME;
        }
    }
}
