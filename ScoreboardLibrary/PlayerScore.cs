using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardLibrary
{
    public class PlayerScore
    {
        private string player;
        private int score;

        public string Player
        {
            get { return player; }
            set { player = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public PlayerScore(string player, int score)
        {
            Player = player;
            Score = score;
        }

        public override string ToString()
        {
            return @$"{Player}     |     {Score} / 10";
        }
    }
}
